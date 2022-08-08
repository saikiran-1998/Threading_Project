using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocksAndMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(10000);
            Task task1 = Task.Factory.StartNew(() => account.withdrawRandomly());
            Task task2 = Task.Factory.StartNew(() => account.withdrawRandomly());
            Task task3 = Task.Factory.StartNew(() => account.withdrawRandomly());
            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("Thank you for banking with us");
            Console.ReadKey();
        }
    }
}
