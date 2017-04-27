using System;
using System.Linq;

namespace FluentErgast.F1.Mappers.ConstructorStandings
{
    public class StandingsTableMapper : IMapper<InternalDtos.ConstructorStandings.StandingsTable, Dtos.ConstructorStandings.StandingsTable>
    {
        private readonly IMapper<InternalDtos.ConstructorStandings.StandingsList, Dtos.ConstructorStandings.StandingsList> standingsListMapper;

        public StandingsTableMapper(IMapper<InternalDtos.ConstructorStandings.StandingsList, Dtos.ConstructorStandings.StandingsList> standingsListMapper)
        {
            this.standingsListMapper = standingsListMapper;
        }

        public Dtos.ConstructorStandings.StandingsTable Map(InternalDtos.ConstructorStandings.StandingsTable input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.ConstructorStandings.StandingsTable
            {
                Season = Convert.ToInt32(input.Season),
                StandingsLists = input.StandingsLists.Select(this.standingsListMapper.Map).ToArray()
            };
        }
    }
}