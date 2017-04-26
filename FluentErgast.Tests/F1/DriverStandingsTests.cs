using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.Http;
using NSubstitute;
using Xunit;
using Dtos = FluentErgast.F1.Dtos;
using DriverStandingsInstance = FluentErgast.F1.DriverStandings;
using InternalDtos = FluentErgast.F1.InternalDtos;

namespace FluentErgast.Tests.F1
{
    public class DriverStandingsTests
    {
        [Fact]
        public async Task ForYearAsyncGetsExpectedDataAndReturnsMappedInstance()
        {
            // Arrange
            var httpClient = Substitute.For<IHttpClient>();
            var driverStandingsResponse = new InternalDtos.DriverStandings.Response
            {
                MRData = new InternalDtos.DriverStandings.MRData
                {
                    StandingsTable = new InternalDtos.DriverStandings.StandingsTable()
                }
            };
            httpClient.GetAsync<InternalDtos.DriverStandings.Response>("http://ergast.com/api/f1/2017/driverStandings.json")
                      .Returns(Task.FromResult(driverStandingsResponse));

            var standingsTableMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.StandingsTable, Dtos.DriverStandings.StandingsTable>>();
            var standingsTable = new Dtos.DriverStandings.StandingsTable();
            standingsTableMapper.Map(driverStandingsResponse.MRData.StandingsTable)
                                .Returns(standingsTable);

            var subjectUnderTest = new DriverStandingsInstance(httpClient, standingsTableMapper);

            // Act
            var output = await subjectUnderTest.ForYearAsync(2017);

            // Assert
            output.Should().Be(standingsTable);
        }

        [Fact]
        public async Task ForCurrentYearAsyncGetsExpectedDataAndReturnsMappedInstance()
        {
            // Arrange
            var httpClient = Substitute.For<IHttpClient>();
            var driverStandingsResponse = new InternalDtos.DriverStandings.Response
            {
                MRData = new InternalDtos.DriverStandings.MRData
                {
                    StandingsTable = new InternalDtos.DriverStandings.StandingsTable()
                }
            };
            httpClient.GetAsync<InternalDtos.DriverStandings.Response>($"http://ergast.com/api/f1/{DateTime.Now.Year}/driverStandings.json")
                      .Returns(Task.FromResult(driverStandingsResponse));

            var standingsTableMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.StandingsTable, Dtos.DriverStandings.StandingsTable>>();
            var standingsTable = new Dtos.DriverStandings.StandingsTable();
            standingsTableMapper.Map(driverStandingsResponse.MRData.StandingsTable)
                                .Returns(standingsTable);

            var subjectUnderTest = new DriverStandingsInstance(httpClient, standingsTableMapper);

            // Act
            var output = await subjectUnderTest.ForCurrentYearAsync();

            // Assert
            output.Should().Be(standingsTable);
        }

        [Fact]
        public async Task ForRoundGetsExpectedDataAndReturnsMappedInstance()
        {
            // Arrange
            var httpClient = Substitute.For<IHttpClient>();
            var driverStandingsResponse = new InternalDtos.DriverStandings.Response
            {
                MRData = new InternalDtos.DriverStandings.MRData
                {
                    StandingsTable = new InternalDtos.DriverStandings.StandingsTable()
                }
            };
            httpClient.GetAsync<InternalDtos.DriverStandings.Response>("http://ergast.com/api/f1/2017/3/driverStandings.json")
                      .Returns(Task.FromResult(driverStandingsResponse));

            var standingsTableMapper = Substitute.For<IMapper<InternalDtos.DriverStandings.StandingsTable, Dtos.DriverStandings.StandingsTable>>();
            var standingsTable = new Dtos.DriverStandings.StandingsTable();
            standingsTableMapper.Map(driverStandingsResponse.MRData.StandingsTable)
                                .Returns(standingsTable);

            var subjectUnderTest = new DriverStandingsInstance(httpClient, standingsTableMapper);

            // Act
            var output = await subjectUnderTest.ForRound(3).ForYearAsync(2017);

            // Assert
            output.Should().Be(standingsTable);
        }
    }
}