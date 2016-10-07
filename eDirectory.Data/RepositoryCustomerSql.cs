using eDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eDirectory.Data
{
    public class RepositoryCustomerSql
        : IRepository<Customer>
    {
        public IQueryable<Customer> FindAll()
        {
            using (var cn = CreateConnection())
            {
                return cn.Query<Customer>("SELECT * FROM Customer").AsQueryable();
            }
        }

        public Customer GetById(long id)
        {
            using (var cn = CreateConnection())
            {
                return cn.Query<Customer>("SELECT * FROM Customer WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(Customer e)
        {
            using (var cn = CreateConnection())
            {
                cn.Execute("DELETE FROM Customer WHERE Id = @Id", new { Id = e.Id });
            }
        }

        public Customer Save(Customer e)
        {
            using (var cn = CreateConnection())
            {
                var id = Convert.ToInt32(cn.ExecuteScalar("INSERT INTO Customer(FirstName,LastName,Telephone) VALUES (@FirstName,@LastName,@Telephone);SELECT @@identity;", e));
                SetId(e, id);
                return e;
            }
        }

        public void Update(Customer e)
        {
            using (var cn = CreateConnection())
            {
                cn.Execute("UPDATE Customer SET FirstName = @FirstNamae, LastName = @LastName, Telephone=@Telephone WHERE Id = @Id", e);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["eDirectory"].ConnectionString);
        }

        private void SetId(Customer e, int id)
        {
            var propInfo = e.GetType().GetProperty("Id");
            if (propInfo != null)
            {
                var methodInfo = propInfo.GetSetMethod(true);
                if(methodInfo!=null)
                {
                    methodInfo.Invoke(e, new object[1] { id });
                }
            }
        }
    }
}