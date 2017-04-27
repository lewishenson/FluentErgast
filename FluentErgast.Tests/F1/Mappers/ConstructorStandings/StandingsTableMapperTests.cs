using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.F1.Mappers.ConstructorStandings;
using NSubstitute;
using Xunit;
using Dtos = FluentErgast.F1.Dtos;
using InternalDtos = FluentErgast.F1.InternalDtos;

namespace FluentErgast.Tests.F1.ConstructorStandings
{
    public class StandingsTableMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var standingsListMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.StandingsList, Dtos.ConstructorStandings.StandingsList>>();

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
            var internalDto = new InternalDtos.ConstructorStandings.StandingsTable
            {
                Season = "2017",
                StandingsLists = new[]
                {
                    new InternalDtos.ConstructorStandings.StandingsList()
                }
            };

            var standingsListMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.StandingsList, Dtos.ConstructorStandings.StandingsList>>();
            var standingsListDto = new Dtos.ConstructorStandings.StandingsList();
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