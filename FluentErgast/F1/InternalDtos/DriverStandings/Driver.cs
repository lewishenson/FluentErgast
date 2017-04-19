using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.DriverStandings
{
    public class Driver
    {
        [JsonProperty("driverId")]
        public string DriverId { get; set; }

        [JsonProperty("permanentNumber")]
        public string PermanentNumber { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }
    }
}