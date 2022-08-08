using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks.Introduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(Demo);
            task1.Start();
            Task<string> task2 = new Task<string>(ReturnMethod);
            task2.Start();
            Console.WriteLine("End of method 1");
            //task2.Wait();
            Console.WriteLine("End of method 2");
            //task.Result will wait till the result is calculated in called method like wait() method
            Console.WriteLine(task2.Result);
            Console.WriteLine("End of main method");
            Console.ReadKey();
        }
        private static void Demo()
        {
            Console.WriteLine("This is task which doesnt return value");
        }
        private static string ReturnMethod()
        {
            Thread.Sleep(5000);
            Console.WriteLine("this is return method");
            return "This is task that return values";
        }
    }
}
