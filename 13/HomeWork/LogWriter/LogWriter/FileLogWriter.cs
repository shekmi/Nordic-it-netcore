using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogWriter
{
    class FileLogWriter: ILogWriter, IDisposable
    {
        private readonly StreamWriter _streamWriter;
        public string FileName { get; }
        public FileLogWriter(string filePath)
        {
            FileName = filePath;
            try
            {
                _streamWriter = new StreamWriter(
                File.Open(
                    filePath,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.Read));
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Создайте необходимую директорию");                
            }           
        }

        public void LogInfo(string message)
        {
            _streamWriter?.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss+0000")} {MessageType.Info} {message}");
            _streamWriter?.Flush();
        }

        public void LogWarning(string message)
        {
            _streamWriter?.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss+0000")} {MessageType.Warning} {message}");
            _streamWriter?.Flush();
        }

        public void LogError(string message)
        {
            _streamWriter?.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss+0000")} {MessageType.Error} {message}");
            _streamWriter?.Flush();
        }

        public void Dispose()
        {
            _streamWriter?.Dispose();
        }
    }
}
