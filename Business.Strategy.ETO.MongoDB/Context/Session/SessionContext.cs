using Business.Strategy.ETO.MongoDB.DependencyInjection.Contracts;
using Business.Strategy.ETO.MongoDB.UnitOfWork;
using MongoDB.Driver;

namespace Business.Strategy.ETO.MongoDB.Context.Session
{
    internal class SessionContext : ISessionContext
    {
        private readonly IClientSessionHandle _session;
        private readonly IUnitOfWork _unitOfWork;

        public IClientSessionHandle ClientSession => _session;

        public SessionContext(IUnitOfWork unitOfWork,IMongoClientDatabase mongoClientDatabase)
        {
            _unitOfWork = unitOfWork;
            _session = mongoClientDatabase.MongoClient.StartSession();
            
        }

        public async Task CommitScopedSessionAsync(CancellationToken cancellationToken = default)
        {
            await _session.CommitTransactionAsync(cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            _session.StartTransaction();
        }

        public async Task RollbackScopedSessionAsync(CancellationToken cancellationToken = default)
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            await _session.AbortTransactionAsync(cancellationToken);
            _session.StartTransaction();
            
        }

        public void Dispose() 
        { 
            _session.Dispose();
        }
    }
}
