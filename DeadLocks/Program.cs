using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DeadLocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object lock1 = new object();
            object lock2 = new object();
            Thread thread = new Thread(() =>
           {
               lock (lock1)
               {
                   Console.WriteLine("Lock1 Obtained in worker Thread");
                  // Thread.Sleep(2000);
                   lock (lock2)
                   {
                       Console.WriteLine("Lock2 Obtained in worker Thread");
                   }
               }
           });
            thread.Start();
            lock (lock2)
            {
                Console.WriteLine("Lock2 Obtained in main Thread");
               // Thread.Sleep(1000);
                lock(lock1)
                {
                    Console.WriteLine("Lock1 Obtained in main Thread");
                }
            }
            //thread.Start();
            Console.ReadKey();
        }
    }
}
