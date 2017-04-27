using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.ConstructorStandings
{
    public class MRData : MRDataBase
    {
        [JsonProperty("StandingsTable")]
        public StandingsTable StandingsTable { get; set; }
    }
}