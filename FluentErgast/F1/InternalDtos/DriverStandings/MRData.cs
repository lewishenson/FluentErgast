using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.DriverStandings
{
    public class MRData : MRDataBase
    {
        [JsonProperty("StandingsTable")]
        public StandingsTable StandingsTable { get; set; }
    }
}