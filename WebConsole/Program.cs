using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            var httpClient = new HttpClient(handler, true);
            var stringResponse = await httpClient.GetStringAsync("http://localhost:5000/user");


            var lastTrade = JsonConvert.DeserializeObject<Entity>(stringResponse);

            Console.WriteLine($"Сумма сделки {lastTrade.price}\n" +
                $"Дата сделки: {lastTrade.time.ToLocalTime()}");

            Console.ReadLine();
        }
    }
}
