using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassWork
{
    class LogFileWriterExtended : IDisposable
    {
        public static int Count { get; private set; }

        private readonly StreamWriter _streamWriter;
        public string FileName { get; }
      

        public LogFileWriterExtended(string filePath)
        {
            FileName = filePath;
            _streamWriter = new StreamWriter(
              File.Open(
                  filePath,
                  FileMode.Append,
                  FileAccess.Write,
                  FileShare.None));
            Count++;
        }

        public void WriteLog(string message)
        {

            _streamWriter.WriteLine($"{DateTimeOffset.UtcNow:O}\t{message}");
            _streamWriter.Flush();
            //sw.Close();
        }

        public void Dispose()
        {  
            //if(_streamWriter == null)
            //   _streamWriter.Dispose();
            _streamWriter?.Dispose();
        }

    }
}
