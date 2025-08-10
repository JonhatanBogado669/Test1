using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace test1
{
    public class FolderSync
    {
        private FileSystemWatcher _watcher;
        private DriveUploader _uploader;
        private string _dbPath;
        private Timer _debounceTimer;
        private const int DebounceDelayMs = 2000;

        public FolderSync(string dbPath, DriveUploader uploader)
        {
            _dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            _uploader = uploader ?? throw new ArgumentNullException(nameof(uploader));

            string folderPath = Path.GetDirectoryName(dbPath);
            string fileName = Path.GetFileName(dbPath);

            _watcher = new FileSystemWatcher(folderPath, fileName)
            {
                NotifyFilter = NotifyFilters.LastWrite
            };

            _watcher.Changed += OnChanged;
            _watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Vigilando cambios en {_dbPath}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Evento Changed detectado para archivo: {e.FullPath}");

            _debounceTimer?.Dispose();
            _debounceTimer = new Timer(async _ =>
            {
                Console.WriteLine("Ejecutando subida tras debounce...");
                try
                {
                    await _uploader.UploadOrUpdateFileAsync(_dbPath);
                    Console.WriteLine("Archivo subido correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en subida a Drive: {ex.Message}");
                }
            }, null, DebounceDelayMs, Timeout.Infinite);
        }
    }
}
