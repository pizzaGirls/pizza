using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    class OrderApi
    {
        private readonly IRepository<Customer> _customersRepository;
        private readonly IRepository<OrderLine> _orederLineRepository;


    }
}
