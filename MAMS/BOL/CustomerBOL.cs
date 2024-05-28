using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class CustomerBOL
    {
        private DAL.Customer_DAL _objCustomerDAL;
        public CustomerBOL()
        {
            _objCustomerDAL = new DAL.Customer_DAL();

        }
        public async Task<int> InsertCustomerInfo(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            int affectedRows = 0;
            if (customer != null)
            {
                affectedRows =await _objCustomerDAL.InsertCustomerInfo(customer, sqlConnectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public async Task<List<Customer>> GetCustomerInfo(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objCustomerDAL.GetCustomerInfo(customer, sqlConnectionFactory);
        }
        public async Task<Customer> GetSpecificCustomerInfo(Guid Id, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objCustomerDAL.GetSpecificCustomerInfo(Id, sqlConnectionFactory);
        }
        public async Task<int> CustomerEdit(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            int affectedRows = 0;
            if (customer != null)
            {
                affectedRows =await _objCustomerDAL.CustomerEdit(customer, sqlConnectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public async Task<int> DeleteCustomer(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objCustomerDAL.DeleteCustomer(customer, sqlConnectionFactory);
        }
    }
}
