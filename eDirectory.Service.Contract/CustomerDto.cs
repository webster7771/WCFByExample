using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Service.Contract
{
    public class CustomerDto
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
    }
}