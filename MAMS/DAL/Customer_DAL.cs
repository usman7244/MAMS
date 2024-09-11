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
        private List<Customer> _customers;
        private Customer _customer;

        public Customer_DAL()
        {
            _customers = new List<Customer>();
            _customer = new Customer();
        }


        public async Task<(Guid? CustomerUID, int AffectedRows)> InsertCustomerInfo(Customer customer, ISqlConnectionFactory connectionFactory)
        {
            Guid? customerUid;
            int affectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spCreateCustomer] @Name, @Phone, @Email, @CNIC, @City, @Country, @CusType, @ComShopName, @ComAddress, @CreatedBy, @BranchId, @CustomerUID OUTPUT, @AffectedRows OUTPUT";

            var parameters = new DynamicParameters();
            parameters.Add("Name", customer.Name);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Email", customer.Email);
            parameters.Add("CNIC", customer.CNIC);
            parameters.Add("City", customer.City);
            parameters.Add("Country", customer.Country);
            parameters.Add("CusType", customer.CusType);
            parameters.Add("ComShopName", customer.ComShopName);
            parameters.Add("ComAddress", customer.ComAddress);
            parameters.Add("CreatedBy", customer.CreatedBy);
            parameters.Add("BranchId", customer.BranchId);
            parameters.Add("CustomerUID", dbType: DbType.Guid, direction: ParameterDirection.Output);
            parameters.Add("AffectedRows", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(SQLQuery, parameters);

            customerUid = parameters.Get<Guid?>("CustomerUID");
            affectedRows = parameters.Get<int>("AffectedRows");

            return (customerUid, affectedRows);
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



        //public async Task<int> CustomerEdit(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        //{
        //    int affectedRows = 0;
        //    await using var connection = sqlConnectionFactory.CreateConnection();

        //    string SQLQuery = @"UPDATE [dbo].[CustomerMgt.CustomerInfo]
        //                SET [Name] = @Name,
        //                    [Phone] = @Phone,
        //                    [Email] = @Email,
        //                    [CNIC] = @CNIC,
        //                    [City] = @City,
        //                    [Country] = @Country,
        //                    [CusType] = @CusType,
        //                    [ComShopName] = @ComShopName,
        //                    [ComAddress] = @ComAddress,
        //                    [ModifiedBy] = @ModifiedBy,
        //                    [ModifiedDate] = GETUTCDATE()
        //                WHERE [UID] = @UID";

        //    affectedRows = await connection.ExecuteAsync(SQLQuery, customer);

        //    return affectedRows;
        //}
        public async Task<(Guid? CustomerUID, int AffectedRows)> CustomerEdit(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            Guid? customerUid = null;
            int affectedRows = 0;

            await using var connection = sqlConnectionFactory.CreateConnection();

            string SQLQuery = @"
        EXEC [dbo].[spUpdateCustomer]
            @Name,
            @Phone,
            @Email,
            @CNIC,
            @City,
            @Country,
            @CusType,
            @ComShopName,
            @ComAddress,
            @ModifiedBy,
            @UID,
            @CustomerUID OUTPUT,
            @AffectedRows OUTPUT";

            var parameters = new DynamicParameters();
            parameters.Add("Name", customer.Name);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Email", customer.Email);
            parameters.Add("CNIC", customer.CNIC);
            parameters.Add("City", customer.City);
            parameters.Add("Country", customer.Country);
            parameters.Add("CusType", customer.CusType);
            parameters.Add("ComShopName", customer.ComShopName);
            parameters.Add("ComAddress", customer.ComAddress);
            parameters.Add("ModifiedBy", customer.ModifiedBy);
            parameters.Add("UID", customer.UID);
            parameters.Add("CustomerUID", dbType: DbType.Guid, direction: ParameterDirection.Output);
            parameters.Add("AffectedRows", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(SQLQuery, parameters);

            customerUid = parameters.Get<Guid?>("CustomerUID");
            affectedRows = parameters.Get<int>("AffectedRows");

            return (customerUid, affectedRows);
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
