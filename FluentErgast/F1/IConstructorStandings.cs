namespace FluentErgast.F1
{
    public interface IConstructorStandings : IGetConstructorStandings
    {
        IGetConstructorStandings ForRound(int round);
    }
}