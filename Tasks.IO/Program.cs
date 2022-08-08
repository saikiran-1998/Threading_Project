
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tasks.IO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<List<Employee>> task = new Task<List<Employee>>(() => GetEmployeeDetails().Result);
            //Task<Employee> task = new Task<Employee>(() => GetEmployeeDetails().Result);
            task.Start();
            Console.WriteLine(task.Result);
            // Employee employee = task.Result;
            foreach (var item in task.Result)
            {
                Console.WriteLine(item.id);
                Console.WriteLine(item.title);
                Console.WriteLine(item.body);
            }
            Console.WriteLine("End of main method");
            // GetEmployeeDetails();
            Console.ReadKey();
        }

        private static async Task<List<Employee>> GetEmployeeDetails()
        // private async static Task<Employee> GetEmployeeDetails()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            string content = await response.Content.ReadAsStringAsync();
            // var returnResponse = JsonConvert.DeserializeObject<List<Employee>>(content).Find(e => e.id == 1);
            var returnResponse = JsonConvert.DeserializeObject<List<Employee>>(content);
            return returnResponse;
        }

    }
}
