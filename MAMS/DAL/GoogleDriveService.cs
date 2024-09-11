using Consul;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MAMS_Models.Model;
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
namespace DAL
{

    public static class GoogleDriveServiceHelper
    {
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };
        private const string ApplicationName = "MAMS";
        private static readonly string ClientId = "1077577498265-ghmka0pqb1nhhfs6kucet4d1gp9r960a.apps.googleusercontent.com";
        private static readonly string ClientSecret = "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";
        private const string RefreshToken = "1//04BTLDqR--auSCgYIARAAGAQSNwF-L9Irgd7F_-HRK-Zo1uPedhjEFNC7qHPAc5Izc1gkaGtNRxBSxqH9e0qp07UWLc-YZfojmTA";

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

            //credentials.RefreshTokenMethod(CancellationToken.None).Wait();
            
            credentials =   RefreshTokenMethodAsync();

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName,
            });
        }
        //private static async Task<UserCredential> RefreshTokenMethodAsync()
        //{
        //    try
        //    {
        //        string UserId = "9B115365-E54C-4380-80E7-F4FA9075AD8A";
        //        // Initialize Google Authorization Code Flow
        //        var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        //        {
        //            ClientSecrets = new ClientSecrets
        //            {
        //                ClientId = "1077577498265-ghmka0pqb1nhhfs6kucet4d1gp9r960a.apps.googleusercontent.com",
        //                ClientSecret = "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"  // Replace with your actual ClientSecret
        //            },
        //            Scopes = new[]
        //            {
        //        DriveService.Scope.Drive,
        //        "https://www.googleapis.com/auth/userinfo.email",
        //        "https://www.googleapis.com/auth/userinfo.profile"
        //            },
        //            DataStore = new FileDataStore("Drive.Api.Auth.Store", true)
        //        });

        //        // Create a token response from the refresh token
        //        var tokenResponse = new TokenResponse
        //        {
        //            RefreshToken = RefreshToken  // Make sure you pass the refresh token in the request
        //        };

        //        // Initialize user credentials with the existing refresh token
        //        var credentials = new UserCredential(flow, UserId, tokenResponse);

        //        // Attempt to refresh the token
        //        var success = await credentials.RefreshTokenAsync(CancellationToken.None);

        //        if (success)
        //        {
        //            // Update token information after refresh
        //            var newToken = new GoogleTokenEntity
        //            {
        //                UserId = UserId,
        //                RefreshToken = credentials.Token.RefreshToken,
        //                AccessToken = credentials.Token.AccessToken,
        //                ExpiresInSeconds = credentials.Token.ExpiresInSeconds,
        //                IdToken = credentials.Token.IdToken,
        //                IssuedUtc = credentials.Token.IssuedUtc,
        //                Scope = credentials.Token.Scope,
        //                TokenType = credentials.Token.TokenType,
        //                Drive = true
        //            };


        //            // await StoreToken(newToken,UserId, CancellationToken.None);

        //            return credentials;
        //        }
        //        else
        //        {
        //            throw new Exception("Failed to refresh token.");
        //        }
        //    }
        //    catch (TokenResponseException tokenEx) when (tokenEx.Error.Error == "invalid_grant")
        //    {
        //        // Handle the invalid_grant error
        //        Console.WriteLine("Token has been expired or revoked. Re-authentication is required.");
        //        // Logic to re-authenticate and obtain a new refresh token should go here

        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle other exceptions
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw;
        //    }
        //}

        private static UserCredential RefreshTokenMethodAsync()
        {
            try
            {

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

                // Attempt to refresh the token
                credentials.RefreshTokenAsync(CancellationToken.None);

                return credentials;
            }
            catch (AggregateException ex) when (ex.InnerException is TokenResponseException tokenEx && tokenEx.Error.Error == "invalid_grant")
            {
                // Handle the invalid_grant error
                Console.WriteLine("Token has been expired or revoked. Re-authentication is required.");

                // Logic to re-authenticate and obtain a new refresh token should go here
                // For example, redirect the user to the Google authorization page

                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }



        public static async Task<(string FileId, string FileUrl)> UploadFileAsync(Documents document)
        {
            // Await GetService to get the DriveService instance
            var service = await GetService();

            // Step 1: Search for existing folder with BranchId
            var listRequest = service.Files.List();
            listRequest.Q = $"mimeType = 'application/vnd.google-apps.folder' and name = '{document.BranchId}' and trashed = false";
            listRequest.Fields = "files(id, name)";
            var listResponse = await listRequest.ExecuteAsync();

            string folderId;
            if (listResponse.Files != null && listResponse.Files.Count > 0)
            {
                // Folder already exists
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
                request.Fields = "id, webViewLink"; // Request the webViewLink in addition to the file ID
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

            // Step 4: Return the file ID and URL
            return (file.Id, file.WebViewLink);
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




    }
}