using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class CreateCustomerAction : IAction
    {
        private readonly CustomerApi _customerApi;
        public CreateCustomerAction(CustomerApi customerApi)
        {
            _customerApi = customerApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            CustomerDto customer = new CustomerDto();
            context.Out.WriteLine(ConsoleColor.Yellow, "NEW CUSTOMER");
            context.Out.WriteLine("Enter address");...
            _customerApi.AddNewCustomer(customer);
        }
    }
}
