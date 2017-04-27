using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.ConstructorStandings
{
    public class StandingsList
    {
        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("ConstructorStandings")]
        public ConstructorStanding[] ConstructorStandings { get; set; }
    }
}