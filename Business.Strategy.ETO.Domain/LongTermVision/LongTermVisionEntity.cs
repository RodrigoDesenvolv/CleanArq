namespace Business.Strategy.ETO.Domain.LongTermVision
{
    public class LongTermVisionEntity
    {
        public string UpTo2Years { get; private set; }
        public string From2To5Years { get; private set; }
        public string From5To10Years { get; private set; }


        public LongTermVisionEntity(string upTo2Years, string from2To5Years, string from5To10Years)
        {
            UpTo2Years = upTo2Years ?? throw new ArgumentNullException(nameof(upTo2Years));
            From2To5Years = from2To5Years ?? throw new ArgumentNullException(nameof(from2To5Years));
            From5To10Years = from5To10Years ?? throw new ArgumentNullException(nameof(from5To10Years));
        }
    }
}
