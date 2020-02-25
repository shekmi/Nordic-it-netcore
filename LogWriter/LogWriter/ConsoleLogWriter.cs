using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        public Writer Writer { get; }
        public ConsoleLogWriter(Writer writer): base(writer)
        {
            Writer = writer;
        }
    }
}
