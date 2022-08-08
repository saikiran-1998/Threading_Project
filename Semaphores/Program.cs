using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphores
{
    internal class Program
    {
        //semaphoreslim takes the count of thread that can access the resources
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
        static void Main(string[] args)
        {
            for (int i = 1; i < 11; i++)
            {
                new Thread(AcquireSemaphore).Start(i);
            }
        }

        private static void AcquireSemaphore(object i)
        {
            Console.WriteLine(i + " waiting to access the resource");
            semaphoreSlim.Wait();
            Console.WriteLine(i + " accesses the resource");
            Thread.Sleep(1000);
            Console.WriteLine(i + " Left the resource");
        }
    }
}
