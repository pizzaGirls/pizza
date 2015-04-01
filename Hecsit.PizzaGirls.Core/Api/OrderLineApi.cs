using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<OrederLineDto> GetOrderLinesWithOrderId(string number)
        {
            return _orderLineRepository.AsQueryable()
                .Where(x=>(x.Order.Number == number))
                .Select(x => new OrederLineDto
                {
                    Quantity = x.Quantity,
                    Cost = x.Cost,
                    Ready = x.Ready
                }).ToList();
        }
    }
}
