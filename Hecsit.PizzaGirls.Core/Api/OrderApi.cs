using System;
using System.Collections.Generic;
using System.Linq;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class OrderApi
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        //private readonly IRepository<OrderLines> _orderLinesRepository;

        public OrderApi(IRepository<Customer> customerRepository, IRepository<Order> orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
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

        public Guid AddNewOrder(string number, Guid customerId)
        {
            var customer = _customerRepository.Get(customerId);
            var order = new Order(number, customer);
            _orderRepository.Add(order);

            return order.Id;
        }

        public void AddOrderLine(Guid orderId, Guid productId, int quantity)
        {
            var order = _orderRepository.Get(orderId);
            var product = _productRepository.Get(productId);
            order.AddLine(product, quantity);
        }
    }
}
