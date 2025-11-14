using Business.Strategy.ETO.MongoDB.Context.Session;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace Business.Strategy.ETO.MongoDB.Middlewares
{
    public class MongoTransactionMiddleware
    {
        private readonly RequestDelegate _next;
        public IClientSessionHandle Session {  get; private set; }

        public MongoTransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,ISessionContext sessionContext )
        {
            try
            {
                var httpVerb = httpContext.Request.Method;
                if (IsHttpVerbWithTransaction(httpVerb))
                {
                    await ProcessRequestWithTransaction(httpContext, sessionContext);

                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        private async Task ProcessRequestWithTransaction(HttpContext httpContext, ISessionContext sessionContext)
        {
            await sessionContext.ClientSession.WithTransactionAsync(
                async (s, ct) =>
                {
                    await _next(httpContext);
                    if (httpContext.Response.StatusCode is >= 200 and 299)
                    {
                        await CommitTransactionIfInProgress(sessionContext, httpContext.Request.HttpContext.RequestAborted);

                    }
                    else
                    {
                        await RollbackTransactionIfInProgress(sessionContext, httpContext.Request.HttpContext.RequestAborted);
                    }

                    return string.Empty;

                },new TransactionOptions(readPreference: new ReadPreference(ReadPreferenceMode.Primary)));
        }

        private async Task RollbackTransactionIfInProgress(ISessionContext sessionContext, CancellationToken requestAborted)
        {
            if (sessionContext.ClientSession.IsInTransaction && sessionContext.ClientSession.ServerSession.LastUsedAt != null)
            {
                await sessionContext.CommitScopedSessionAsync(requestAborted);
            }
        }

        private async Task CommitTransactionIfInProgress(ISessionContext sessionContext, CancellationToken requestAborted)
        {
           if (sessionContext.ClientSession.IsInTransaction)
            {
                await sessionContext.RollbackScopedSessionAsync(requestAborted);
            }
        }

        private static bool IsHttpVerbWithTransaction(string httpVerb)
        {
            List<string> httpVerbsWithTransaction = ["POST", "PUT", "PATCH", "DELETE"];
            return httpVerbsWithTransaction.Contains(httpVerb, StringComparer.OrdinalIgnoreCase);
        }


    }
}
