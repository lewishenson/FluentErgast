using System.Collections.Generic;

namespace FluentErgast.F1.Dtos.ConstructorStandings
{
    public class StandingsList
    {
        public int Season { get; set; }

        public int Round { get; set; }

        public IEnumerable<ConstructorStanding> ConstructorStandings { get; set; }
    }
}