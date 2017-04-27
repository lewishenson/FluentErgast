using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentErgast.F1.Mappers;
using FluentErgast.Http;
using NSubstitute;
using Xunit;
using Dtos = FluentErgast.F1.Dtos;
using ConstructorStandingsInstance = FluentErgast.F1.ConstructorStandings;
using InternalDtos = FluentErgast.F1.InternalDtos;

namespace FluentErgast.Tests.F1
{
    public class ConstructorStandingsTests
    {
        [Fact]
        public async Task ForYearAsyncGetsExpectedDataAndReturnsMappedInstance()
        {
            // Arrange
            var httpClient = Substitute.For<IHttpClient>();
            var constructorStandingsResponse = new InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>
            {
                MRData = new InternalDtos.ConstructorStandings.MRData
                {
                    StandingsTable = new InternalDtos.ConstructorStandings.StandingsTable()
                }
            };
            httpClient.GetAsync<InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>>("http://ergast.com/api/f1/2017/constructorStandings.json")
                      .Returns(Task.FromResult(constructorStandingsResponse));

            var standingsTableMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.StandingsTable, Dtos.ConstructorStandings.StandingsTable>>();
            var standingsTable = new Dtos.ConstructorStandings.StandingsTable();
            standingsTableMapper.Map(constructorStandingsResponse.MRData.StandingsTable)
                                .Returns(standingsTable);

            var subjectUnderTest = new ConstructorStandingsInstance(httpClient, standingsTableMapper);

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
            var constructorStandingsResponse = new InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>
            {
                MRData = new InternalDtos.ConstructorStandings.MRData
                {
                    StandingsTable = new InternalDtos.ConstructorStandings.StandingsTable()
                }
            };
            httpClient.GetAsync<InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>>($"http://ergast.com/api/f1/{DateTime.Now.Year}/constructorStandings.json")
                      .Returns(Task.FromResult(constructorStandingsResponse));

            var standingsTableMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.StandingsTable, Dtos.ConstructorStandings.StandingsTable>>();
            var standingsTable = new Dtos.ConstructorStandings.StandingsTable();
            standingsTableMapper.Map(constructorStandingsResponse.MRData.StandingsTable)
                                .Returns(standingsTable);

            var subjectUnderTest = new ConstructorStandingsInstance(httpClient, standingsTableMapper);

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
            var constructorStandingsResponse = new InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>
            {
                MRData = new InternalDtos.ConstructorStandings.MRData
                {
                    StandingsTable = new InternalDtos.ConstructorStandings.StandingsTable()
                }
            };
            httpClient.GetAsync<InternalDtos.Response<InternalDtos.ConstructorStandings.MRData>>("http://ergast.com/api/f1/2017/3/constructorStandings.json")
                      .Returns(Task.FromResult(constructorStandingsResponse));

            var standingsTableMapper = Substitute.For<IMapper<InternalDtos.ConstructorStandings.StandingsTable, Dtos.ConstructorStandings.StandingsTable>>();
            var standingsTable = new Dtos.ConstructorStandings.StandingsTable();
            standingsTableMapper.Map(constructorStandingsResponse.MRData.StandingsTable)
                                .Returns(standingsTable);

            var subjectUnderTest = new ConstructorStandingsInstance(httpClient, standingsTableMapper);

            // Act
            var output = await subjectUnderTest.ForRound(3).ForYearAsync(2017);

            // Assert
            output.Should().Be(standingsTable);
        }
    }
}