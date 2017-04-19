using FluentAssertions;
using FluentErgast.F1.InternalDtos.DriverStandings;
using FluentErgast.F1.Mappers.DriverStandings;
using Xunit;

namespace FluentErgast.Tests.F1.DriverStandings
{
    public class ConstructorMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var subjectUnderTest = new ConstructorMapper();

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new Constructor
            {
                ConstructorId = "TheConstructorId",
                Url = "TheUrl",
                Name = "TheName",
                Nationality = "TheNationality"
            };

            var subjectUnderTest = new ConstructorMapper();

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto);
        }
    }
}