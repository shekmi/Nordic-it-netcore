using System;

namespace LogWriter
{
    class Program
    {
        static void Main(string[] args)
        {            
            FileLogWriter fileLogWriter = new FileLogWriter(@"./../log/log1.txt");
            fileLogWriter.LogWarning("Warning Log");
            fileLogWriter.LogError("Error Log");
            fileLogWriter.LogInfo("Info Log");

            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            consoleLogWriter.LogWarning("Warning Log");
            consoleLogWriter.LogError("Error Log");
            consoleLogWriter.LogInfo("Info Log");

            ConsoleLogWriter consoleLogWriter1 = new ConsoleLogWriter();
            FileLogWriter fileLogWriter1 = new FileLogWriter(@"./../log/log2.txt");
            MultipleLogWriter multipleLogWriter = new MultipleLogWriter(consoleLogWriter1, fileLogWriter1);
            multipleLogWriter.LogError("multipleLog Error");
            multipleLogWriter.LogInfo("multipleLog Info");
            multipleLogWriter.LogWarning("multipleLog Warning");
        }
    }
}
