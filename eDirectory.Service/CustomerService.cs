using eDirectory.Domain;
using eDirectory.Naive;
using eDirectory.Service;
using eDirectory.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Service
{
    public class CustomerService
        : ICustomerService
    {
        public CustomerService()
        {
            this.Repository = new RepositoryLocatorCustomer();
        }

        public IRepositoryLocator Repository { get; set; }

        public CustomerDto CreateNewCustomer(CustomerDto customer)
        {
            Customer cs = Customer.Create(Repository, customer);
            return new CustomerDto
            {
                CustomerId = cs.Id,
                FirstName = cs.FirstName,
                LastName = cs.LastName,
                Telephone = cs.Telephone
            };
        }
    }
}