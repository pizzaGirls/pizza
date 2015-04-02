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
        private readonly IRepository<Order> _orderRepository;

        public DetailedOrderApi(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DetailedOrderDto GetDetailedOrder(Guid id)
        {
            return _orderRepository.AsQueryable()
                .Where(x=>x.Id == id)
                .Select(x => new DetailedOrderDto
                {
                    Id = x.Id,
                    Number = x.Number,
                    Date = x.Date,
                    DeliveryCost = x.DeliveryCost,
                    Status = x.Status,
                    Price = x.Price,
                    CustomerAddress = x.Customer.Address,
                    Lines = x.OrderLines.Select(l => new OrederLineDto
                    {
                        Id = l.Id,
                        Cost = l.Cost,
                        ProductName = l.Product.Name,
                        Quantity = l.Quantity,
                        Ready = l.Ready
                    })
                    .ToList()
                }).FirstOrDefault();
        }


    }
}
