using System.Threading.Tasks;
using FluentErgast.F1.Dtos.ConstructorStandings;

namespace FluentErgast.F1
{
    public interface IGetConstructorStandings
    {
        Task<StandingsTable> ForCurrentYearAsync();

        Task<StandingsTable> ForYearAsync(int year);
    }
}