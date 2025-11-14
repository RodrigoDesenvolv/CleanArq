namespace Business.Strategy.ETO.Domain.AnnualGoal
{
    public class AnnualGoalEntity
    {
        public string Goal { get; private set; }
        public int Year { get; private set; }

        public AnnualGoalEntity(string goal, int year)
        {
            Goal = goal ?? throw new ArgumentNullException(nameof(goal));
            Year = year > 0 ? year : throw new ArgumentException("Year must be greater than 0.");
        }
    }
}
