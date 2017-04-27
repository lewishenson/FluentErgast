using FluentErgast.F1.InternalDtos.Shared;
using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.ConstructorStandings
{
    public class ConstructorStanding
    {
        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        [JsonProperty("points")]
        public string Points { get; set; }

        [JsonProperty("wins")]
        public string Wins { get; set; }

        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }
    }
}