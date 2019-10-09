using System;
using CommandPattern.DataAccess;
using CommandPattern.DataAccess.DataSources;
using CommandPattern.Domain.Commands;
using CommandPattern.Domain.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CommandPattern.Tests
{
    public class CarInspectionFailedTests
    {
        private const string RegNo = "GLW975";

        private readonly CarInspectionFailed _sut;
        private readonly DateTimeOffset _inspectedAt;

        public CarInspectionFailedTests()
        {
            _inspectedAt = DateTimeOffset.Now;
            _sut = new CarInspectionFailed(_inspectedAt);
        }

        [Fact]
        public void CarInspectionFailedTest()
        {
            var domainModel = new Car(RegNo);
            var dataSource = new InMemoryDataSource();

            _sut.Execute(domainModel,  dataSource);

            var containSingle = dataSource.Cars.Should().ContainSingle(x => x.RegNo == RegNo).Subject;
            containSingle.InspectedAt.Should().Be(_inspectedAt);
            containSingle.InspectionApproved.Should().BeFalse();
        }

        [Fact]
        public void CarInspectionFailed_ShouldInvokeDataSource()
        {
            var domainModel = new Car(RegNo);
            var dataSource = Substitute.For<InMemoryDataSource>();

            _sut.Execute(domainModel, dataSource);

            dataSource.Received().Store(Arg.Is<DataAccess.Entities.Car>(car =>
                car.InspectionApproved == false &&
                car.RegNo == RegNo &&
                car.InspectedAt == _inspectedAt));
        }

        [Fact]
        public void CarInspectionFailed_ShouldApplyDomainModelChanges()
        {
            var dataSource = Substitute.For<InMemoryDataSource>();
            var domainModel = Substitute.For<Car>(RegNo);

            _sut.Execute(domainModel, dataSource);

            domainModel.Received().ApplyInspectionFailed(_inspectedAt);
        }
    }
}
