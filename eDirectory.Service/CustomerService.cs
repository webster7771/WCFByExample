using eDirectory.Common.Dto;
using eDirectory.Common.ServiceContract;
using eDirectory.Domain;
using eDirectory.Naive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eDirectory.Common.Message;
using eDirectory.Data;

namespace eDirectory.Service
{
    public class CustomerService
        : ICustomerService
    {
        public CustomerService()
        {
            this.Repository = new RepositoryLocatorCustomerSql();
        }

        public IRepositoryLocator Repository { get; set; }

        public CustomerDto CreateNewCustomer(CustomerDto customer)
        {
            try
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
            catch(Exception ex)
            {
                CustomerDto response = new CustomerDto();
                response.Response.AddBusinessException(new BusinessException(BusinessExceptionEnum.Default, ex.Message));
                return response;
            }
        }

        public DtoResponse DeleteCustomer(long id)
        {
            try
            {
                Customer cs = Repository.GetById<Customer>(id);
                if (cs != null)
                {
                    Repository.Remove(cs);
                }
                else
                {
                    throw new ApplicationException("Not found (" + id.ToString() + ")");
                }
                return new DtoResponse();
            }
            catch (Exception ex)
            {
                DtoResponse response = new DtoResponse();
                response.Response.AddBusinessException(new BusinessException(BusinessExceptionEnum.Default, ex.Message));
                return response;
            }
        }

        public CustomerDtos FindAll()
        {
            try
            {
                CustomerDtos result = new CustomerDtos();
                result.Customers = new List<CustomerDto>();
                var entityItems = Repository.FindAll<Customer>();
                foreach (var item in entityItems)
                {
                    result.Customers.Add(new CustomerDto
                    {
                        CustomerId = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Telephone = item.Telephone
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                CustomerDtos response = new CustomerDtos();
                response.Response.AddBusinessException(new BusinessException(BusinessExceptionEnum.Default, ex.Message));
                return response;
            }
       }

        public CustomerDto GetById(long id)
        {
            try
            {
                var cs = Repository.GetById<Customer>(id);
                CustomerDto response = new CustomerDto();
                if (cs == null)
                {
                    response.Response.AddBusinessWarnings(new List<BusinessWarning>
                    {
                        new BusinessWarning(BusinessWarningEnum.Operational, "Customer with id " + id.ToString() + " not found.")
                    });
                }
                else
                {
                    response.CustomerId = cs.Id;
                    response.FirstName = cs.FirstName;
                    response.LastName = cs.LastName;
                    response.Telephone = cs.Telephone;
                }

                return response;
            }
            catch(Exception ex)
            {
                CustomerDto response = new CustomerDto();
                response.Response.AddBusinessException(new BusinessException(BusinessExceptionEnum.Default, ex.Message));
                return response;
            }
        }

        public CustomerDto UpdateCustomer(CustomerDto customer)
        {
            try
            {
                Repository.Update(customer);
                return customer;
            }
            catch(Exception ex)
            {
                CustomerDto response = new CustomerDto();
                response.Response.AddBusinessException(new BusinessException(BusinessExceptionEnum.Default, ex.Message));
                return response;
            }
        }        
    }
}