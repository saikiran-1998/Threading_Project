using System;
using System.Threading;

namespace ThreaPool_Project
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //to know weather thread belongs to threadpool
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

           // var processorCount = Environment.ProcessorCount;

            int workerThreads = 0;
            int completionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);

            Employee employee1 = new Employee();
            employee1.EmployeeId = 614809;
            employee1.EmployeeName = "Saikiran";
            employee1.CompanyName = "EPAM Systems";
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayFirstEmployeeDetails), employee1);

            // Task.Delay(5000);
            Employee employee2 = new Employee();
            employee2.EmployeeId = 614810;
            employee2.EmployeeName = "Vamsi";
            employee2.CompanyName = "EPAM Systems";
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplaySecondEmployeeDetails), employee2);

            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            Console.ReadKey();
        }

        private static void DisplaySecondEmployeeDetails(object employee)
        {
            Console.WriteLine("Second Thread in pool {0}",Thread.CurrentThread.IsThreadPoolThread);
            Employee emp = employee as Employee;
            Console.WriteLine("Employee Id is {0}", emp.EmployeeId);
            Console.WriteLine("Employee Name is {0}", emp.EmployeeName);
            Console.WriteLine("Company Name is {0}", emp.CompanyName);
        }

        private static void DisplayFirstEmployeeDetails(object employee)
        {
            Console.WriteLine("First Thread in pool {0}", Thread.CurrentThread.IsThreadPoolThread);
            Employee emp = employee as Employee;
            Console.WriteLine("Employee Id is {0}", emp.EmployeeId);
            Console.WriteLine("Employee Name is {0}", emp.EmployeeName);
            Console.WriteLine("Company Name is {0}", emp.CompanyName);
        }
    }
}
