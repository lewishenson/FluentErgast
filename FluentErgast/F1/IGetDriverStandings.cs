using System.Threading.Tasks;
using FluentErgast.F1.Dtos.DriverStandings;

namespace FluentErgast.F1
{
    public interface IGetDriverStandings
    {
        Task<StandingsTable> ForCurrentYearAsync();

        Task<StandingsTable> ForYearAsync(int year);
    }
}