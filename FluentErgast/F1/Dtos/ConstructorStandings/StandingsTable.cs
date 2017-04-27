using System.Collections.Generic;

namespace FluentErgast.F1.Dtos.ConstructorStandings
{
    public class StandingsTable
    {
        public int Season { get; set; }

        public IEnumerable<StandingsList> StandingsLists { get; set; }
    }
}