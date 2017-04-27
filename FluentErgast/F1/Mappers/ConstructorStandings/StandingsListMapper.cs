using System;
using System.Linq;

namespace FluentErgast.F1.Mappers.ConstructorStandings
{
    public class StandingsListMapper : IMapper<InternalDtos.ConstructorStandings.StandingsList, Dtos.ConstructorStandings.StandingsList>
    {
        private readonly IMapper<InternalDtos.ConstructorStandings.ConstructorStanding, Dtos.ConstructorStandings.ConstructorStanding> constructorStandingMapper;

        public StandingsListMapper(IMapper<InternalDtos.ConstructorStandings.ConstructorStanding, Dtos.ConstructorStandings.ConstructorStanding> constructorStandingMapper)
        {
            this.constructorStandingMapper = constructorStandingMapper;
        }

        public Dtos.ConstructorStandings.StandingsList Map(InternalDtos.ConstructorStandings.StandingsList input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.ConstructorStandings.StandingsList
            {
                Season = Convert.ToInt32(input.Season),
                Round = Convert.ToInt32(input.Round),
                ConstructorStandings = input.ConstructorStandings.Select(this.constructorStandingMapper.Map).ToArray()
            };
        }
    }
}