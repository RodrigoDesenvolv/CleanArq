using MongoDB.Driver;

namespace Business.Strategy.ETO.MongoDB.Context.Session
{
    public interface ISessionContext
    {
        IClientSessionHandle ClientSession { get; }
       // void StartTransactionPrimary(TransactionOptions transactionOptions);
        Task CommitScopedSessionAsync(CancellationToken cancellationToken = default);
        Task RollbackScopedSessionAsync(CancellationToken cancellationToken = default);

    }
}
