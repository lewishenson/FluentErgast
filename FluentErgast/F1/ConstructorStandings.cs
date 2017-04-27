using System;
using System.Threading.Tasks;
using FluentErgast.F1.Dtos.ConstructorStandings;
using FluentErgast.F1.Mappers;
using FluentErgast.Http;

namespace FluentErgast.F1
{
    public class ConstructorStandings : IConstructorStandings
    {
        private readonly IHttpClient httpClient;
        private readonly IMapper<InternalDtos.ConstructorStandings.StandingsTable, Dtos.ConstructorStandings.StandingsTable> standingsTableMapper;
        private int? round;

        public ConstructorStandings(IHttpClient httpClient, IMapper<InternalDtos.ConstructorStandings.StandingsTable, Dtos.ConstructorStandings.StandingsTable> standingsTableMapper)
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

        public IGetConstructorStandings ForRound(int round)
        {
            this.round = round;

            return this;
        }

        private string GenerateUri(int year)
        {
            return this.round.HasValue
                    ? $"http://ergast.com/api/f1/{year}/{this.round}/constructorStandings.json"
                    : $"http://ergast.com/api/f1/{year}/constructorStandings.json";
        }

        private async Task<StandingsTable> Get(string uri)
        {
            var response = await this.httpClient.GetAsync<InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>>(uri);
            var standingsTable = this.standingsTableMapper.Map(response.MRData.StandingsTable);

            return standingsTable;
        }
    }
}