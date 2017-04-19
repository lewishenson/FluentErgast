using System.Collections.Generic;

namespace FluentErgast.F1.Dtos.DriverStandings
{
    public class StandingsTable
    {
        public int Season { get; set; }

        public IEnumerable<StandingsList> StandingsLists { get; set; }
    }
}