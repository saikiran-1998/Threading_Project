using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReaderWriterLocks
{
    internal class Program
    {
        static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        static Dictionary<int, string> employee = new Dictionary<int, string>();
        static Random random = new Random();
        static void Main(string[] args)
        {
            Task task1 = Task.Factory.StartNew(Read);
            Task task2 = Task.Factory.StartNew(() => Write("sai"));
            Task task3 = Task.Factory.StartNew(() => Write("kiran"));
            Task task4 = Task.Factory.StartNew(Read);
            Task task5 = Task.Factory.StartNew(Read);
            Task.WaitAll(task1, task2, task3, task4, task5);
            Console.ReadKey();
        }
        public static void Read()
        {
            for (int i = 0; i < 10; i++)
            {
                readerWriterLockSlim.EnterReadLock();
                Thread.Sleep(100);
                readerWriterLockSlim.ExitReadLock();
            }
        }

        public static void Write(string name)
        {
            for (int i = 1; i < 10; i++)
            {
                int id = GetRandom();
                readerWriterLockSlim.EnterWriteLock();
                employee.Add(id, "Employee" + i);
                readerWriterLockSlim.ExitWriteLock();
                Console.WriteLine(name + " added " + "Employee" + i);
                Thread.Sleep(100);
            }
        }
        public static int GetRandom()
        {
           // lock (random)
            {
                return random.Next(50000, 60000);
            }
        }
    }
}
