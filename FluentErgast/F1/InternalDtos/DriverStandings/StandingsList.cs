using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.DriverStandings
{
    public class StandingsList
    {
        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("DriverStandings")]
        public DriverStanding[] DriverStandings { get; set; }
    }
}