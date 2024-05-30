using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public  class DepositCashDAL
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

        public async Task<string> DepositAdd(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            string _deposit = JsonConvert.SerializeObject(deposit);

            string response = "";

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spCreateDeposit] @JsonStringDeposit";

            var result = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { JsonStringDeposit = _deposit });

            if (result != null)
            {
                response = result;
            }

            return response;
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
        public async Task<string> UpdateDeposit(Deposit param, ISqlConnectionFactory connectionFactory)
        {
            string Status = "";
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

                 Status = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, param, null);

                return Status;
            }
            catch (Exception ex)
            {
          
                Console.WriteLine($"An error occurred: {ex.Message}");

               
                throw;
            }
        }

    }
}
