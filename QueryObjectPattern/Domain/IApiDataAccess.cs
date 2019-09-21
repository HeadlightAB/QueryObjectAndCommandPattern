using System.Net;

namespace Domain
{
    public interface IApiDataAccess : IDataSource
    {
        HttpWebResponse Request(HttpWebRequest request);
    }
}