using eDirectory.Common.Dto;
using eDirectory.Common.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<ICustomerService, CustomerDtos> getAllCustomer = (service) =>
             {
                 return service.FindAll();
             };

            var result = new WcfCommandDispatcher().ExecuteCommand(getAllCustomer);
            foreach(var item in result.Customers)
            {
                System.Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", item.CustomerId, item.FirstName, item.LastName, item.Telephone));
            }

            System.Console.ReadLine();
        }
    }
}