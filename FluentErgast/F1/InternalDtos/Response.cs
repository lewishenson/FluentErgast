using Newtonsoft.Json;

namespace FluentErgast.F1.InternalDtos
{
    public class Response<T> where T : MRDataBase
    {
        [JsonProperty("MRData")]
        public T MRData { get; set; }
    }
}