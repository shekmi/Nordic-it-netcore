using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter
{
    class MultipleLogWriter : AbstractLogWriter
    {
        public MultipleLogWriter(ConsoleLogWriter consoleLog, FileLogWriter fileLog)
            :base(consoleLog.Writer, fileLog.WriterFile)            
        {
           
        }

     
    }
}
