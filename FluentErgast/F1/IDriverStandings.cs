namespace FluentErgast.F1
{
    public interface IDriverStandings : IGetDriverStandings
    {
        IGetDriverStandings ForRound(int round);
    }
}