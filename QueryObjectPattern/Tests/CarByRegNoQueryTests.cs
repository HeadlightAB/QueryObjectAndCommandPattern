using System;
using Domain;
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
                .Query(Arg.Any<Func<Domain.Models.Car, bool>>(), Arg.Any<Func<object, Domain.Models.Car>>())
                .Returns(new[] {new Domain.Models.Car()});

            var sut = new CarByRegNo("GLW975");

            var car = sut.Execute(dbDataAccess);

            car.Should().NotBeNull();
        }
    }
}
