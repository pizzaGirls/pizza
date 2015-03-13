using System;
using Feonufry.CUI.Actions;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class ShowCustomersAction : IAction
    {
        private readonly CustomerApi _customerApi;

        public ShowCustomersAction(CustomerApi customerApi)
        {
            _customerApi = customerApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var customers = _customerApi.GetCustomers();

            context.Out.WriteLine(ConsoleColor.Yellow, "CUSTOMERS");
            context.Out.WriteLine("Адрес \t\t\t Телефон \t\t Карта");
            foreach (var customer in customers)
            {
                context.Out.WriteLine("{0}\t\t {1}\t  {2}", customer.Address, customer.Phone, (customer.Card)==true?"есть":"нет");
            }
        }
    }
}