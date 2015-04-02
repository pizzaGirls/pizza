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
        //private readonly OrderDto _orderDto;
        private readonly OrderLineApi _orderLineApi;

        public PreparedOrderLineAction(OrderApi orderApi, OrderLineApi orderLineApi)
        {
            _orderLineApi = orderLineApi;
            _orderApi = orderApi;
           // _orderDto= new OrderDto();
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
                submenuOrder.Item(temp, ctx => SelectNotReadyOrderLineFromOrder(ctx, currentOrder));
            }

            submenuOrder.GetMenu().Run();

        }

        private void SelectNotReadyOrderLineFromOrder(ActionExecutionContext context, OrderDto orderDto)
        {
            var submenuOrder = new MenuBuilder()
               .Title("SELECT ORDERLINE: ")
               .RunnableOnce();

            var orderLines = _orderLineApi.GetNotReadyOrderLinesWithOrderId(orderDto.Number);

            foreach (var orderLine in orderLines)
            {
                var currentOrderLine = orderLine;
                var temp =currentOrderLine.ProductName +  " " + currentOrderLine.Quantity +" "+ currentOrderLine.Cost;

                submenuOrder.Item(temp, ctx => SetOrderLineStatusAsReady(ctx, currentOrderLine.Id, orderDto.Id));
            }

            submenuOrder.GetMenu().Run();
        }

        private void SetOrderLineStatusAsReady(ActionExecutionContext context, Guid orderLineId, Guid orderId)
        {
            _orderLineApi.Prepared(orderLineId);
            SetOrderStatusAsInProgressOrReadyToDelivery(orderId);
        }

        private void SetOrderStatusAsInProgressOrReadyToDelivery(Guid orderId)
        {
            var orderLines = _orderApi.GetOrderLinesWithOrderId(orderId);
            bool flag = false;
            foreach (var orderLine in orderLines)
            {
                if (orderLine.Ready == false)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                _orderApi.InProgress(orderId);
            }
            else
            {
                _orderApi.ReadyToDelivery(orderId);
            }
        }
    }
}
