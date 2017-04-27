using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos.Shared
{
    public class Constructor
    {
        [JsonProperty("constructorId")]
        public string ConstructorId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }
    }
}