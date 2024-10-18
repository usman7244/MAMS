using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class CreditCashDAL
    {
       

        public async Task<List<Credit>> GetAllCreditInfo(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            var creditList = new List<Credit>();

            await using var connection = connectionFactory.CreateConnection();

            // Assuming 'CashMgt.Credit' is the name of the table
            //string SQLQuery = "SELECT * FROM [dbo].[CashMgt.Credit] WHERE BranchId = @BranchId AND CreatedBy = @CreatedBy";
            string SQLQuery = "EXEC [dbo].[spGetCreditInfo] @BranchId, @CreatedBy";

            var credits = await connection.QueryAsync<Credit>(SQLQuery, new { BranchId = credit.BranchId, CreatedBy = credit.CreatedBy });

            creditList = credits.ToList();

            return creditList;
        }
        public async Task<(int CreditUID, int AffectedRows)> CreditAdd(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            string _credit = JsonConvert.SerializeObject(credit);  

            await using var connection = connectionFactory.CreateConnection();  
             
            string SQLQuery = "EXEC [dbo].[spCreateCredit] @JsonStringCredit";

             
            var parameters = new { JsonStringCredit = _credit };

         
            var result = await connection.QueryFirstOrDefaultAsync<(int? CreditUID, int AffectedRows)>(SQLQuery, parameters);

          
            int creditUID = result.CreditUID ?? 0;

            return (creditUID, result.AffectedRows);
        }






        public async Task<Credit> EditCredit(int Id, ISqlConnectionFactory connectionFactory)
        {
            Credit credit = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[GetCreditDataByID] @UID ";
            credit = await connection.QueryFirstOrDefaultAsync<Credit>(SQLQuery, new { UID = Id });

          

            return credit;
        }
        //public async Task<string> UpdateCredit(Credit param, ISqlConnectionFactory connectionFactory)
        //{
        //    String affectedRows = null;
        //    try
        //    {
        //        await using var connection = connectionFactory.CreateConnection();
        //        string SQLQuery = @"
        //                             EXEC [dbo].[UpdateCredit]
        //                                    @UID,
        //                                    @TotalCash,
        //                                    @Status,
        //                                    @Detail,
        //                                    @ModifiedBy,
        //                                    @BranchId
        //                                             ";

        //        affectedRows = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, param);

        //        return affectedRows;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception here, you can log it or throw a custom exception
        //        // Log the exception
        //        Console.WriteLine($"An error occurred: {ex.Message}");

        //        // Optionally, rethrow the exception or throw a custom exception
        //        throw; // rethrowing the exception
        //    }
        //}
        public async Task<(string Message, int? UpdatedUID)> UpdateCredit(Credit param, ISqlConnectionFactory connectionFactory)
        {
            try
            {
                await using var connection = connectionFactory.CreateConnection();
                string SQLQuery = @"
            EXEC [dbo].[UpdateCredit]
                @UID,
                @TotalCash,
                @Status,
                @Detail,
                @ModifiedBy,
                @BranchId
                 ";

                // Execute the stored procedure and get the result as a dynamic object
                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(SQLQuery, param);

                // Return a tuple with the message and UpdatedUID
                return (result.Message, result.UpdatedUID);
            }
            catch (Exception ex)
            {
                // Handle exception here, you can log it or throw a custom exception
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Optionally, rethrow the exception or throw a custom exception
                throw; // rethrowing the exception
            }
        }



        public async Task<string> DeleteCredit(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            string Status = "";

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteCredit] @UID, @ModifiedBy";

            Status = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { UID = credit.UID, ModifiedBy = credit.ModifiedBy });

            return Status;
        }



        public async Task<Credit> GetAllCreditById(int Id, ISqlConnectionFactory sqlConnectionFactory)
        {
            Credit credit = null;
            await using var connection = sqlConnectionFactory.CreateConnection();

            string SQLQuery = @"EXEC [dbo].[spGetCreditById] @UID";

            credit = await connection.QueryFirstOrDefaultAsync<Credit>(SQLQuery, new { UID = Id });

            return credit;
        }







    }
}
