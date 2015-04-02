using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.Core.Domain
{
    public class PriceCalculator : Entity
    {
        public decimal CalculatePrice(Order order, List<OrederLineDto> orderLines)
        {
            decimal price = 0;
            foreach (var orderLine in orderLines)
            {
                price += orderLine.Cost * orderLine.Quantity;
            }
            if (price <= 1500)
            {
                price = price + order.DeliveryCost;
            }
            if (order.Customer.Card)
            {
                price = price * 0.75m;
            }
            return price;
        }
    }
}
