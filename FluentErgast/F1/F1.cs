namespace FluentErgast.F1
{
    public class F1 : IF1
    {
        public F1(IDriverStandings driverStandings)
        {
            this.DriverStandings = driverStandings;
        }

        public IDriverStandings DriverStandings { get; }
    }
}