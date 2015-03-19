using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class OrderApi
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Order> _orderRepository;
        //private readonly IRepository<OrderLines> _orderLinesRepository;

        public OrderApi(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.AsQueryable()
                .Select(x => new OrderDto
                {
                    Number = x.Number,
                    Date = x.Date,
                    Status = x.Status,
                    DeliveryCost = x.DeliveryCost,
                    CustomerId = x.Customer.Id,
                    CustomersCard = x.Customer.Card,
                }).ToList();
        }

        public void AddNewOrder(Guid customerId, string number)
        {
            _orderRepository.Add(new Order(number, _customerRepository.Get(customerId)));
        }

        
    }
}
