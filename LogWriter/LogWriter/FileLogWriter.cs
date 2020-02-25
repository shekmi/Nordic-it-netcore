using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogWriter
{
    class FileLogWriter : AbstractLogWriter
    {
        public WriterFile WriterFile { get; }
        public FileLogWriter(WriterFile writerFile) : base(writerFile)
        {
            WriterFile = writerFile;
        }
    }
}
