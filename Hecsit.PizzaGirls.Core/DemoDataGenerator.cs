using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core
{
    public class DemoDataGenerator
    {
        private readonly IRepository<Customer> _customersRepository; 
        private readonly IRepository<Product> _productsRepository;

        public DemoDataGenerator(IRepository<Customer> customersRepository, IRepository<Product> productsRepository)
        {
            _customersRepository = customersRepository;
            _productsRepository = productsRepository;
        }

        public void Generate()
        {
            
        }
    }
}