using System;

namespace FluentErgast.F1.Mappers.DriverStandings
{
    public class DriverMapper : IMapper<InternalDtos.DriverStandings.Driver, Dtos.DriverStandings.Driver>
    {
        public Dtos.DriverStandings.Driver Map(InternalDtos.DriverStandings.Driver input)
        {
            if (input == null)
            {
                return null;
            }

            return new Dtos.DriverStandings.Driver
            {
                DriverId = input.DriverId,
                PermanentNumber = Convert.ToInt32(input.PermanentNumber),
                Code = input.Code,
                Url = input.Url,
                GivenName = input.GivenName,
                FamilyName = input.FamilyName,
                DateOfBirth = Convert.ToDateTime(input.DateOfBirth),
                Nationality = input.Nationality
            };
        }
    }
}