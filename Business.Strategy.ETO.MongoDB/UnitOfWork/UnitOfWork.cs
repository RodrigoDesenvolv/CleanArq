using Business.Strategy.ETO.MongoDB.Context.Contracts;
using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using Business.Strategy.ETO.MongoDB.Interceptor;

namespace Business.Strategy.ETO.MongoDB.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly IMongoContext _mongoContext;
        private readonly SaveChangeInterceptor _saveChangeInterceptor;
        private readonly IEventCatcher _eventCatcher;

        public UnitOfWork(IMongoContext mongoContext,SaveChangeInterceptor saveChangeInterceptor,IEventCatcher eventCatcher)
        {
            if (mongoContext is null)
            {
                throw new ArgumentNullException(nameof(mongoContext));

            }

            if (saveChangeInterceptor is null)
            {
                throw new ArgumentNullException(nameof(saveChangeInterceptor));

            }

            if (eventCatcher is null)
            {
                throw new ArgumentNullException(nameof(eventCatcher));

            }

            _mongoContext = mongoContext;
            _saveChangeInterceptor = saveChangeInterceptor;
            _eventCatcher = eventCatcher;
                
        }


        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await (_saveChangeInterceptor.BeforeCommitAsync(_eventCatcher));
            return await _mongoContext.SaveChanges();
        }

        public void Dispose()
        {
           _mongoContext.Dispose();
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
