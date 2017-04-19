using System;
using System.Linq;

namespace FluentErgast.F1.Mappers.DriverStandings
{
    public class StandingsTableMapper : IMapper<InternalDtos.DriverStandings.StandingsTable, Dtos.DriverStandings.StandingsTable>
    {
        private readonly IMapper<InternalDtos.DriverStandings.StandingsList, Dtos.DriverStandings.StandingsList> standingsListMapper;

        public StandingsTableMapper(IMapper<InternalDtos.DriverStandings.StandingsList, Dtos.DriverStandings.StandingsList> standingsListMapper)
        {
            this.standingsListMapper = standingsListMapper;
        }

        public Dtos.DriverStandings.StandingsTable Map(InternalDtos.DriverStandings.StandingsTable input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.DriverStandings.StandingsTable
            {
                Season = Convert.ToInt32(input.Season),
                StandingsLists = input.StandingsLists.Select(this.standingsListMapper.Map).ToArray()
            };
        }
    }
}