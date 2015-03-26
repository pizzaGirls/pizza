using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class DetailedOrderApi
    {
        private readonly IRepository<OrderLine> _orderLineRepository;
        public readonly IRepository<Customer> _customerRepository;
        public readonly IRepository<Product> _productRepository;

        public DetailedOrderApi(IRepository<OrderLine> orderLineRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository)
        {
            _orderLineRepository = orderLineRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }
    }
}
