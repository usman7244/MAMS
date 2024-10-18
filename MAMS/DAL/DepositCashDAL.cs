using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class DepositCashDAL
    {

        public async Task<List<Deposit>> GetAllDepositInfo(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            var depositList = new List<Deposit>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = @"EXEC [dbo].[spGetDepositInfo] @BranchId, @CreatedBy";

            var deposits = await connection.QueryAsync<Deposit>(SQLQuery, new { BranchId = deposit.BranchId, CreatedBy = deposit.CreatedBy });

            depositList = deposits.ToList();

            return depositList;
        }

        //public async Task<(int DepositUID, int AffectedRows)> DepositAdd(Deposit deposit, ISqlConnectionFactory connectionFactory)
        //{

        //    string _deposit = JsonConvert.SerializeObject(deposit);


        //    await using var connection = connectionFactory.CreateConnection();

        //    string SQLQuery = "EXEC [dbo].[spCreateDeposit] @JsonStringDeposit";

        //    var parameters = new { JsonStringDeposit = _deposit };

        //    var result = await connection.QueryFirstOrDefaultAsync<(int? DepositUID, int AffectedRows)>(SQLQuery, parameters);

        //    int depositUID = result.DepositUID ?? 0;

        //    return (depositUID, result.AffectedRows);
        //}
        public async Task<(int DepositUID, int AffectedRows)> DepositAdd(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            string depositJson = JsonConvert.SerializeObject(deposit);

            await using var connection = connectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[spCreateDeposit]";

            // Input parameter
            command.Parameters.Add(new SqlParameter("@JsonStringDeposit", SqlDbType.NVarChar)
            {
                Value = depositJson
            });

            // Output parameters
            var uidParam = new SqlParameter("@UID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(uidParam);

            var affectedRowsParam = new SqlParameter("@AffectedRows", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(affectedRowsParam);

            var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(messageParam);

            await command.ExecuteNonQueryAsync();

            // Retrieve output values
            int depositUID = (int)(uidParam.Value ?? 0);
            int affectedRows = (int)(affectedRowsParam.Value ?? 0);

            return (depositUID, affectedRows);
        }



        public async Task<Deposit> EditDeposit(int Id, ISqlConnectionFactory connectionFactory)
        {
            Deposit deposit = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = @"EXEC [dbo].[GetCreditDataByID] @UID ";
            deposit = await connection.QueryFirstOrDefaultAsync<Deposit>(SQLQuery, new { UID = Id });



            return deposit;
        }
        public async Task<Deposit> GetAllDepositById(int Id, ISqlConnectionFactory sqlConnectionFactory)
        {
            Deposit deposit = null;
            await using var connection = sqlConnectionFactory.CreateConnection();

            string SQLQuery = @"EXEC [dbo].[spGetDepositById]  @UID";

            deposit = await connection.QueryFirstOrDefaultAsync<Deposit>(SQLQuery, new { UID = Id });

            return deposit;
        }
        public async Task<string> DeleteDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            string Status = "";

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteDeposit]  @UID, @ModifiedBy";

            Status = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { UID = deposit.UID, ModifiedBy = deposit.ModifiedBy });

            return Status;
        }
        //public async Task<string> UpdateDeposit(Deposit param, ISqlConnectionFactory connectionFactory)
        //{
        //    string Status = "";
        //    try
        //    {
        //        await using var connection = connectionFactory.CreateConnection();
        //        string SQLQuery = @"
        //                             EXEC [dbo].[UpdateDeposit]
        //                                    @UID,
        //                                    @TotalCash,
        //                                    @Status,
        //                                    @Detail,
        //                                    @ModifiedBy,
        //                                    @BranchId
        //                                             ";

        //        Status = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, param, null);

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"An error occurred: {ex.Message}");


        //        throw;
        //    }
        //}
        public async Task<(string Message, int? UpdatedUID)> UpdateDeposit(Deposit param, ISqlConnectionFactory connectionFactory)
        {
            try
            {
                await using var connection = connectionFactory.CreateConnection();
                string SQLQuery = @"
            EXEC [dbo].[UpdateDeposit]
                @UID,
                @TotalCash,
                @Status,
                @Detail,
                @ModifiedBy,
                @BranchId
        ";

                // Use dynamic to capture both the message and UpdatedUID from the output
                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(SQLQuery, param);

                // Return the message and updated UID
                return (result?.Message, result?.UpdatedUID != null ? (int?)result.UpdatedUID : null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }



    }
}
