using Feonufry.CUI.Menu.Builders;
using Hecsit.PizzaGirls.Core;
using Hecsit.PizzaGirls.Core.Api;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;
using Hecsit.PizzaGirls.UI.Actions;

namespace Hecsit.PizzaGirls.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var customersRepository = new MemoryRepository<Customer>();
            var productsRepository = new MemoryRepository<Product>();
            var demoData = new DemoDataGenerator(customersRepository, productsRepository);

            var productsApi = new ProductApi(productsRepository);
            var customerApi = new CustomerApi(customersRepository);

            demoData.Generate();

            new MenuBuilder()
                    .Title("Pizza Delivery")
                    .Repeatable()
                    .Item("Прайс-листик ", new ShowProductsAction(productsApi))
                    .Item("Клиентики ", new ShowCustomersAction(customerApi))
                    .Exit("Назад")
                    .Submenu("Измененить статус")
                    .Exit("Назад")
                    .End()
                    .Exit("Закрыть").GetMenu().Run();
        }
    }
}
