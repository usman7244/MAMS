using Consul;
using DAL.Sql;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using Dapper;
namespace DAL
{

    public class GoogleDriveServiceHelper
    {
         
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };

        private static string ApplicationName = string.Empty;
        private static string ClientId = string.Empty;
        private static string ClientSecret = string.Empty;
        private static string RefreshToken = string.Empty;
        private static int Id=0;
        public static async Task<DriveService> GetService()
        {

            var tokenResponse = new TokenResponse
            {
                RefreshToken = RefreshToken
            };

            Google.Apis.Auth.OAuth2.UserCredential credentials = new UserCredential(
                new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = ClientId,
                        ClientSecret = ClientSecret
                    },
                    Scopes = Scopes,
                    DataStore = new FileDataStore("token.json", true)
                }),
                "user",
                tokenResponse);

            // Refresh the token asynchronously if needed
            if (credentials.Token.IsExpired(SystemClock.Default))
            {
                await credentials.RefreshTokenAsync(CancellationToken.None);
            }

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName,
            });
        }
        public static async Task<DriveService> GetServiceAsync(List<ConfigMgt> configMgt, ISqlConnectionFactory connectionFactory)
        {
            foreach (var item in configMgt)
            {
                  Id = item.Id;
                ApplicationName = item.ApplicationName;
                ClientId = item.ClientId;
                ClientSecret = item.ClientSecret;
                RefreshToken = item.RefreshToken;

            }

            var tokenResponse = new TokenResponse
            {
                RefreshToken = RefreshToken
            };

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret
                },
                Scopes = Scopes,
                DataStore = new FileDataStore("token.json", true)
            });

            var credentials = new UserCredential(flow, "user", tokenResponse);
            // Refresh the token if it has expired
            try
            {
                if (credentials.Token.IsExpired(SystemClock.Default))
                {
                    await credentials.RefreshTokenAsync(CancellationToken.None);
                    var NewRefreshToken = credentials.Token.RefreshToken;
                    await UpdateTokenInfo(connectionFactory, Id, ApplicationName, ClientId, ClientSecret, NewRefreshToken);


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error refreshing token: {ex.Message}");
            }

            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName,
            });
        }




        public static async Task<(string FileId, string FileUrl)> UploadFileAsync(Documents document, ISqlConnectionFactory connectionFactory)
        {
            var helper = new GoogleDriveServiceHelper();
            List<ConfigMgt> configMgts = await helper.GetTokenInfo(connectionFactory);

            try
            {
                var service = await GetServiceAsync(configMgts, connectionFactory);

                // Step 1: Search for existing folder with BranchId
                var listRequest = service.Files.List();
                listRequest.Q = $"mimeType = 'application/vnd.google-apps.folder' and name = '{document.BranchId}' and trashed = false";
                listRequest.Fields = "files(id, name)";
                var listResponse = await listRequest.ExecuteAsync();

                string folderId;
                if (listResponse.Files != null && listResponse.Files.Count > 0)
                {
                    folderId = listResponse.Files.First().Id;
                }
                else
                {
                    var folderMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = document.BranchId.ToString(),
                        MimeType = "application/vnd.google-apps.folder"
                    };
                    var folderRequest = service.Files.Create(folderMetadata);
                    folderRequest.Fields = "id";
                    var folder = await folderRequest.ExecuteAsync();
                    folderId = folder.Id;
                }

                // Step 2: Upload the file
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = document.File.FileName,
                    Parents = new List<string> { folderId }
                };

                FilesResource.CreateMediaUpload request;
                using (var memoryStream = new MemoryStream())
                {
                    await document.File.CopyToAsync(memoryStream);
                    request = service.Files.Create(fileMetadata, memoryStream, GetMimeType(document.File.FileName));
                    request.Fields = "id, webViewLink";
                    await request.UploadAsync();
                }

                var file = request.ResponseBody;

                // Step 3: Set the file permissions to public
                var permission = new Google.Apis.Drive.v3.Data.Permission()
                {
                    Role = "reader",
                    Type = "anyone"
                };
                await service.Permissions.Create(permission, file.Id).ExecuteAsync();

                return (file.Id, file.WebViewLink);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred during the file upload process.", ex);
            }
        }


        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }



        public static async Task<string> GetFileAsync(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException("FileId cannot be null or empty", nameof(fileId));
            }

            // Await GetService to get the DriveService instance
            var service = await GetService();
            if (service == null)
            {
                throw new InvalidOperationException("Service could not be initialized.");
            }

            var request = service.Files.Get(fileId);
            request.Fields = "webViewLink, webContentLink";

            try
            {
                var file = await request.ExecuteAsync();
                if (file == null)
                {
                    throw new InvalidOperationException("File could not be retrieved.");
                }

                var fileUrl = file.WebViewLink ?? file.WebContentLink;
                if (string.IsNullOrEmpty(fileUrl))
                {
                    throw new InvalidOperationException("File URL could not be found.");
                }

                return fileUrl;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve file URL.", ex);
            }
        }
        private async Task<List<ConfigMgt>> GetTokenInfo(ISqlConnectionFactory connectionFactory)
        {
            var configMgtList = new List<ConfigMgt>();

            try
            {
                await using var connection = connectionFactory.CreateConnection();

                string sqlQuery = "EXEC [dbo].[spGetConfigMgt]";

                var configMgt = await connection.QueryAsync<ConfigMgt>(sqlQuery, new { });

                configMgtList = configMgt.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return configMgtList;
        }
        public static async Task UpdateTokenInfo(ISqlConnectionFactory connectionFactory, int id, string applicationName, string clientId, string clientSecret, string refreshToken)
        {
            try
            {
                await using var connection = connectionFactory.CreateConnection();

                string sqlQuery = @"
                             UPDATE [dbo].[ConfigMgt]
                             SET 
                                 ApplicationName = @ApplicationName,
                                 ClientId = @ClientId,
                                 ClientSecret = @ClientSecret,
                                 RefreshToken = @RefreshToken
                             WHERE
                                 Id = @Id";

                await connection.ExecuteAsync(sqlQuery, new
                {
                    ApplicationName = applicationName,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RefreshToken = refreshToken,
                    Id = id
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }






    }
}