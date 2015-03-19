using System;
using System.Linq;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.DataAccess
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> AsQueryable();
        Guid GetLastId();
    }
}