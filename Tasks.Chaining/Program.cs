using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Chaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<string> antecedent = Task.Run(() => DateTime.Now.ToString());
            Task<string> continuation = antecedent.ContinueWith(x => "Current Date and Time is : " + x.Result);
            Console.WriteLine(continuation.Result);


            Task<List<Employee>> antecedent1 = Task.Run(() =>
            {
                return GetEmployeeDetails();
            });
            Task<Employee> continuation1 = antecedent1.ContinueWith(x =>
            {
                return x.Result.Find(e => e.id == 2);
            });
            Console.WriteLine(JsonConvert.SerializeObject(continuation1.Result));
            Console.ReadKey();
        }
        private static async Task<List<Employee>> GetEmployeeDetails()
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
