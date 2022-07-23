using System.Net.Sockets;
using System.Text;

namespace Http.Example
{
    using System.Net;
    using Newtonsoft.Json;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Http.Example");
            await GooglePageExampleAsync();
            //await ReqresModelsExampleAsync();
            //await ReqresPostExampleAsync();
        }

        public static async Task GooglePageExampleAsync()
        {
            using var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync("https://www.google.com/");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Ok Code from google.com");
                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        public static async Task ReqresModelsExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");

            HttpResponseMessage result = await client.GetAsync("api/users?page=2");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Ok Code from reqres");
                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                ReqresPage page = JsonConvert.DeserializeObject<ReqresPage>(content);

                if (page is not null)
                {
                    Console.WriteLine(page.ToString());
                }
            }
        }

        public static async Task ReqresPostExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/");
            CreateUserParameters userParameters = new CreateUserParameters
            {
                Name = "Vlad",
                Job = "Software Engineer"
            };

            string serializedUser =  JsonConvert.SerializeObject(userParameters);
            StringContent stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json"); // application/json - обязательно

            HttpResponseMessage result = await client.PostAsync("api/users", stringContent);
            
            if (result.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("StatusCode Created");

                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                User user = JsonConvert.DeserializeObject<User>(content);
                Console.WriteLine(user!.Name);
            }
        }
    }
}