
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hecsit.PizzaGirls.Core.Api;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;
namespace Hecsit.PizzaGirls.Core
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>))
                .ImplementedBy(typeof (MemoryRepository<>)));

            container.Register(Component.For<PriceCalculator>());
            container.Register(Component.For<DemoDataGenerator>());

            container.Register(Classes.FromThisAssembly()
                .InSameNamespaceAs<CustomerApi>()
                .If(t => t.Name.EndsWith("Api"))
                .WithServiceSelf());
        }
    }
}
