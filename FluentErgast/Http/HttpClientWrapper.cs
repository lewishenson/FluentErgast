using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FluentErgast.Http
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly static HttpClient HttpClient = new HttpClient();

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var responseJson = await HttpClient.GetStringAsync(requestUri);
            var response = JsonConvert.DeserializeObject<T>(responseJson);

            return response;
        }
    }
}