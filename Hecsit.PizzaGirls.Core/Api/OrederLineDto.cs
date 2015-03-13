
namespace Hecsit.PizzaGirls.Core.Api
{
    class OrederLineDto
    {
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public bool Ready { get; set; }
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
