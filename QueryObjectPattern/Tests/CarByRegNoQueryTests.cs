using System;
using DataAccess.DataSources;
using Domain.Queries;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class CarByRegNoQueryTests
    {
        [Fact]
        public void ShouldReturnNotNull()
        {
            var dbDataAccess = Substitute.For<IDbDataAccess>();
            dbDataAccess
                .Query(Arg.Any<Func<DataAccess.Entities.Car, bool>>(), Arg.Any<Func<DataAccess.Entities.Car, Domain.Models.Car>>())
                .Returns(new[] {new Domain.Models.Car("GLW975") });

            var sut = new CarByRegNo("GLW975");

            var car = sut.Execute(dbDataAccess);

            car.Should().NotBeNull();
        }
    }
}
