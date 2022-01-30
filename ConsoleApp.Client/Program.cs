using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp.Client
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class Page
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }
        public Support support { get; set; }
    }

    public sealed class PostUser
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var http = new HttpClient())
            {
                var postUser = new PostUser()
                {
                    Name = "Vlad",
                    Job = "software engineer"
                };
                
                string serializedPostUser = JsonConvert.SerializeObject(postUser);

                var postResponse = http.PostAsync(
                    "https://reqres.in/api/users",
                    new StringContent(
                        serializedPostUser,
                        Encoding.UTF8,
                        "application/json"))
                    .GetAwaiter().GetResult();

                Console.WriteLine(postResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                var result = http.GetAsync("https://reqres.in/api/users?page=2").GetAwaiter().GetResult();

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Not Fount");
                }
                
                Console.WriteLine(result.StatusCode);
                string data = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Page p = JsonConvert.DeserializeObject<Page>(data);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
