using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FluentErgast.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            var standings = await FluentErgast.F1.DriverStandings.ForRound(5).ForYearAsync(2009);

            var json = JsonConvert.SerializeObject(standings);

            Console.WriteLine(json);
        }
    }
}