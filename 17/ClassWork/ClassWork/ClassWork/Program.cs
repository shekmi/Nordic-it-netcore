using System;

namespace ClassWork
{
   
    delegate void WorkPerformedEventHandler(int hours, WorkType workType);
    delegate int DoCalculation(int x, int y);

    class Program
    {
        static void Main_old(string[] args)
        {
            DoCalculation doCalculation1 = SimpleCalculater.Sum;
            DoCalculation doCalculation2 = SimpleCalculater.Multiply;

            doCalculation1 += doCalculation2;
            doCalculation1 = (DoCalculation)Delegate.Combine(doCalculation1, doCalculation2);
            var multipleResult = doCalculation1(3, 4);
            Console.WriteLine($"{nameof(multipleResult)} = {multipleResult}");

            var delegate1 = new WorkPerformedEventHandler(WorkPerformed1);
            var delegate2 = new WorkPerformedEventHandler(WorkPerformed2);
            var delegate3 = new WorkPerformedEventHandler(WorkPerformed3);

            delegate1 += delegate2;
            delegate1 += delegate3;
            delegate1(5, WorkType.DoNothing);
            Console.WriteLine($"{nameof(delegate1)} = {delegate1}");
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"[{nameof(WorkPerformed1)}] Work of type {workType} : {hours} hours");
        }
        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine($"[{nameof(WorkPerformed2)}] Work of type {workType} : {hours} hours");
        }
        static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine($"[{nameof(WorkPerformed3)}] Work of type {workType} : {hours} hours");
        }
    }
}
