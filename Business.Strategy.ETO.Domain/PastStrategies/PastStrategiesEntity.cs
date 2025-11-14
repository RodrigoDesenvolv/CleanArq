namespace Business.Strategy.ETO.Domain.PastStrategies
{
    public class PastStrategiesEntity
    {
        public List<string> ActionsTaken { get; private set; }
        public List<string> Results { get; private set; }
        public List<string> LessonsLearned { get; private set; }

        // Constructor
        public PastStrategiesEntity(List<string> actionsTaken, 
                                    List<string> results, 
                                    List<string> lessonsLearned)
        {
            ActionsTaken = actionsTaken;
            Results = results;
            LessonsLearned = lessonsLearned;
        }
    }
}
