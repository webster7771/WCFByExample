using eDirectory.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eDirectory.Common.Dto
{
    public class CustomerDto
        : DtoBase
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
    }
}