using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class ShowOrdersAction : IAction
    {
        private readonly OrderApi _orderApi;

        public ShowOrdersAction(OrderApi orderApi)
        {
            _orderApi = orderApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var orders = _orderApi.GetOrders();

            context.Out.WriteLine(ConsoleColor.Yellow, "ORDERS");
            context.Out.WriteLine("Number \t\t\t Data \t\t Status  ");
            foreach (var order in orders)
            {
                context.Out.WriteLine("{0}\t\t {1}\t  {2}", order.Number, order.Date, order.Status);
            }
        }
    }
}
