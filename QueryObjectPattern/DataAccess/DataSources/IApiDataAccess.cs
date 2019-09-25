using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.DataSources
{
    public interface IApiDataAccess : IDataAccess
    {
        Task<HttpResponseMessage> Request(HttpRequestMessage request);
    }
}