using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public OrderApi(IRepository<Customer> customerRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository )
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
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

        public IQueryable<OrderDto> GetOrderById(Guid orderId)
        {
            return _orderRepository.AsQueryable()
                .Where(x => (x.Id == orderId))
                .Select(x => new OrderDto
                {
                    Number = x.Number,
                    Date = x.Date,
                    Status = x.Status,
                    DeliveryCost = x.DeliveryCost,
                    CustomerId = x.Customer.Id,
                    CustomersCard = x.Customer.Card,
                });
        }

        public void AddOrderLine(Guid orderId, Guid productId, int quantity)
        {
            var order = _orderRepository.Get(orderId);
            var product = _productRepository.Get(productId);
            order.AddLine(product, quantity);
        }

        public void Accept(Guid orderId, OrderStatus status)
        {
            //TODO вычислить стоимость
            var order = _orderRepository.Get(orderId);
            order.Status = status;
        }
    }
}
