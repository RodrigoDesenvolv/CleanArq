using Business.Strategy.ETO.MongoDB.Repository.Company.Contracts;

namespace Business.Strategy.ETO.MongoDB.SeedWork
{
    public abstract class EntityBase<TKey> : IEntity<TKey> where TKey : struct
    {
        public TKey Id { get; protected set; }

        public bool Equals(EntityBase<TKey> obj)
        {
            return Id.Equals(obj.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return GetType() == obj.GetType() && Equals((EntityBase<TKey>) obj);
        }

        public static bool operator ==(EntityBase<TKey> left, EntityBase<TKey> right)
        {
            return left.Id.Equals(right.Id);
        }

        public static bool operator !=(EntityBase<TKey> left, EntityBase<TKey> right)
        {
            return !left.Id.Equals(right.Id);
        }
    }
}
