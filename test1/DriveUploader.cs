using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace test1
{
    public class DriveUploader
    {
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };
        private const string ApplicationName = "BomberoDB Backup";

        private DriveService _service;
        private string _fileId;

        public async Task InitializeAsync(string credentialsPath, string tokenPath)
        {
            try
            {
                if (!File.Exists(credentialsPath))
                    throw new FileNotFoundException("Archivo de credenciales no encontrado.", credentialsPath);

                UserCredential credential;
                using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(tokenPath, true));
                }

                _service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                Console.WriteLine("DriveUploader inicializado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar DriveUploader: {ex.Message}");
                throw;
            }
        }

        public async Task UploadOrUpdateFileAsync(string filePath)
        {
            int retries = 3;
            int delayMs = 1000;

            for (int attempt = 1; attempt <= retries; attempt++)
            {
                try
                {
                    if (_service == null)
                        throw new InvalidOperationException("El servicio de Drive no está inicializado.");

                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine("Archivo para subir no encontrado: " + filePath);
                        return;
                    }

                    var fileName = Path.GetFileName(filePath);

                    if (string.IsNullOrEmpty(_fileId))
                    {
                        var listRequest = _service.Files.List();
                        listRequest.Q = $"name = '{fileName.Replace("'", "\\'")}' and trashed = false";
                        listRequest.Fields = "files(id, name)";
                        var result = await listRequest.ExecuteAsync();
                        var file = result.Files.FirstOrDefault();
                        if (file != null)
                            _fileId = file.Id;
                    }

                    // Abrir archivo con permisos de lectura aunque esté en uso
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        if (string.IsNullOrEmpty(_fileId))
                        {
                            var fileMetadata = new Google.Apis.Drive.v3.Data.File() { Name = fileName };
                            var createRequest = _service.Files.Create(fileMetadata, stream, "application/x-sqlite3");
                            createRequest.Fields = "id";
                            await createRequest.UploadAsync();
                            _fileId = createRequest.ResponseBody.Id;
                            Console.WriteLine($"Archivo creado en Drive con ID: {_fileId}");
                        }
                        else
                        {
                            var updateRequest = _service.Files.Update(new Google.Apis.Drive.v3.Data.File(), _fileId, stream, "application/x-sqlite3");
                            await updateRequest.UploadAsync();
                            Console.WriteLine($"Archivo actualizado en Drive con ID: {_fileId}");
                        }
                    }

                    break; // salió bien, no reintentar
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Intento {attempt} falló por IOException: {ioEx.Message}");
                    if (attempt == retries)
                        Console.WriteLine("No se pudo subir el archivo tras varios intentos.");
                    else
                        await Task.Delay(delayMs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al subir archivo a Drive: {ex.Message}");
                    break; // otro error, no reintentar
                }
            }
        }
    }
}