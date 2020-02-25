using System;
using System.Text;
using System.IO;

namespace LogWriter
{
    class Writer: IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
