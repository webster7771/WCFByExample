using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eDirectory.Naive;
using eDirectory.Service.Contract;
using eDirectory.Domain;

namespace eDirectory.Test
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CreateCustomer()
        {
            var repository = new RepositoryLocatorCustomer();
            var dto = new CustomerDto
            {
                FirstName = "Joe",
                LastName = "Bloggs",
                Telephone = "9999-8888"
            };

            var customer = Customer.Create(repository, dto);
            Assert.IsFalse(customer.Id == 0, "Customer Id should have been updated");
            Assert.AreSame(customer.FirstName, "Joe", "First Name are differenct");
        }
    }
}