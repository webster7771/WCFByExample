using eDirectory.Domain;
using eDirectory.Naive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace eDirectory.Naive
{
    public class RepositoryCustomer
        : RepositoryEntityStore<Customer>
    {
        public override void Remove(Customer e)
        {
            RepositoryMap.Remove(e.Id);
        }

        public override Customer Save(Customer e)
        {
            SetNewId(e);
            RepositoryMap.Add(e.Id, e);
            return e;
        }

        private void SetNewId(Customer instance)
        {
            PropertyInfo pi = instance.GetType().GetProperty("Id");
            if(pi != null)
            {
                pi.GetSetMethod(true).Invoke(instance, new Object[1] { RepositoryMap.Values.Count() + 1 });
            }
        }

        public override void Update(Customer e)
        {
            RepositoryMap.Remove(e.Id);
            RepositoryMap.Add(e.Id, e);
        }
    }
}