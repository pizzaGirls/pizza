using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class CreateOrderAction : IAction
    {
        private readonly OrderApi _orderApi;
        private readonly CustomerApi _customerApi;

        public CreateOrderAction(OrderApi orderApi, CustomerApi customerApi)
        {
            _orderApi = orderApi;
            _customerApi = customerApi;
        }
        public void Perform(ActionExecutionContext context)
        {
            //OrderDto orderDto = new OrderDto();
            context.Out.WriteLine(ConsoleColor.Yellow, "NEW ORDER");
            context.Out.WriteLine("Enter number of order");
            string number = context.In.ReadLine();
            context.Out.WriteLine(ConsoleColor.Green, "CREATE NEW CUSTOMER");
            CreateNewCustomer(context);
            Order orderDto = new Order(number, _customerApi.GetLastCustomer());
        }

        public void CreateNewCustomer(ActionExecutionContext context)
        {
            CustomerDto customer = new CustomerDto();
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
            _customerApi.AddNewCustomer(customer);
        }
    }
}
