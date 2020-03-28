using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork
{
    //public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes); не нужен, обычно не используется в разработке
    class RandomDataGenerator
    {
        public event EventHandler <RandomDataGeneratedEventArg> RandomDataGenerated;
        public event EventHandler RandomDataGenerationDone;
        public byte[] GetRandomData(int dataSize, int packageSize)
        {            
            byte[] result = new byte[dataSize];
            Random rand = new Random();
            //for (int i = 0; i < dataSize; i++)
            //{
            //    result[i] = (byte)rand.Next(256);
            //}
            //или
            int packageNumber = dataSize / packageSize;
            int elementInLastPackage = dataSize % packageSize;
            for (int i = 0; i < packageNumber; i++)
            {
                byte[] tempByte = new byte[packageNumber];
                rand.NextBytes(tempByte);
                tempByte.CopyTo(result, i * packageSize);
                RandomDataGenerated?.Invoke(
                    this, 
                    new RandomDataGeneratedEventArg((i+1) * packageSize, dataSize));
            }
            if (elementInLastPackage > 0)
            {
                byte[] tempByte = new byte[elementInLastPackage];
                rand.NextBytes(tempByte);
                tempByte.CopyTo(result, dataSize - elementInLastPackage);                
                RandomDataGenerated?.Invoke(
                    this,
                    new RandomDataGeneratedEventArg(elementInLastPackage, dataSize));
            }
            RandomDataGenerationDone?.Invoke(this, EventArgs.Empty);
            return result;
        }
    }
}
