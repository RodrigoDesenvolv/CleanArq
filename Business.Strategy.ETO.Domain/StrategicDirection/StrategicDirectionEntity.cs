using Business.Strategy.ETO.Domain.AnnualGoal;
using Business.Strategy.ETO.Domain.GrowthAvenue;
using Business.Strategy.ETO.Domain.LongTermVision;

namespace Business.Strategy.ETO.Domain.StrategicDirection
{
    public class StrategicDirectionEntity
    {

        public LongTermVisionEntity LongTermVision { get; private set; }
        public List<string> StrategicGuidelines { get; private set; }
        public List<AnnualGoalEntity> MajorAnnualGoals { get; private set; }
        public List<GrowthAvenueEntity> GrowthAvenues { get; private set; }


        public StrategicDirectionEntity(LongTermVisionEntity longTermVision, List<string> strategicGuidelines,
                          List<AnnualGoalEntity> majorAnnualGoals, List<GrowthAvenueEntity> growthAvenues)
        {
            LongTermVision = longTermVision ?? throw new ArgumentNullException(nameof(longTermVision));
            StrategicGuidelines = strategicGuidelines ?? new List<string>();
            MajorAnnualGoals = majorAnnualGoals ?? new List<AnnualGoalEntity>();
            GrowthAvenues = growthAvenues ?? new List<GrowthAvenueEntity>();
        }
    }
}
