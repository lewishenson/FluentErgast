using System.Collections.Generic;

namespace FluentErgast.F1.Dtos.DriverStandings
{
    public class DriverStanding
    {
        public int Position { get; set; }

        public string PositionText { get; set; }

        public float Points { get; set; }

        public int Wins { get; set; }

        public Driver Driver { get; set; }

        public IEnumerable<Constructor> Constructors { get; set; }
    }
}