using System;
using Feonufry.CUI.Actions;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class ShowProductsAction : IAction
    {
        private readonly ProductApi _productApi;

        public ShowProductsAction(ProductApi productApi)
        {
            _productApi = productApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var products = _productApi.GetProducts();
            
            context.Out.WriteLine(ConsoleColor.Green, "PRODUCTS:");
            context.Out.WriteLine("Название \t\t Цена \t\t\t Состав");
            foreach (var product in products)
            {
                context.Out.WriteLine("{0} \t\t {1:N2} \t\t {2}", product.Name, product.UnitPrice, product.Description);
            }
        }
    }
}