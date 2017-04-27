using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.F1.Mappers.DriverStandings;
using NSubstitute;
using Xunit;
using Dtos = FluentErgast.F1.Dtos;
using InternalDtos = FluentErgast.F1.InternalDtos;

namespace FluentErgast.Tests.F1.DriverStandings
{
    public class DriverStandingMapperTests
    {
        [Fact]
        public void NullInputResultsInNullOutput()
        {
            // Arrange
            var driverMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.Driver, Dtos.DriverStandings.Driver>>();
            var constructorMapper = Substitute.For<IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor>>();
            var subjectUnderTest = new DriverStandingMapper(driverMapper, constructorMapper);

            // Act
            var output = subjectUnderTest.Map(null);

            // Assert
            output.Should().BeNull();
        }

        [Fact]
        public void ValidInputHasAllPropertiesMappedToOutput()
        {
            // Arrange
            var internalDto = new InternalDtos.DriverStandings.DriverStanding
            {
                Position = "1",
                PositionText = "ThePositionText",
                Points = "2",
                Wins = "3",
                Driver = new InternalDtos.DriverStandings.Driver(),
                Constructors = new InternalDtos.Shared.Constructor[]
                {
                    new InternalDtos.Shared.Constructor()
                }
            };

            var driverMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.Driver, Dtos.DriverStandings.Driver>>();
            var driverDto = new Dtos.DriverStandings.Driver();
            driverMapper.Map(internalDto.Driver)
                        .Returns(driverDto);

            var constructorMapper = Substitute.For<IMapper<InternalDtos.Shared.Constructor, Dtos.Shared.Constructor>>();
            var constructorDto = new Dtos.Shared.Constructor();
            constructorMapper.Map(internalDto.Constructors[0])
                             .Returns(constructorDto);

            var subjectUnderTest = new DriverStandingMapper(driverMapper, constructorMapper);

            // Act
            var output = subjectUnderTest.Map(internalDto);

            // Assert
            output.ShouldBeEquivalentTo(internalDto, options => options.Excluding(x => x.Driver)
                                                                       .Excluding(x => x.Constructors));
            output.Driver.Should().Be(driverDto);
            output.Constructors.ShouldBeEquivalentTo(new[] { constructorDto });
        }
    }
}