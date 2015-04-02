using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class DetailedOrderDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public decimal DeliveryCost { set; get; }
        public decimal Price { get; set; }
        public string CustomerAddress { get; set; }
        public List<OrederLineDto> Lines { get; set; }

    
    }
}
