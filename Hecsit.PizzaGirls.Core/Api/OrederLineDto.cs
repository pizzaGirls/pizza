
using System;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class OrederLineDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public bool Ready { get; set; }
       // public OrderDto Order { get; set; }
        public string ProductName { get; set; }
    }
}
