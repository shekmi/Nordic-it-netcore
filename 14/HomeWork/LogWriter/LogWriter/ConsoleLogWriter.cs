using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        private static ConsoleLogWriter _instanseConsoleLogWriter;
        public static Writer Writer { get; private set; }
        
        private ConsoleLogWriter() : base(Writer)
        { }

        public static ConsoleLogWriter GetInstanseConsoleLogWriter(Writer writer)
        {
            if(_instanseConsoleLogWriter == null)
            {
                Writer = writer;
                _instanseConsoleLogWriter = new ConsoleLogWriter();
            }
            return _instanseConsoleLogWriter;
        }
    }
}
