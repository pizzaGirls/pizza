using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Hecsit.PizzaGirls.Core.Api;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class CreateOrderAction : IAction
    {
        private readonly OrderApi _orderApi;
        private readonly OrderLineApi _orderLineApi;
        private readonly CustomerApi _customerApi;
        private readonly ProductApi _productApi;

        public CreateOrderAction(OrderApi orderApi, CustomerApi customerApi, ProductApi productApi, OrderLineApi orderLineApi)
        {
            _orderApi = orderApi;
            _customerApi = customerApi;
            _productApi = productApi;
            _orderLineApi = orderLineApi;
        }
        public void Perform(ActionExecutionContext context)
        {
            //OrderDto orderDto = new OrderDto();
            context.Out.WriteLine(ConsoleColor.Yellow, "NEW ORDER");
            context.Out.WriteLine("Enter number of order");
            string number = context.In.ReadLine();
            context.Out.WriteLine(ConsoleColor.Green, "CREATE NEW CUSTOMER");
            var customerId = CreateNewCustomer(context);
            context.Out.WriteLine("Enter price of delivery");
            string temp = context.In.ReadLine();
            decimal price;
            while (!Decimal.TryParse(temp, out price))
            {
                context.Out.WriteLine("Enter correct price of delivery");
                temp = context.In.ReadLine();
            }
            context.Out.WriteLine("Enter cost of delivery");
            var orderId = _orderApi.AddNewOrder(number, customerId, price);

            context.Out.WriteLine(ConsoleColor.Green, "CHOOSE PRODUCTS");
            var products = _productApi.GetProducts();
            var builder = new MenuBuilder()
                .Repeatable();
            foreach (var product in products)
            {
                var currentProduct = product;
                builder.Item(product.Name, ctx => AddOrderLine(orderId, currentProduct.Id, context));
            }
            builder.Item("Accept", ctx => Accept(ctx, orderId))
                .GetMenu()
                .Run();
        }

        private void Accept(ActionExecutionContext ctx, Guid orderId)
        {
            _orderApi.Accept(orderId);
            ctx.Cancel();
        }

        private void AddOrderLine(Guid orderId, Guid productId, ActionExecutionContext context)
        {
            context.Out.WriteLine("Enter amount of products");
            var temp = context.In.ReadLine();
            int quantity;
            while (!Int32.TryParse(temp, out quantity))
            {
                context.Out.WriteLine("Enter correct amount of products");
                temp = context.In.ReadLine();
            }
            _orderApi.AddOrderLine(orderId, productId, quantity);
        }

        public Guid CreateNewCustomer(ActionExecutionContext context)
        {
            var customer = new CustomerDto();
            context.Out.WriteLine(ConsoleColor.Yellow, "NEW CUSTOMER");
            context.Out.WriteLine("Enter address");
            var adress = context.In.ReadLine();
            context.Out.WriteLine("Enter phone");
            var phone = context.In.ReadLine();
            context.Out.WriteLine("Does customer have a card(y/n):");
            var temp = context.In.ReadLine();
            if (!temp.Equals("y") && !temp.Equals("n"))
            {
                context.Out.WriteLine("Does customer have a card(y/n):");
                temp = context.In.ReadLine();
            }
            bool card = temp.Equals("y") ? true : false;
            customer.Address = adress;
            customer.Phone = phone;
            customer.Card = card;
            Guid customerId = _customerApi.AddNewCustomer(customer);
            return customerId;
        }
    }
}
