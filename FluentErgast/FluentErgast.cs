using FluentErgast.F1;
using FluentErgast.F1.Mappers.Shared;
using FluentErgast.Http;

namespace FluentErgast
{
    public static class FluentErgast
    {
        private readonly static IHttpClient HttpClient = new HttpClientWrapper();

        static FluentErgast()
        {
            var constructorMapper = new ConstructorMapper();
            var driverStandings = CreateDriverStandings(constructorMapper);
            var constructorStandings = CreateConstructorStandings(constructorMapper);

            F1 = new F1.F1(driverStandings, constructorStandings);
        }

        public static IF1 F1 { get; set; }

        private static DriverStandings CreateDriverStandings(ConstructorMapper constructorMapper)
        {
            var driverMapper = new F1.Mappers.DriverStandings.DriverMapper();
            var driverStandingMapper = new F1.Mappers.DriverStandings.DriverStandingMapper(driverMapper, constructorMapper);
            var standingsListMapper = new F1.Mappers.DriverStandings.StandingsListMapper(driverStandingMapper);
            var standingsTableMapper = new F1.Mappers.DriverStandings.StandingsTableMapper(standingsListMapper);
            var driverStandings = new DriverStandings(HttpClient, standingsTableMapper);

            return driverStandings;
        }

        private static ConstructorStandings CreateConstructorStandings(ConstructorMapper constructorMapper)
        {
            var constructorStandingMapper = new F1.Mappers.ConstructorStandings.ConstructorStandingMapper(constructorMapper);
            var standingsListMapper = new F1.Mappers.ConstructorStandings.StandingsListMapper(constructorStandingMapper);
            var standingsTableMapper = new F1.Mappers.ConstructorStandings.StandingsTableMapper(standingsListMapper);
            var constructorStandings = new ConstructorStandings(HttpClient, standingsTableMapper);

            return constructorStandings;
        }
    }
}