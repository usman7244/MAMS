using MAMS_Models.Extenions;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Customer_DAL
    {
        private ConnectionLayer _connection;
        private List<Customer> _customers;
        private Customer _customer;

        public Customer_DAL()
        {
            _connection = new ConnectionLayer();
            _customers = new List<Customer>();
            _customer = new Customer();
        }

        public int InsertCustomerInfo(Customer customer)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spCreateCustomer";
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@CNIC", customer.CNIC);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@CusType", customer.CusType);
                    cmd.Parameters.AddWithValue("@ComShopName", customer.ComShopName);
                    cmd.Parameters.AddWithValue("@ComAddress", customer.ComAddress);
                    cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                    cmd.Parameters.AddWithValue("@BranchId", customer.BranchId);

                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }
        public List<Customer> GetCustomerInfo(Customer customer)
        {
            _customers = new List<Customer>();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetAllCustomerInfo";
                    cmd.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                    cmd.Parameters.AddWithValue("@BranchId", customer.BranchId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _customer = new Customer();
                            _customer.UID =reader[0].ToString().ToGuid();
                            _customer.Name = reader[1].ToString();
                            _customer.Phone = reader[2].ToString();
                            _customer.Email = reader[3].ToString();
                            _customer.CNIC = reader[4].ToString();
                            _customer.City = reader[5].ToString();
                            _customer.Country = reader[6].ToString();
                            _customer.CusType = reader[7].ToString();
                            _customer.ComShopName = reader[8].ToString();
                            _customer.ComAddress = reader[9].ToString();  
                            _customer.CreatedDate = Convert.ToDateTime(reader[11].ToString());
                            _customer.UserName = reader[10].ToString();
                            _customers.Add(_customer);
                        }
                    }
                    reader.Close();
                }
            }
            _connection.ConnectionClose();
            return _customers;
        }
        public Customer GetSpecificCustomerInfo(Guid Id)
        {
            _customer = new Customer();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetCustomerInfo";
                    cmd.Parameters.AddWithValue("@UID", Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _customer.UID = reader[0].ToString().ToGuid();
                            _customer.Name = reader[1].ToString();
                            _customer.Phone = reader[2].ToString();
                            _customer.Email = reader[3].ToString();
                            _customer.CNIC = reader[4].ToString();
                            _customer.City = reader[5].ToString();
                            _customer.Country = reader[6].ToString();
                            _customer.CusType = reader[7].ToString();
                            _customer.ComShopName = reader[8].ToString();
                            _customer.ComAddress = reader[9].ToString(); 
                            _customer.CreatedBy = reader[10].ToString().ToGuid(); 
                            _customer.CreatedDate =Convert.ToDateTime(reader[11].ToString()); 
                        }
                    }
                    reader.Close();
                }
            }
            _connection.ConnectionClose();
            return _customer;
        }
        public int CustomerEdit(Customer customer)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spUpdateCustomerInfo";
                    cmd.Parameters.AddWithValue("@UID", customer.UID);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@CNIC", customer.CNIC);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@CusType", customer.CusType);
                    cmd.Parameters.AddWithValue("@ComShopName", customer.ComShopName);
                    cmd.Parameters.AddWithValue("@ComAddress", customer.ComAddress);
                    cmd.Parameters.AddWithValue("@ModifiedBy", customer.ModifiedBy);

                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }
        public int DeleteCustomer(Customer customer)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spDeleteCustomerInfo";
                    cmd.Parameters.AddWithValue("@UID", customer.UID);
                    cmd.Parameters.AddWithValue("@ModifiedBy", customer.ModifiedBy);
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }
    }
}
