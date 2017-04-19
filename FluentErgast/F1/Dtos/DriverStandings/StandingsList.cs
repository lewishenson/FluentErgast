using System.Collections.Generic;

namespace FluentErgast.F1.Dtos.DriverStandings
{
    public class StandingsList
    {
        public int Season { get; set; }

        public int Round { get; set; }

        public IEnumerable<DriverStanding> DriverStandings { get; set; }
    }
}