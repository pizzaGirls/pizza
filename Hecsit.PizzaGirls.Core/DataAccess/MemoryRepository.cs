using System;
using System.Collections.Generic;
using System.Linq;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.DataAccess
{
    public class MemoryRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _entities = new List<T>(); 

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AsQueryable()
        {
            return _entities.AsQueryable();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}