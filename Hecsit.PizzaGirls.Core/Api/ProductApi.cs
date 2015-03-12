using System.Collections.Generic;
using System.Linq;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class ProductApi
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductApi(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<ProductDto> GetProducts()
        {
            return _productsRepository.AsQueryable()
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    Description = x.Description
                })
                .ToList();
        }
    }
}