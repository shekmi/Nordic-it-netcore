using System;
using System.IO;

namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string filePath = @"./../log/log.txt";

            //Console.WriteLine(Path.GetDirectoryName(filePath));
            //Console.WriteLine(File.Exists(filePath));
            //Console.WriteLine(Path.Combine(@"C"));


            //LogFileWriter logger1 = new LogFileWriter(@"./../log/log1.txt");
            //logger1.WriteLog(Path.GetFullPath(logger1.FileName));

            //LogFileWriterExtended logger2 = new LogFileWriterExtended(@"./../log/log2.txt");
            //logger2.WriteLog(Path.GetFullPath(logger2.FileName));
            //logger2.Dispose();

            //using (var logger3 = new LogFileWriterExtended(@"./../log/log3.txt"))
            //{
            //    logger3.WriteLog(Path.GetFullPath(logger2.FileName));
            //    logger3.Dispose();
            //}

            using (ErrorList errorList = new ErrorList("System Error"))
            {
                errorList.Add("System Error1");
                ErrorList.OutputPrefixformat = "dd-MM-yyyy hh:mm:ss.ffffff";
                errorList.Add("System Error2");
                foreach (var item in errorList)
                {
                    Console.WriteLine($"{errorList.Category} : {item}");
                }
            }

            //Calculate calculate = new Calculate();

            Console.WriteLine(Calculate.Add(7, 12));
            Console.WriteLine(Calculate.Multiply(7, 12));
        }
    }
}
