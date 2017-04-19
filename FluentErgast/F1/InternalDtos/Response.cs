using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.DriverStandings
{
    public class Response
    {
        [JsonProperty("MRData")]
        public MRData MRData { get; set; }
    }
}