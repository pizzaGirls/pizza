using Castle.MicroKernel.Registration;
using Castle.Windsor;
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
            var container = new WindsorContainer();
            container.Install(new CoreInstaller(), new UIInstaller());

            var demoData = container.Resolve<DemoDataGenerator>();
            demoData.Generate();

            new MenuBuilder()
                    .WithActionFactory(new WindsorActionFactory(container))
                    .Title("Pizza Delivery")
                    .Repeatable()
                    .Item<ShowProductsAction>("Price-list ")
                    .Item<ShowCustomersAction>("Clients")
                    .Item<ShowOrdersAction>("Show orders")
                    .Item<ShowDetailedOrdersAction>("Show orders")
                    .Item<CreateOrderAction>("Create new order")
                    //.Item<SetAsInProgress>("Set as In Progress")
                    .Item<PreparedOrderLineAction>("Mark as prepared")
                    .Item<TakeIntoDelivery>("Take into delivery")
                    .Item<SetAsDelivered>("Set as delivered")
                    ////.Exit("Back")
                    ////.Submenu("Измененить статус")
                    ////.Exit("Back")
                    //.End()
                    .Exit("Close").GetMenu().Run();
        }
    }
}
