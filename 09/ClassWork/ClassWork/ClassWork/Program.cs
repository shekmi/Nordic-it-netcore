using System;
using System.Diagnostics;

namespace ClassWork
{
    class Program
    {
        static int [] GetInitialArray(int length, int maxValue)
        {
            var arr = new int[length];
            var rnd = new Random();
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(maxValue);
            }
            return arr;
        }
        static void Print(int[] arr, string arrayName)
        {
            Console.WriteLine(arrayName + ":");
            //for (var i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
        }

        static int [] GetBubbleSortedArray(int[] arr)
        {
            int[] array = (int[])(arr.Clone()); 
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                        //arr[i] = arr[i] ^ arr[i + 1];
                        //arr[i + 1] = arr[i + 1] ^ arr[i];
                        //arr[i] = arr[i] ^ arr[i + 1];
                    }
                }
            }
            return array;
        }

        static int[] GetNetCoreGetBubbleSortedArray(int[] arr)
        {
            int[] array = (int[])(arr.Clone());
            Array.Sort(array);
            return array;
        }

        static void Main(string[] args)
        {
            const int length = 50000;
            const int maxValue = 1000000;
            int[] arr = GetInitialArray(length, maxValue);
            Print(arr, "Initial array");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int[] bubbleArr = GetBubbleSortedArray(arr);
            timer.Stop();
            Print(bubbleArr, $"Sorted array {timer.ElapsedMilliseconds} ms");

            timer.Restart();
            int[] netCoreArray = GetNetCoreGetBubbleSortedArray(arr);
            timer.Stop();
            Print(netCoreArray, $"Sort C# {timer.ElapsedMilliseconds} ms");
        }
    }
}
