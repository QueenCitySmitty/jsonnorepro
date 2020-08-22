using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(@"https://jsonplaceholder.typicode.com/posts/42");
            var dynamicTest = await result.Content.ReadFromJsonAsync<dynamic>();
            var typeTest = dynamicTest.GetType();

            result = await client.GetAsync(@"https://jsonplaceholder.typicode.com/posts/42");
            var modelTest = await result.Content.ReadFromJsonAsync<Model>();
            typeTest = modelTest.GetType();
        }
    }

    public class Model
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
