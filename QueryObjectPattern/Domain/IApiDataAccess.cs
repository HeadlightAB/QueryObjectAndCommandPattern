using System.Net;

namespace Domain
{
    public interface IApiDataAccess : IDataAccess
    {
        HttpWebResponse Request(HttpWebRequest request);
    }
}