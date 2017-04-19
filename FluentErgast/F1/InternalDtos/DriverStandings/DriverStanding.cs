using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.DriverStandings
{
    public class DriverStanding
    {
        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        [JsonProperty("points")]
        public string Points { get; set; }

        [JsonProperty("wins")]
        public string Wins { get; set; }

        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        [JsonProperty("Constructors")]
        public Constructor[] Constructors { get; set; }
    }
}