using System;

namespace Hecsit.PizzaGirls.Core.Domain
{
    public abstract class Entity
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }

        protected Entity()
        {
            _id = Guid.NewGuid();
        }
    }
}