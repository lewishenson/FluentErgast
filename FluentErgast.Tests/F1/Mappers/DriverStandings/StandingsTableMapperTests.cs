using FluentAssertions;
using FluentErgast.F1.Mappers.DriverStandings;
using NSubstitute;
using Xunit;
using InternalDtos = FluentErgast.F1.InternalDtos;
using Dtos = FluentErgast.F1.Dtos;
using FluentErgast.F1.Mappers;

namespace FluentErgast.Tests.F1.DriverStandings
{
    public class StandingsTableMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var standingsListMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.StandingsList, Dtos.DriverStandings.StandingsList>>();

            var subjectUnderTest = new StandingsTableMapper(standingsListMapper);

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new InternalDtos.DriverStandings.StandingsTable
            {
                Season = "2017",
                StandingsLists = new[]
                {
                    new InternalDtos.DriverStandings.StandingsList()
                }
            };

            var standingsListMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.StandingsList, Dtos.DriverStandings.StandingsList>>();
            var standingsListDto = new Dtos.DriverStandings.StandingsList();
            standingsListMapper.Map(internalDto.StandingsLists[0])
                               .Returns(standingsListDto);

            var subjectUnderTest = new StandingsTableMapper(standingsListMapper);

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto, options => options.Excluding(x => x.StandingsLists));
            output.StandingsLists.ShouldBeEquivalentTo(new[] { standingsListDto });
        }
    }
}