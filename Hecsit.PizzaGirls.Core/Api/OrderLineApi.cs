using System;
using System.Collections.Generic;
using System.Linq;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class OrderLineApi
    {
        private readonly IRepository<OrderLine> _orderLineRepository;

        public OrderLineApi(IRepository<OrderLine> orderLineRepository)
        {
            _orderLineRepository = orderLineRepository;
        }
        
        public List<OrederLineDto> GetNotReadyOrderLinesWithOrderId(string number)
        {
            return _orderLineRepository.AsQueryable()
                .Where(x => x.Order.Number == number && !x.Ready)
                .Select(x => new OrederLineDto
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Cost = x.Cost,
                    Ready = x.Ready,
                    ProductName = x.Product.Name
                }).ToList();
        }

        public void CompleteLine(Guid orderLineId)
        {
            var orderLine = _orderLineRepository.Get(orderLineId);
            orderLine.Ready = true;
        }
    }
}
