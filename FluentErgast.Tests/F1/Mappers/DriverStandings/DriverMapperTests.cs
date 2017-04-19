using System;
using FluentAssertions;
using FluentErgast.F1.InternalDtos.DriverStandings;
using FluentErgast.F1.Mappers.DriverStandings;
using Xunit;

namespace FluentErgast.Tests.F1.DriverStandings
{
    public class DriverMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var subjectUnderTest = new DriverMapper();

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new Driver
            {
                DriverId = "TheDriverId",
                PermanentNumber = "22",
                Code = "TheCode",
                Url = "TheUrl",
                GivenName = "TheGivenName",
                FamilyName = "TheFamilyName",
                DateOfBirth = "2017-03-26",
                Nationality = "TheNationality"
            };

            var subjectUnderTest = new DriverMapper();

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto, options => options.Excluding(x => x.DateOfBirth));
            output.DateOfBirth.Should().Be(new DateTime(2017, 3, 26));
        }
    }
}