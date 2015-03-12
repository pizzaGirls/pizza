using System;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}