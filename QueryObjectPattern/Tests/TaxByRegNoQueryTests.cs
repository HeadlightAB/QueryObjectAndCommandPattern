using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccess.DataSources;
using Domain.Queries;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class TaxByRegNoQueryTests
    {
        [Fact]
        public async Task ShouldReturnNotNull()
        {
            var apiDatAccess = Substitute.For<IApiDataAccess>();
            apiDatAccess
                .Request(Arg.Any<HttpRequestMessage>())
                .Returns(Task.FromResult(
                    new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent("5000")}));

            var sut = new TaxByRegNo("GLW975");

            var taxRate = await sut.Execute(apiDatAccess);

            taxRate.Should().Be(5000f);
        }
    }
}