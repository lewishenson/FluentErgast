using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.ConstructorStandings
{
    public class StandingsTable
    {
        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("StandingsLists")]
        public StandingsList[] StandingsLists { get; set; }
    }
}