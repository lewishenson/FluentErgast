using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos
{
    public abstract class MRDataBase
    {
        [JsonProperty("xmlns")]
        public string XmlNamespace { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
    }
}