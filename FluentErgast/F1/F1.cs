namespace FluentErgast.F1
{
    public class F1 : IF1
    {
        public F1(IDriverStandings driverStandings, IConstructorStandings constructorStandings)
        {
            this.DriverStandings = driverStandings;
            this.ConstructorStandings = constructorStandings;
        }

        public IDriverStandings DriverStandings { get; }

        public IConstructorStandings ConstructorStandings { get; }
    }
}