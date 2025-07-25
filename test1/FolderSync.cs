using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace test1
{
    public class FolderSync
    {
        private FileSystemWatcher watcher;
        private DriveUploader uploader;

        public FolderSync(string folderPath)
        {
            try
            {
                uploader = new DriveUploader();

                watcher = new FileSystemWatcher(folderPath);
                watcher.IncludeSubdirectories = false;
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
                watcher.Created += async (s, e) =>
                {
                    if (Path.GetFileName(e.FullPath).Equals("bomberoDB.db", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Archivo creado: " + e.FullPath);
                        await uploader.UploadFile(e.FullPath);
                    }
                };

                watcher.Changed += async (s, e) =>
                {
                    if (Path.GetFileName(e.FullPath).Equals("bomberoDB.db", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Archivo cambiado: " + e.FullPath);
                        await uploader.UploadFile(e.FullPath);
                    }
                };

                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
