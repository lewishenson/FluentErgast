using System.Collections.Generic;
using FluentErgast.F1.Dtos.Shared;

namespace FluentErgast.F1.Dtos.ConstructorStandings
{
    public class ConstructorStanding
    {
        public int Position { get; set; }

        public string PositionText { get; set; }

        public float Points { get; set; }

        public int Wins { get; set; }

        public Constructor Constructor { get; set; }
    }
}