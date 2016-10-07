using eDirectory.Common.Dto;
using eDirectory.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Test
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void CreateCustomer()
        {
            var service = new CustomerService();
            var dto = new CustomerDto
            {
                FirstName = "Joe",
                LastName = "Bloggs",
                Telephone = "9999-8888"
            };

            var customer = service.CreateNewCustomer(dto);
            Assert.IsFalse(customer.CustomerId == 0, "Customer Id should have been updated");
            Assert.AreSame(customer.FirstName, dto.FirstName, "First Name are differenct");
        }
    }
}