using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.F1.Mappers.ConstructorStandings;
using NSubstitute;
using Xunit;
using Dtos = FluentErgast.F1.Dtos;
using InternalDtos = FluentErgast.F1.InternalDtos;

namespace FluentErgast.Tests.F1.ConstructorStandings
{
    public class ConstructorStandingMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var constructorMapper = Substitute.For<IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor>>();
            var subjectUnderTest = new ConstructorStandingMapper(constructorMapper);

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new InternalDtos.ConstructorStandings.ConstructorStanding
            {
                Position = "1",
                PositionText = "ThePositionText",
                Points = "2",
                Wins = "3",
                Constructor = new InternalDtos.Shared.Constructor()
            };

            var constructorMapper = Substitute.For<IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor>>();
            var constructorDto = new Dtos.Shared.Constructor();
            constructorMapper.Map(internalDto.Constructor)
                             .Returns(constructorDto);

            var subjectUnderTest = new ConstructorStandingMapper(constructorMapper);

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto, options => options.Excluding(x => x.Constructor));
            output.Constructor.Should().Be(constructorDto);
        }
    }
}