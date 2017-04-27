using System;
using System.Linq;

namespace FluentErgast.F1.Mappers.ConstructorStandings
{
    public class ConstructorStandingMapper : IMapper<InternalDtos.ConstructorStandings.ConstructorStanding, Dtos.ConstructorStandings.ConstructorStanding>
    {
        private readonly IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor> constructorMapper;

        public ConstructorStandingMapper(IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor> constructorMapper)
        {
            this.constructorMapper = constructorMapper;
        }

        public Dtos.ConstructorStandings.ConstructorStanding Map(InternalDtos.ConstructorStandings.ConstructorStanding input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.ConstructorStandings.ConstructorStanding
            {
                Position = Convert.ToInt32(input.Position),
                PositionText = input.PositionText,
                Points = Convert.ToSingle(input.Points),
                Wins = Convert.ToInt32(input.Wins),
                Constructor = this.constructorMapper.Map(input.Constructor)
            };
        }
    }
}