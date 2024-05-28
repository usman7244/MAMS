using DAL.Sql;
using Dapper;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
        public async Task<int> InsertCustomerInfo(Customer customer, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spCreateCustomer] @Name, @Phone, @Email, @CNIC, @City, @Country, @CusType, @ComShopName, @ComAddress, @CreatedBy, @BranchId";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new
            {
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,
                CNIC = customer.CNIC,
                City = customer.City,
                Country = customer.Country,
                CusType = customer.CusType,
                ComShopName = customer.ComShopName,
                ComAddress = customer.ComAddress,
                CreatedBy = customer.CreatedBy,
                BranchId = customer.BranchId
            });

            return effectedRows;
        }

        public async Task<List<Customer>> GetCustomerInfo(Customer customer, ISqlConnectionFactory connectionFactory)
        {
            var customerList = new List<Customer>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetAllCustomerInfo]  @BranchId,@CreatedBy";

            var customers = await connection.QueryAsync<Customer>(SQLQuery, new { BranchId = customer.BranchId, CreatedBy = customer.CreatedBy });

            customerList = customers.ToList();

            return customerList;
        }

            


        public async Task<Customer> GetSpecificCustomerInfo(Guid Id, ISqlConnectionFactory connectionFactory)
        {
            Customer customer = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCustomerInfo] @UID";

            customer = await connection.QueryFirstOrDefaultAsync<Customer>(SQLQuery, new { UID = Id });

            return customer;
        }


       
        public async Task<int> CustomerEdit(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            int affectedRows = 0;
            await using var connection = sqlConnectionFactory.CreateConnection();

            string SQLQuery = @"UPDATE [dbo].[CustomerMgt.CustomerInfo]
                        SET [Name] = @Name,
                            [Phone] = @Phone,
                            [Email] = @Email,
                            [CNIC] = @CNIC,
                            [City] = @City,
                            [Country] = @Country,
                            [CusType] = @CusType,
                            [ComShopName] = @ComShopName,
                            [ComAddress] = @ComAddress,
                            [ModifiedBy] = @ModifiedBy,
                            [ModifiedDate] = GETUTCDATE()
                        WHERE [UID] = @UID";

            affectedRows = await connection.ExecuteAsync(SQLQuery, customer);

            return affectedRows;
        }

        public async Task<int> DeleteCustomer(Customer customer, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteCustomerInfo] @UID, @ModifiedBy";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = customer.UID, ModifiedBy = customer.ModifiedBy });

            return effectedRows;
        }


       
    }
}
