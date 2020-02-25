using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter
{
    class MultipleLogWriter : AbstractLogWriter
    {
        private static MultipleLogWriter _instanseMultipleLogWriter;
        protected static ConsoleLogWriter ConsoleLogWriter { get; private set; }
        protected static FileLogWriter FileLogWriter { get; private set; }
       
        private MultipleLogWriter()
            : base(ConsoleLogWriter.Writer, FileLogWriter.WriterFile)
        {  }
        public static MultipleLogWriter GetInstanseMultipleLogWriter(ConsoleLogWriter consoleLog, FileLogWriter fileLog)
        {
            if(_instanseMultipleLogWriter == null)
            {
                ConsoleLogWriter = consoleLog;
                FileLogWriter = fileLog;
                _instanseMultipleLogWriter = new MultipleLogWriter();
            }
            return _instanseMultipleLogWriter;
        }
    }
}
