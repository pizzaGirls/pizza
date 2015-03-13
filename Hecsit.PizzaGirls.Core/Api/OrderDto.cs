using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    class OrderDto
    {
        public string Number { get; set; }
        private DateTime Date { get; set; }
        private OrderStatus Status { get; set; }
        private decimal DeliveryCost { set; get; }
        public List<OrederLineDto> OrederLines { get; set; }
        public string Phone { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
