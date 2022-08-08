using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MutexLock
{
    internal class Program
    {
        static Mutex mutex= new Mutex();
        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                Thread thread = new Thread(AcquireMutex);
                thread.Name = "Thread" + i;
                thread.Start();
            }
            Console.ReadKey();
        }

        private static void AcquireMutex()
        {
            mutex.WaitOne();
            Sample();
            mutex.ReleaseMutex();
            Console.WriteLine("Mutex is released by {0}",Thread.CurrentThread.Name);
        }

        private static void Sample()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Mutex is aquired by {0}", Thread.CurrentThread.Name);
        }
    }
}
