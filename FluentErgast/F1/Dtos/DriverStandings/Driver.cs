using System;

namespace FluentErgast.F1.Dtos.DriverStandings
{
    public class Driver
    {
        public string DriverId { get; set; }

        public int PermanentNumber { get; set; }

        public string Code { get; set; }

        public string Url { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }
    }
}