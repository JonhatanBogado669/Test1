using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace test1
{
    public class DriveUploader
    {
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "test1";

        private DriveService service;

        public DriveUploader()
        {
            Initialize();
        }

        private async Task Initialize()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }

            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public async Task UploadFile(string filePath)
        {
            if (service == null)
                await Initialize();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Archivo no encontrado: " + filePath);
                return; // Salimos si el archivo no existe
            }

            if (service == null)
                await Initialize();

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath)
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";
                await request.UploadAsync();
            }

            var file = request.ResponseBody;
            Console.WriteLine("Archivo subido. ID: " + file.Id);
        }

    }
}
