using System;
using CommandPattern.DataAccess.DataSources;
using CommandPattern.Domain.Commands;
using FluentAssertions;
using Xunit;

namespace CommandPattern.Tests
{
    public class CommandTests
    {
        private static readonly InMemoryDataSource DataSource = new InMemoryDataSource();

        [Fact]
        public void CarInspectionFailedTest()
        {
            var inspectedAt = DateTimeOffset.UtcNow;
            var sut = new CarInspectionFailed("RNY293", inspectedAt);

            sut.Execute(DataSource);

            var containSingle = DataSource.Cars.Should().ContainSingle(x => x.RegNo == "RNY293").Subject;
            containSingle.InspectedAt.Should().Be(inspectedAt);
            containSingle.InspectionApproved.Should().BeFalse();
        }

        [Fact]
        public void CarInspectionApprovedTest()
        {
            var inspectedAt = DateTimeOffset.UtcNow;
            var sut = new CarInspectionApproved("GLW975", inspectedAt);

            sut.Execute(DataSource);

            var containSingle = DataSource.Cars.Should().ContainSingle(x => x.RegNo == "GLW975").Subject;
            containSingle.InspectedAt.Should().Be(inspectedAt);
            containSingle.InspectionApproved.Should().BeTrue();
        }
    }
}
