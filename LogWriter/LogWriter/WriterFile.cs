﻿using System;
using System.Text;
using System.IO;

namespace LogWriter
{
    class WriterFile : IWriter, IDisposable
    {
        StreamWriter _streamWriter;
        public WriterFile(string fileName)
        {
            _streamWriter = new StreamWriter(
                File.Open(
                fileName,
                FileMode.Append,
                FileAccess.Write,
                FileShare.Read));
        }

        public void Dispose()
        {
            _streamWriter?.Dispose();
        }

        public void WriteLine(string text)
        {
            _streamWriter.WriteLine(text);
            _streamWriter.Flush();
        }
    }
}
