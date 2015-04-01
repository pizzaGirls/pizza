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
        private readonly IRepository<OrderLine> _orderLineRepository;
        private readonly IRepository<Product> _productRepository;
        //private readonly IRepository<OrderLines> _orderLinesRepository;

        public OrderApi(IRepository<Customer> customerRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository, IRepository<OrderLine> orderlineRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderLineRepository = orderlineRepository;
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
                    Price = x.Price,
                    CustomerId = x.Customer.Id,
                    CustomersCard = x.Customer.Card,
                }).ToList();
        }

        public Guid AddNewOrder(string number, Guid customerId, decimal deliveryPrice)
        {
            var customer = _customerRepository.Get(customerId);
            var order = new Order(number, customer, deliveryPrice);
            _orderRepository.Add(order);
            return order.Id;
        }

        //public OrderDto GetOrderById(Guid orderId)
        //{
        //    return _orderRepository.AsQueryable()
        //        .Where(x => x.Id == orderId)
        //        .Select(x => new OrderDto
        //        {
        //            Number = x.Number,
        //            Date = x.Date,
        //            Status = x.Status,
        //            DeliveryCost = x.DeliveryCost,
        //            CustomerId = x.Customer.Id,
        //            CustomersCard = x.Customer.Card,
        //        })
        //        .FirstOrDefault();
        //}

        public void AddOrderLine(Guid orderId, Guid productId, int quantity)
        {
            var order = _orderRepository.Get(orderId);
            var product = _productRepository.Get(productId);
            order.AddLine(product, quantity);

            _orderLineRepository.Add(new OrderLine(order,product,quantity));
        }

        public List<OrederLineDto> GetOrderLinesWithOrderId(Guid id)
        {
            return _orderLineRepository.AsQueryable()
                .Where(x => (x.Order.Id == id))
                .Select(x => new OrederLineDto
                {
                    Quantity = x.Quantity,
                    Cost = x.Cost,
                    Ready = x.Ready
                }).ToList();
        }

        public List<OrderDto> GetAcceptedOrInProgressOrders()
        {
            return _orderRepository.AsQueryable()
                .Where(x => (x.Status == OrderStatus.Accepted || x.Status == OrderStatus.InProgress))
                .Select(x => new OrderDto
                {
                    Number = x.Number,
                    Price = x.Price,
                    Date = x.Date,
                    Status = x.Status

                }).ToList();
        }

        public void Accept(Guid orderId)
        {
            decimal price = 0;
            var order = _orderRepository.Get(orderId);
            //var order = this.GetOrderById(orderId);
            var orderLines = GetOrderLinesWithOrderId(orderId);
            
            
            foreach (var orderLine in orderLines)
            {
                price += orderLine.Cost * orderLine.Quantity;
            }
            if (price <= 1500)
            {
                price = price + order.DeliveryCost;
            }
            if (order.Customer.Card  == true)
            {
                price = price * (decimal)0.75;
            }
            order.Price = price;
            order.Status = OrderStatus.Accepted;
        }
    }
}
