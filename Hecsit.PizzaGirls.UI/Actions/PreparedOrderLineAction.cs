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
    public class PreparedOrderLineAction : IAction
    {
        private readonly OrderApi _orderApi;
        private readonly OrderDto _orderDto;
        private readonly OrderLineApi _orderLineApi;

        public PreparedOrderLineAction(OrderApi orderApi, OrderLineApi orderLineApi)
        {
            _orderLineApi = orderLineApi;
            _orderApi = orderApi;
            _orderDto= new OrderDto();
        }

        public void Perform(ActionExecutionContext context)
        {
            context.Out.WriteLine(ConsoleColor.Green, "Mark Order Line as prepared");
            var orders = _orderApi.GetAcceptedOrInProgressOrders();

            var submenuOrder = new MenuBuilder()
               .Title("SELECT ORDER: ")
               .RunnableOnce();

            foreach (var order in orders)
            {
                var currentOrder = order;
                var temp = order.Number + " " + order.Date + " " + order.Status;
                submenuOrder.Item(temp, ctx => SelectOrderLineFromOrder(ctx, currentOrder));
            }

            submenuOrder.GetMenu().Run();

        }

        private void SelectOrderLineFromOrder(ActionExecutionContext context, OrderDto orderDto)
        {
            var submenuOrder = new MenuBuilder()
               .Title("SELECT ORDERLINE: ")
               .RunnableOnce();

            var orderLines = _orderLineApi.GetOrderLinesWithOrderId(orderDto.Number);

            foreach (var orderLine in orderLines)
            {
                var currentOrderLine = orderLine;
                var temp = orderLine.Cost + " " + orderLine.Quantity;
                submenuOrder.Item(temp, ctx => SetOrderLineStatusAsReady(ctx, currentOrderLine));
            }

            submenuOrder.GetMenu().Run();
        }

        private void SetOrderLineStatusAsReady(ActionExecutionContext context, OrederLineDto orderLineDto)
        {

        }
    }
}
