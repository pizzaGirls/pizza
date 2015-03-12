using Hecsit.PizzaGirls.Core.DataAccess;
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
            _customersRepository.Add(new Customer("Kirova street 43,5", "53-98-77", true));
            _customersRepository.Add(new Customer("St.Razina 45,7", "8-953-369-77-22", false));
            _productsRepository.Add(new Product("Marggaritta", 350, "tomato, cheese, sause "));
            _productsRepository.Add(new Product("Peperoni", 400, "peperoni, cheese, onion"));
            _productsRepository.Add(new Product("Hawaiian", 500, "pineapple, ham, cheese, onion, chiken"));
        }
    }
}