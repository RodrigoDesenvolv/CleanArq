using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.ETO.MongoDB.Context.Contracts
{
    public interface IMongoContext :IDisposable
    {
        IEventCatcher EventCatcher { get; }
        IMongoCollection<T> GetCollection<T>(string name);
        Task AddCommand(Func<Task> func);
        Task<int> SaveChanges();
    }
}
