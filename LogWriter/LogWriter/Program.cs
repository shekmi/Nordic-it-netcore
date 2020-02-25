using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            WriterFile writerFile = new WriterFile(@"./../log/log.txt");

            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter(writer);
            FileLogWriter fileLogWriter = new FileLogWriter(writerFile);

            fileLogWriter.LogError($"{fileLogWriter.GetType()} Log Error");
            fileLogWriter.LogInfo($"{fileLogWriter.GetType()} Log Info");
            fileLogWriter.LogWarning($"{fileLogWriter.GetType()} Log Warning");

            consoleLogWriter.LogError($"{consoleLogWriter.GetType()} Log Error");
            consoleLogWriter.LogInfo($"{consoleLogWriter.GetType()} Log Info");
            consoleLogWriter.LogWarning($"{consoleLogWriter.GetType()} Log Warning");

            MultipleLogWriter multipleLogWriter = new MultipleLogWriter(consoleLogWriter, fileLogWriter);
            multipleLogWriter.LogError($"{multipleLogWriter.GetType()} Log Error");
            multipleLogWriter.LogInfo($"{multipleLogWriter.GetType()} Log Info");
            multipleLogWriter.LogWarning($"{multipleLogWriter.GetType()} Log Warning");
            writerFile.Dispose();
            Console.ReadKey();
        }
    }
}
