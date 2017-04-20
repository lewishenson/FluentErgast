using System;
using System.Linq;
using System.Threading.Tasks;
using FluentErgast.F1.Dtos.DriverStandings;

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
            var standings = await FluentErgast.F1.DriverStandings.ForYearAsync(2009);

            OutputStandings(standings);
        }

        private static void OutputStandings(StandingsTable standings)
        {
            Console.WriteLine($"Formula 1 Driver Standings ({standings.Season} season)");

            foreach (var standingsList in standings.StandingsLists)
            {
                foreach (var driverStanding in standingsList.DriverStandings)
                {
                    OutputDriver(driverStanding);
                }
            }
        }

        private static void OutputDriver(DriverStanding driver)
        {
            Console.Write($"{driver.PositionText.PadLeft(2, ' ')} > ");

            var driverName = $"{driver.Driver.GivenName} {driver.Driver.FamilyName} ({driver.Constructors.Last().Name})";                Console.Write(driverName.PadRight(35, ' '));

            Console.Write($"{driver.Points} points");

            Console.WriteLine();
        }
    }
}