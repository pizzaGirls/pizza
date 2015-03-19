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

            var orderRepository = new MemoryRepository<Order>();
            var orderLinesRepository = new MemoryRepository<OrderLine>();

            var productsApi = new ProductApi(productsRepository);
            var customerApi = new CustomerApi(customersRepository);
            var orderApi = new OrderApi(customersRepository, orderRepository, productsRepository);

            demoData.Generate();

            new MenuBuilder()
                    .Title("Pizza Delivery")
                    .Repeatable()
                    .Item("Price-list ", new ShowProductsAction(productsApi))
                    .Item("Clients", new ShowCustomersAction(customerApi))
                    .Item("Show orders", new ShowOrdersAction(orderApi))
                    //.Item("Create New Customer", new CreateCustomerAction(customerApi))
                    .Item("Create new order", new CreateOrderAction(orderApi,customerApi,productsApi))
                    
                    ////.Exit("Back")
                    ////.Submenu("Измененить статус")
                    ////.Exit("Back")
                    //.End()
                    .Exit("Close").GetMenu().Run();
        }
    }
}
