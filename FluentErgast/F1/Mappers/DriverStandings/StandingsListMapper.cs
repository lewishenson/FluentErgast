using System;
using System.Linq;

namespace FluentErgast.F1.Mappers.DriverStandings
{
    public class StandingsListMapper : IMapper<InternalDtos.DriverStandings.StandingsList, Dtos.DriverStandings.StandingsList>
    {
        private readonly IMapper<InternalDtos.DriverStandings.DriverStanding, Dtos.DriverStandings.DriverStanding> driverStandingMapper;

        public StandingsListMapper(IMapper<InternalDtos.DriverStandings.DriverStanding, Dtos.DriverStandings.DriverStanding> driverStandingMapper)
        {
            this.driverStandingMapper = driverStandingMapper;
        }

        public Dtos.DriverStandings.StandingsList Map(InternalDtos.DriverStandings.StandingsList input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.DriverStandings.StandingsList
            {
                Season = Convert.ToInt32(input.Season),
                Round = Convert.ToInt32(input.Round),
                DriverStandings = input.DriverStandings.Select(this.driverStandingMapper.Map).ToArray()
            };
        }
    }
}