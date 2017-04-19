using FluentErgast.F1;
using FluentErgast.F1.Mappers.DriverStandings;
using FluentErgast.Http;

namespace FluentErgast
{
    public static class FluentErgast
    {
        private readonly static IHttpClient HttpClient = new HttpClientWrapper();

        static FluentErgast()
        {
            var driverMapper = new DriverMapper();
            var constructorMapper = new ConstructorMapper();
            var driverStandingMapper = new DriverStandingMapper(driverMapper, constructorMapper);
            var standingsListMapper = new StandingsListMapper(driverStandingMapper);
            var standingsTableMapper = new StandingsTableMapper(standingsListMapper);
            var driverStandings = new DriverStandings(HttpClient, standingsTableMapper);
            F1 = new F1.F1(driverStandings);
        }

        public static IF1 F1 { get; set; }
    }
}