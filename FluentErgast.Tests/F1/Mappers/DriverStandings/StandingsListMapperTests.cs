using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.F1.Mappers.DriverStandings;
using NSubstitute;
using Xunit;
using InternalDtos = FluentErgast.F1.InternalDtos;
using Dtos = FluentErgast.F1.Dtos;

namespace FluentErgast.Tests.F1.DriverStandings
{
    public class StandingsListMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var driverStandingMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.DriverStanding, Dtos.DriverStandings.DriverStanding>>();

            var subjectUnderTest = new StandingsListMapper(driverStandingMapper);

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new InternalDtos.DriverStandings.StandingsList
            {
                Season = "2017",
                Round = "1",
                DriverStandings = new[]
                {
                    new InternalDtos.DriverStandings.DriverStanding()
                }
            };

            var driverStandingMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.DriverStanding, Dtos.DriverStandings.DriverStanding>>();
            var driverStandingDto = new Dtos.DriverStandings.DriverStanding();
            driverStandingMapper.Map(internalDto.DriverStandings[0])
                                .Returns(driverStandingDto);

            var subjectUnderTest = new StandingsListMapper(driverStandingMapper);

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto, options => options.Excluding(x => x.DriverStandings));
            output.DriverStandings.ShouldBeEquivalentTo(new[] { driverStandingDto });
        }
    }
}