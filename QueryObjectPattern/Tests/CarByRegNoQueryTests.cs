using System;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccess.DataSources;
using Domain.Queries;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class CarByRegNoQueryTests
    {
        [Fact]
        public async Task ShouldReturnNotNull()
        {
            var dbDataAccess = Substitute.For<IDbDataAccess>();
            dbDataAccess
                .Query(Arg.Any<Func<DataAccess.Entities.Car, bool>>(), Arg.Any<Func<DataAccess.Entities.Car, Domain.Models.Car>>())
                .Returns(new[] {new Domain.Models.Car("GLW975") });

            var sut = new CarByRegNo("GLW975");

            var car = await sut.Execute(dbDataAccess);

            car.Should().NotBeNull();
        }

        [Theory]
        [InlineData("GLW975")]
        [InlineData("WFT227")]
        [InlineData("RNY293")]
        public async Task IntegrationTest(string regNo)
        {
            /////
            // Expecting result -1 since the api url is not valid.
            /////

            var services = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var apiDbAccess = new ApiDataAccess(services.GetService<IHttpClientFactory>());

            var sut = new TaxByRegNo(regNo);

            var result = await sut.Execute(apiDbAccess);
            
            result.Should().BeOfType(typeof(float));
        }
    }
}
