using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace ClassWork
{
    class Program2
    {
        static void Main(string[] args)
        {
            RandomDataGenerator randomDataGenerator = new RandomDataGenerator();
            randomDataGenerator.RandomDataGenerated += RandomDataGenerator_RandomDataGenerated;
            randomDataGenerator.RandomDataGenerationDone += RandomDataGenerator_RandomDataGenerationDone;

            const string sourceFileName = "text_bytes.txt";
            const string zipFileName = "text_bytes.zip";
            const string gzipFileName = "text_bytes.gz";

            byte[] data = randomDataGenerator.GetRandomData(1024 * 1024, 1024 * 1024-1);
            File.WriteAllBytes(sourceFileName, data);

            if (File.Exists(zipFileName))
                File.Delete(zipFileName);

            using var zipFile = ZipFile.Open(zipFileName, ZipArchiveMode.Create);
            zipFile.CreateEntryFromFile(sourceFileName, sourceFileName);

            if (File.Exists(gzipFileName))
                File.Delete(gzipFileName);
            using FileStream zipFileStream = File.Create(gzipFileName);
            using GZipStream zipStream = new GZipStream(zipFileStream, CompressionLevel.Optimal);
            zipStream.Write(data);
        }

        private static void RandomDataGenerator_RandomDataGenerationDone(object sender, EventArgs e)
        {
            Console.WriteLine($"{sender.GetHashCode()} : I'm done!");
        }

        private static void RandomDataGenerator_RandomDataGenerated(object sender, RandomDataGeneratedEventArg e)
        {
            Console.WriteLine($"Generated {e.BytesDone}  from {e.TotalBytes} byte(s)...");
        }
    }
}
