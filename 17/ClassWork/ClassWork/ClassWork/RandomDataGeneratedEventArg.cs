using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork
{
    public class RandomDataGeneratedEventArg : EventArgs
    {
        public int BytesDone { get; set; }
        public int TotalBytes { get; set; }

        public RandomDataGeneratedEventArg(int bytesDone, int totalBytes)
        {
            BytesDone = bytesDone;
            TotalBytes = totalBytes;
        }
    }
}
