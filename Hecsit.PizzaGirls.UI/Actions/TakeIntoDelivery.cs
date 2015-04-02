using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Hecsit.PizzaGirls.Core.Api;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.UI.Actions
{
     public class TakeIntoDelivery: IAction
     {
         private readonly OrderApi _orderApi;

         public TakeIntoDelivery(OrderApi orderApi)
         {
             _orderApi = orderApi;
         }

         public void Perform(ActionExecutionContext context)
         {
             context.Out.WriteLine(ConsoleColor.Green, "Mark Order as Delivery");
             var orders = _orderApi.GetOrdersWithStatus(OrderStatus.ReadyToDelivery);

             var submenuOrder = new MenuBuilder()
                            .Title("SELECT ORDER: ")
                            .RunnableOnce();

             foreach (var order in orders)
             {
                 var currentOrder = order;
                 var temp = order.Number + " " + order.Date + " " + order.Status;
                 submenuOrder.Item(temp, ctx => SetAsDelivery(ctx, currentOrder.Id));
             }
             submenuOrder.GetMenu().Run();
         }

         private void SetAsDelivery(ActionExecutionContext ctx, Guid orderid)
         {
             _orderApi.StartDelivery(orderid);
             ctx.Cancel();
         }
     }
}
