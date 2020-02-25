using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogWriter
{
    class FileLogWriter : AbstractLogWriter
    {
        private static FileLogWriter _instanceFileLogWriter;
        public static WriterFile WriterFile { get; private set; }

        private FileLogWriter() : base(WriterFile)
        { }

        public static FileLogWriter GetInstanceFileLogWriter(WriterFile writerFile)
        {
            if(_instanceFileLogWriter == null)
            {
                WriterFile = writerFile;
                _instanceFileLogWriter = new FileLogWriter();                
            }
            return _instanceFileLogWriter;
        }
    }
}
