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
        public async Task<string> CreditAdd(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            string _credit = JsonConvert.SerializeObject(credit);

            string response = "";

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spCreateCredit] @JsonStringCredit";

            var result = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { JsonStringCredit = _credit });

            if (result != null)
            {
                response = result;
            }

            return response;
        }


   

        public async Task<Credit> EditCredit(int Id, ISqlConnectionFactory connectionFactory)
        {
            Credit credit = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[GetCreditDataByID] @UID ";
            credit = await connection.QueryFirstOrDefaultAsync<Credit>(SQLQuery, new { UID = Id });

          

            return credit;
        }
        public async Task<int> UpdateCredit(Credit param, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
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

                affectedRows = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param);

                return affectedRows;
            }
            catch (Exception ex)
            {
                // Handle exception here, you can log it or throw a custom exception
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Optionally, rethrow the exception or throw a custom exception
                throw; // rethrowing the exception
            }
        }


        public async Task<int> DeleteCredit(Credit credit, ISqlConnectionFactory connectionFactory)
        {


            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteCredit] @UID, @ModifiedBy";

            var effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = credit.UID, ModifiedBy = credit.ModifiedBy });

            return effectedRows;
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
