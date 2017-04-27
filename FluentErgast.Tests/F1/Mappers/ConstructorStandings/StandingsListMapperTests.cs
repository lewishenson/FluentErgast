using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.F1.Mappers.ConstructorStandings;
using NSubstitute;
using Xunit;
using Dtos = FluentErgast.F1.Dtos;
using InternalDtos = FluentErgast.F1.InternalDtos;

namespace FluentErgast.Tests.F1.ConstructorStandings
{
    public class StandingsListMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var constructorStandingMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.ConstructorStanding, Dtos.ConstructorStandings.ConstructorStanding>>();

            var subjectUnderTest = new StandingsListMapper(constructorStandingMapper);

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new InternalDtos.ConstructorStandings.StandingsList
            {
                Season = "2017",
                Round = "1",
                ConstructorStandings = new[]
                {
                    new InternalDtos.ConstructorStandings.ConstructorStanding()
                }
            };

            var constructorStandingMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.ConstructorStanding, Dtos.ConstructorStandings.ConstructorStanding>>();
            var constructorStandingDto = new Dtos.ConstructorStandings.ConstructorStanding();
            constructorStandingMapper.Map(internalDto.ConstructorStandings[0])
                                     .Returns(constructorStandingDto);

            var subjectUnderTest = new StandingsListMapper(constructorStandingMapper);

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto, options => options.Excluding(x => x.ConstructorStandings));
            output.ConstructorStandings.ShouldBeEquivalentTo(new[] { constructorStandingDto });
        }
    }
}