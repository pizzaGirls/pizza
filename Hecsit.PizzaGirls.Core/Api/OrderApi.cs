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
        private readonly IRepository<OrderLine> _orderLineRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly PriceCalculator _priceCalculator;
        //private readonly IRepository<OrderLines> _orderLinesRepository;

        public OrderApi(IRepository<Customer> customerRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository, IRepository<OrderLine> orderlineRepository, PriceCalculator priceCalculator)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderLineRepository = orderlineRepository;
            _priceCalculator = priceCalculator;
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.AsQueryable()
                .Select(x => new OrderDto
                {
                    Id = x.Id,
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
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Cost = x.Cost,
                    Ready = x.Ready,
                    ProductName = x.Product.Name,
                }).ToList();
        }

        public List<OrderDto> GetOrdersWithStatus(OrderStatus status)
        {
            return _orderRepository.AsQueryable()
                .Where(x => (x.Status == status))
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Price = x.Price,
                    Date = x.Date,
                    Status = x.Status

                }).ToList();
        }

        
        public void Accept(Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            var orderLines = GetOrderLinesWithOrderId(orderId);
            order.Price = _priceCalculator.CalculatePrice(order, orderLines);
           
            order.Status = OrderStatus.Accepted;
        }

        public void StartProgress(Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.Status = OrderStatus.InProgress;
        }

        public void TransferToDelivery(Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.Status = OrderStatus.ReadyToDelivery;
        }

        public void StartDelivery(Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.Status = OrderStatus.Delivery;
        }

        public void Delivered(Guid orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.Status = OrderStatus.Delivered;
        }

    }
}
