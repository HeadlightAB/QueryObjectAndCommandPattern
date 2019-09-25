using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.DataSources
{
    public class ApiDataAccess : IApiDataAccess
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiDataAccess(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> Request(HttpRequestMessage request)
        {
            return await _httpClientFactory.CreateClient().SendAsync(request);
        }
    }
}