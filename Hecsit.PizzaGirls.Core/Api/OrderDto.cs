using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class OrderDto
    {
        public string Number { get; set; }
        public  DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public decimal DeliveryCost { set; get; }
       // public List<OrederLineDto> OrederLines { get; set; }

        //public CustomerDto Customer { get; set; }
        public bool CustomersCard { get; set; }
        public Guid CustomerId { get; set; }
       // public List<Guid> OrderLinesIds { get; set; }
    }
}
