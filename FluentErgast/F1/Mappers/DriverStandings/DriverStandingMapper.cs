using System;
using System.Linq;

namespace FluentErgast.F1.Mappers.DriverStandings
{
    public class DriverStandingMapper : IMapper<InternalDtos.DriverStandings.DriverStanding, Dtos.DriverStandings.DriverStanding>
    {
        private readonly IMapper<InternalDtos.DriverStandings.Driver, Dtos.DriverStandings.Driver> driverMapper;
        private readonly IMapper<InternalDtos.DriverStandings.Constructor, Dtos.DriverStandings.Constructor> constructorMapper;

        public DriverStandingMapper(IMapper<InternalDtos.DriverStandings.Driver, Dtos.DriverStandings.Driver> driverMapper,
                                    IMapper<InternalDtos.DriverStandings.Constructor, Dtos.DriverStandings.Constructor> constructorMapper)
        {
            this.driverMapper = driverMapper;
            this.constructorMapper = constructorMapper;
        }

        public Dtos.DriverStandings.DriverStanding Map(InternalDtos.DriverStandings.DriverStanding input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.DriverStandings.DriverStanding
            {
                Position = Convert.ToInt32(input.Position),
                PositionText = input.PositionText,
                Points = Convert.ToSingle(input.Points),
                Wins = Convert.ToInt32(input.Wins),
                Driver = this.driverMapper.Map(input.Driver),
                Constructors = input.Constructors.Select(this.constructorMapper.Map).ToArray()
            };
        }
    }
}