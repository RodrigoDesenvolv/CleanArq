using Business.Strategy.ETO.Domain.ExternalFactors;

namespace Business.Strategy.ETO.Domain.StrategicScope
{
    public class StrategicScopeEntity
    {

        public string Mission { get; private set; }
        public string Vision { get; private set; }
        public List<string> Values { get; private set; }
        public string StrategicFoundation { get; private set; }
        public string ValueChain { get; private set; }
        public ExternalFactorsEntity ExternalFactors { get; private set; }
        public List<string> HighImpactFocus { get; private set; }


        public StrategicScopeEntity(string mission,
                            string vision,
                            List<string> values,
                            string strategicFoundation,
                            string valueChain,
                            ExternalFactorsEntity externalFactors,
                            List<string> highImpactFocus)
        {
            Mission = mission;
            Vision = vision;
            Values = values;
            StrategicFoundation = strategicFoundation;
            ValueChain = valueChain;
            ExternalFactors = externalFactors;
            HighImpactFocus = highImpactFocus;
        }
    }
}
