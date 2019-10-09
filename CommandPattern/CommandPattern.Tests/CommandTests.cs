using System;
using CommandPattern.DataAccess.DataSources;
using CommandPattern.Domain.Commands;
using CommandPattern.Domain.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CommandPattern.Tests
{
    public class CommandTests
    {
        private static readonly InMemoryDataSource DataSource = new InMemoryDataSource();

        [Fact]
        public void CarInspectionFailedTest()
        {
            var domainModel = new Car("RNY293");
            var inspectedAt = DateTimeOffset.UtcNow;
            var sut = new CarInspectionFailed(inspectedAt);
            
            sut.Execute(domainModel,  DataSource);

            var containSingle = DataSource.Cars.Should().ContainSingle(x => x.RegNo == "RNY293").Subject;
            containSingle.InspectedAt.Should().Be(inspectedAt);
            containSingle.InspectionApproved.Should().BeFalse();
        }

        [Fact]
        public void CarInspectionFailed_ShouldInvokeDataSource()
        {
            var dataSource = Substitute.For<InMemoryDataSource>();

            var domainModel = new Car("RNY293");
            var inspectedAt = DateTimeOffset.UtcNow;
            var sut = new CarInspectionFailed(inspectedAt);

            sut.Execute(domainModel, dataSource);

            dataSource.Received().Store(Arg.Is<DataAccess.Entities.Car>(car =>
                car.InspectionApproved == false &&
                car.RegNo == "RNY293" &&
                car.InspectedAt == inspectedAt));
        }

        [Fact]
        public void CarInspectionFailed_ShouldApplyDomainModelChanges()
        {
            var dataSource = Substitute.For<InMemoryDataSource>();
            var domainModel = Substitute.For<Car>("RNY293");

            var inspectedAt = DateTimeOffset.UtcNow;
            var sut = new CarInspectionFailed(inspectedAt);

            sut.Execute(domainModel, dataSource);

            domainModel.Received().ApplyInspectionFailed(inspectedAt);
        }

        [Fact]
        public void CarInspectionApprovedTest()
        {
            var domainModel = new Car("GLW975");
            var inspectedAt = DateTimeOffset.UtcNow;
            var sut = new CarInspectionApproved(inspectedAt);
            
            sut.Execute(domainModel,  DataSource);

            var containSingle = DataSource.Cars.Should().ContainSingle(x => x.RegNo == "GLW975").Subject;
            containSingle.InspectedAt.Should().Be(inspectedAt);
            containSingle.InspectionApproved.Should().BeTrue();
        }
    }
}
