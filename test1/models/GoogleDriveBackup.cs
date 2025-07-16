using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test1.models
{
    public class GoogleDriveBackup
    {
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };
        private static readonly string ApplicationName = "BomberoDB Backup";
        private DriveService _driveService;

        public GoogleDriveBackup()
        {
            InitializeDriveService();
        }

        private void InitializeDriveService()
        {
            try
            {
                // Lee las credenciales desde variables de entorno
                string clientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
                string clientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret
                    },
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("token.json", true)).Result;

                _driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar Google Drive: {ex.Message}");
            }
        }

        // Método BackupDatabaseAsync() sigue igual que antes...
    }
}