using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogWriter
{
    class FileLogWriter: AbstractLogWriter, IDisposable
    {

        private readonly StreamWriter _streamWriter;

        public FileLogWriter(string fileName = "log.txt")
        {
            _streamWriter = new StreamWriter(
            File.Open(
                fileName,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read));
            _streamWriter.BaseStream.Seek(0, SeekOrigin.End);           
        }

        protected override void LogRecordType(string message, MessageType logRecordType)
        {
            _streamWriter?.WriteLine(base.GetLogRecord(message, logRecordType));
            _streamWriter?.Flush();
        }
        public void Dispose()
        {
            _streamWriter?.Dispose();
        }
    }
}
