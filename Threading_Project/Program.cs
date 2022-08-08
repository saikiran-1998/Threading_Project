using System;
using System.Threading;

namespace Threading_Project
{
    public class Program
    {
        //below variable "isclosed" is a shared resource
        private static bool isclosed;
        static readonly Object lockCompleted = new Object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(JoinDemo);
            thread1.Start();
            //thread1.IsBackground = true;
            //join and sleep will block the execution until the sleep time completes
            thread1.Join();
            Console.WriteLine("Hello World in main method");

            Thread thread = new Thread(PrintHelloWorld);
            //naming the worker thread
            thread.Name = "sampleThread";
            //worker thread
            thread.Start();

            //naming the worker thread
            Thread.CurrentThread.Name = "Sample Main";
            //main thread
            PrintHelloWorld();
            // Example of each thread having  Local memory
            new Thread(PrintThirtyNumbers).Start();
            PrintThirtyNumbers();
            Console.ReadKey();
        }

        private static void JoinDemo()
        {
            Console.WriteLine("Hello world");
            Thread.Sleep(1000);
        }

        private static void PrintThirtyNumbers()
        {
            for (int i = 1; i < 31; i++)
            {
                Console.Write(Thread.CurrentThread.Name + " " + (i) + " ");
                //Console.Write((i++) + " ");
            }
        }

        private static void PrintHelloWorld()
        {
            lock (lockCompleted)
            {
                if (!isclosed)
                {
                    isclosed = true;
                    Console.WriteLine("Print Hello world only once");
                }
            }
        }

    }
}
