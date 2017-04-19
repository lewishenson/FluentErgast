namespace FluentErgast.F1.Mappers.DriverStandings
{
    public class ConstructorMapper : IMapper<InternalDtos.DriverStandings.Constructor, Dtos.DriverStandings.Constructor>
    {
        public Dtos.DriverStandings.Constructor Map(InternalDtos.DriverStandings.Constructor input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.DriverStandings.Constructor
            {
                ConstructorId = input.ConstructorId,
                Url = input.Url,
                Name = input.Name,
                Nationality = input.Nationality
            };
        }
    }
}