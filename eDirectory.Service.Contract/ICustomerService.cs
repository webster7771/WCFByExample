using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace eDirectory.Service.Contract
{
    [ServiceContract(Namespace ="http://oetawan.com/wcfbyexample/customerservices/")]
    public interface ICustomerService
    {
        [OperationContract]
        CustomerDto CreateNewCustomer(CustomerDto customer);
    }
}
