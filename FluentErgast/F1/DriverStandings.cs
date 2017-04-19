using System;
using System.Threading.Tasks;
using FluentErgast.F1.Dtos.DriverStandings;
using FluentErgast.F1.Mappers;
using FluentErgast.Http;

namespace FluentErgast.F1
{
    public class DriverStandings : IDriverStandings
    {
        private readonly IHttpClient httpClient;
        private readonly IMapper<InternalDtos.DriverStandings.StandingsTable, Dtos.DriverStandings.StandingsTable> standingsTableMapper;
        private int? round;

        public DriverStandings(IHttpClient httpClient, IMapper<InternalDtos.DriverStandings.StandingsTable, Dtos.DriverStandings.StandingsTable> standingsTableMapper)
        {
            this.httpClient = httpClient;
            this.standingsTableMapper = standingsTableMapper;
        }

        public Task<StandingsTable> ForCurrentYearAsync()
        {
            var currentYear = DateTime.Now.Year;

            return this.ForYearAsync(currentYear);
        }

        public Task<StandingsTable> ForYearAsync(int year)
        {
            var uri = this.GenerateUri(year);

            return this.Get(uri);
        }

        public IGetDriverStandings ForRound(int round)
        {
            this.round = round;

            return this;
        }

        private string GenerateUri(int year)
        {
            return this.round.HasValue
                    ? $"http://ergast.com/api/f1/{year}/{this.round}/driverStandings.json"
                    : $"http://ergast.com/api/f1/{year}/driverStandings.json";
        }

        private async Task<StandingsTable> Get(string uri)
        {
            var response = await this.httpClient.GetAsync<InternalDtos.DriverStandings.Response>(uri);
            var standingsTable = this.standingsTableMapper.Map(response.MRData.StandingsTable);

            return standingsTable;
        }
    }
}