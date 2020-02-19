using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassWork
{
    class LogFileWriter
    {
        public static int Count { get; private set; }
        public string FileName { get; }      

        public LogFileWriter(string filePath)
        {
            FileName = filePath;
            Count++;
        }

        public void WriteLog(string message)
        {
            var sw = new StreamWriter(
                File.Open(
                    FileName,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.Read));
            
            sw.WriteLine($"{DateTimeOffset.UtcNow:O}\t{message}");
            
            //sw.Flush();            
            sw.Close();
        }
    }
}
