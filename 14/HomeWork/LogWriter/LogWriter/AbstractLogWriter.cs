using System;
using System.Text;

namespace LogWriter
{
    public enum MessageType
    {
        Info,
        Warning,
        Error
    }
   
    abstract class AbstractLogWriter: ILogWriter
    {
        readonly IWriter _writerAny;
        readonly IWriter _writerFile;
        public AbstractLogWriter(Writer writer)
        {
            _writerAny = writer;
        }       
        public AbstractLogWriter(WriterFile writerFile)
        {
            _writerAny = writerFile;
        }

        public AbstractLogWriter(Writer writer, WriterFile writerFile)
        {
            _writerAny = writer;
            _writerFile = writerFile;
        }
        public void LogError(string message)
        {
            _writerAny.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-dd:thh:mm:ss+0000")}\t{MessageType.Error}\t{message}");
            _writerFile?.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-dd:thh:mm:ss+0000")}\t{MessageType.Error}\t{message}");
        }

        public void LogInfo(string message)
        {
            _writerAny.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-dd:thh:mm:ss+0000")}\t{MessageType.Info}\t{message}");
            _writerFile?.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-dd:thh:mm:ss+0000")}\t{MessageType.Info}\t{message}");
        }

        public void LogWarning(string message)
        {
            _writerAny.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-dd:thh:mm:ss+0000")}\t{MessageType.Warning}\t{message}");
            _writerFile?.WriteLine($"{DateTimeOffset.Now.ToString("yyyy-MM-dd:thh:mm:ss+0000")}\t{MessageType.Warning}\t{message}");
        }
    }
}
