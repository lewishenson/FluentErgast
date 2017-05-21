using System;
using System.Linq;
using System.Threading.Tasks;
using FluentErgast;
using FluentErgast.F1.Dtos.ConstructorStandings;
using FluentErgast.F1.Dtos.DriverStandings;
using ConstructorStandingsTable = FluentErgast.F1.Dtos.ConstructorStandings.StandingsTable;
using DriverStandingsTable = FluentErgast.F1.Dtos.DriverStandings.StandingsTable;

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
            var driverStandings = await Ergast.F1.DriverStandings.ForYearAsync(2009);
            OutputDriverStandings(driverStandings);

            Console.WriteLine();

            var constructorStandings = await Ergast.F1.ConstructorStandings.ForYearAsync(2009);
            OutputConstructorStandings(constructorStandings);
        }

        private static void OutputDriverStandings(DriverStandingsTable standings)
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

            var driverName = $"{driver.Driver.GivenName} {driver.Driver.FamilyName} ({driver.Constructors.Last().Name})";
            Console.Write(driverName.PadRight(35, ' '));

            Console.Write($"{driver.Points} points");

            Console.WriteLine();
        }

        private static void OutputConstructorStandings(ConstructorStandingsTable standings)
        {
            Console.WriteLine($"Formula 1 Constructor Standings ({standings.Season} season)");

            foreach (var standingsList in standings.StandingsLists)
            {
                foreach (var constructorStanding in standingsList.ConstructorStandings)
                {
                    OutputConstructor(constructorStanding);
                }
            }
        }

        private static void OutputConstructor(ConstructorStanding constructor)
        {
            Console.Write($"{constructor.PositionText.PadLeft(2, ' ')} > ");

            Console.Write(constructor.Constructor.Name.PadRight(35, ' '));

            Console.Write($"{constructor.Points} points");

            Console.WriteLine();
        }
    }
}