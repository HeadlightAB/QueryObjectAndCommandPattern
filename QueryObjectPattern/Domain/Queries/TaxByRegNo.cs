using System.Net.Http;
using System.Threading.Tasks;
using DataAccess.DataSources;

namespace Domain.Queries
{
    public class TaxByRegNo : IQuery<float, IApiDataAccess>
    {
        private readonly string _regNo;

        public TaxByRegNo(string regNo)
        {
            _regNo = regNo;
        }

        public async Task<float> Execute(IApiDataAccess dataSource)
        {
            // Url not valid, but for the purpose of the example it is sort of suitable
            var response =
                await dataSource.Request(
                    new HttpRequestMessage(HttpMethod.Get, $"https://www.google.com/{_regNo}"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (float.TryParse(content, out var result))
                {
                    return result;
                }
            }

            return -1;
        }
    }
}