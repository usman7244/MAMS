using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOL
{
    public class CustomerBOL
    {
        private DAL.Customer_DAL _objCustomerDAL;
        public CustomerBOL()
        {
            _objCustomerDAL = new DAL.Customer_DAL();

        }
        public int InsertCustomerInfo(Customer customer)
        {
            int affectedRows = 0;
            if (customer != null)
            {
                affectedRows = _objCustomerDAL.InsertCustomerInfo(customer);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public List<Customer> GetCustomerInfo(Customer customer)
        {
            return _objCustomerDAL.GetCustomerInfo(customer);
        }
        public Customer GetSpecificCustomerInfo(Guid Id)
        {
            return _objCustomerDAL.GetSpecificCustomerInfo(Id);
        }
        public int CustomerEdit(Customer customer)
        {
            int affectedRows = 0;
            if (customer != null)
            {
                affectedRows = _objCustomerDAL.CustomerEdit(customer);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public int DeleteCustomer(Customer customer)
        {
            return _objCustomerDAL.DeleteCustomer(customer);
        }
    }
}
