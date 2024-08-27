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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private const string RefreshToken = " 1//04LsB4Se3Ht5MCgYIARAAGAQSNwF-L9Ir-QDcgpm6Njxe6KBrnD3FhMlF513knluf1Nit6gR1PzluQHfwW9fYXgiRjFm6dgXEe5Y";

        public static DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                RefreshToken = RefreshToken
            };

            var credentials = new UserCredential(
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

            credentials.RefreshTokenAsync(CancellationToken.None).Wait();

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName,
            });
        }

        public static async Task<(string FileId, string FileUrl)> UploadFileAsync(Documents document)
        {
            var service = GetService();

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

            var service = GetService();
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