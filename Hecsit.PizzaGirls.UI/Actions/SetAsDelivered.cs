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
    public class SetAsDelivered : IAction
    {
        private readonly OrderApi _orderApi;

         public SetAsDelivered(OrderApi orderApi)
         {
             _orderApi = orderApi;
         }

         public void Perform(ActionExecutionContext context)
         {
             context.Out.WriteLine(ConsoleColor.Green, "Mark Order as Delivered");
             var orders = _orderApi.GetDeliveryOrders();

             var submenuOrder = new MenuBuilder()
                            .Title("SELECT ORDER: ")
                            .RunnableOnce();

             foreach (var order in orders)
             {
                 var currentOrder = order;
                 var temp = order.Number + " " + order.Date + " " + order.Status;
                 submenuOrder.Item(temp, ctx => SetOrderAsDelivered(ctx, currentOrder.Id));
             }
             submenuOrder.GetMenu().Run();
         }

        private void SetOrderAsDelivered(ActionExecutionContext ctx, Guid orderid)
         {
             _orderApi.Delivered(orderid);
             ctx.Cancel();
         }
    }
}
