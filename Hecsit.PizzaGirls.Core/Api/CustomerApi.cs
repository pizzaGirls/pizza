using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core.DataAccess;
using Hecsit.PizzaGirls.Core.Domain;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class CustomerApi
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerApi(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerDto> GetCustomers()
        {
            return _customerRepository.AsQueryable()
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Address = x.Address,
                    Phone = x.Phone,
                    Card = x.Card
                }).ToList();
        }

        public Guid AddNewCustomer(CustomerDto customerDto)
        {          
            var customer = new Customer(customerDto.Address, customerDto.Phone, customerDto.Card);
            _customerRepository.Add(customer);
            return customer.Id;
        }
    }
}