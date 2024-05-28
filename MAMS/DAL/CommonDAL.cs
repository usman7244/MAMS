using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class CommonDAL
    {
       


        public async Task<List<CustomerType>> GetCustomerType(string cusType, Guid branchId, Guid createdBy, ISqlConnectionFactory connectionFactory)
        {
            var custTypeList = new List<CustomerType>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCustType] @CusType, @BranchId, @CreatedBy";

            var custTypes = await connection.QueryAsync<CustomerType>(SQLQuery, new { CusType = cusType, BranchId = branchId, CreatedBy = createdBy });

            custTypeList = custTypes.ToList();

            return custTypeList;
        }

        public async Task<List<CashHistory>> GetAllCashHistoryInfo(CashHistory cashHistory, ISqlConnectionFactory connectionFactory)
        {
            var cashHistoryList = new List<CashHistory>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetAllCashHistory]  @BranchId, @CreatedBy";

            var cashHistoryResult = await connection.QueryAsync<CashHistory>(SQLQuery, new { BranchId = cashHistory.BranchId, CreatedBy = cashHistory.CreatedBy });

            cashHistoryList = cashHistoryResult.ToList();

            return cashHistoryList;
        }
        public async Task<CashHistory> GetCashHistory(Guid branchId, Guid createdBy, ISqlConnectionFactory connectionFactory)
        {
            CashHistory cashHistory = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCashHistory] @BranchId, @CreatedBy";

            cashHistory = await connection.QueryFirstOrDefaultAsync<CashHistory>(SQLQuery, new { BranchId = branchId, CreatedBy = createdBy });

            return cashHistory;
        }

        public async Task<int> UpdateCashHistorybyProfit(CashHistory param, ISqlConnectionFactory connectionFactory)
        {
            try
            {
                await using var connection = connectionFactory.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchId", param.BranchId, DbType.Guid);
                parameters.Add("@CreatedBy", param.CreatedBy, DbType.Guid);
                parameters.Add("@CashProfit", param.CashProfit, DbType.Decimal);
                parameters.Add("@Details", param.Details, DbType.Decimal);

                string sqlQuery = @"
                                        EXEC [dbo].[spUpdateCashByProfit]
                                        @BranchId,
                                        @CreatedBy,
                                        @CashProfit,
                                        @Details
                                ";

                int result = await connection.QueryFirstOrDefaultAsync<int>(sqlQuery, parameters);

                return result;
            }
            catch (SqlException ex)
            {
                // Log the SQL exception (you can use any logging framework)
                Console.WriteLine($"SQL Exception: {ex.Message}");
                // Optionally, rethrow or handle the exception as needed
                throw;
            }
            catch (Exception ex)
            {
                // Log the general exception
                Console.WriteLine($"Exception: {ex.Message}");
                // Optionally, rethrow or handle the exception as needed
                throw;
            }
        }

        public async Task<int> UpdateCashHistorybyLoss(CashHistory param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@BranchId", param.BranchId, DbType.Guid);
            parameters.Add("@CreatedBy", param.CreatedBy, DbType.Guid);
            parameters.Add("@CashLost", param.CashLost, DbType.Decimal);
            parameters.Add("@Details", param.Details, DbType.Decimal);

            string sqlQuery = @"
                EXEC [dbo].[spUpdateCashByLoss]
                    @BranchId,
                    @CreatedBy,
                    @CashLost,
                     @Details
            ";

            int result = await connection.QueryFirstOrDefaultAsync<int>(sqlQuery, parameters);

            return result;


        }

    }
}
