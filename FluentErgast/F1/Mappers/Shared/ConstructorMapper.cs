namespace FluentErgast.F1.Mappers.Shared
{
    public class ConstructorMapper : IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor>
    {
        public Dtos.Shared.Constructor Map(InternalDtos.Shared.Constructor input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.Shared.Constructor
            {
                ConstructorId = input.ConstructorId,
                Url = input.Url,
                Name = input.Name,
                Nationality = input.Nationality
            };
        }
    }
}