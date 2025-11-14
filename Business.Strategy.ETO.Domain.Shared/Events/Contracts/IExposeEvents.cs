using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;

namespace Business.Strategy.ETO.MongoDB.SeedWork.Contracts
{
    public interface IExposeEvents
    {
        IEnumerable<IEvent> Events { get; }

        void ClearEvents();
    }
}
