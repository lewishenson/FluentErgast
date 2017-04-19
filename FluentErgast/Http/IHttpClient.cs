using System.Threading.Tasks;

namespace FluentErgast.Http
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}