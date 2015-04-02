using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.UI.Actions 
{
    class ShowDetailedOrdersAction : IAction
    {
        private readonly DetailedOrderApi _detailedOrderApi;
        private readonly OrderApi _orderApi;

        public ShowDetailedOrdersAction(DetailedOrderApi detailedOrderApi, OrderApi orderApi)
        {
            _detailedOrderApi = detailedOrderApi;
            _orderApi = orderApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            context.Out.WriteLine(ConsoleColor.Green, "Show detailed information");
            var orders = _orderApi.GetOrders();

            var submenuOrder = new MenuBuilder()
                           .Title("SELECT ORDER: ")
                           .RunnableOnce();

            foreach (var order in orders)
            {
                var currentOrder = order;
                var temp = order.Number + " " + order.Date + " " + order.Status;
                submenuOrder.Item(temp, ctx => ShowDetailed(ctx, currentOrder.Id));
            }
            submenuOrder.GetMenu().Run();
        }

        private void ShowDetailed(ActionExecutionContext ctx, Guid orderid)
        {
            var detailedOrder = _detailedOrderApi.GetDetailedOrder(orderid);
            ctx.Out.WriteLine("Number/t Date/t Status");
            ctx.Out.WriteLine("{0}/t{1}/t{2}",detailedOrder.Number,detailedOrder.Date,detailedOrder.Status);
            ctx.Out.WriteLine("products:");
            var products = detailedOrder.Lines;
            ctx.Out.WriteLine("Name/t Quantity/t Ready");
            foreach (var product in products)
            {
                ctx.Out.WriteLine("{0}/t{1}/t{2}", product.ProductName, product.Quantity, (product.Ready) == true ? "ready" : "not ready");
            }

        } 
    }
}
