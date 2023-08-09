using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class ExpenseDAL
    {
     
        public ExpenseDAL()
        {

        }
        public async Task<int> Update(Expense param, ISqlConnectionFactory sqlConnectionFactory)
        {
             
            await using var connection =  sqlConnectionFactory.CreateConnection();
            string SQLQuery = @" UPDATE [dbo].[StockMgt.Expense]
                                        SET Amount = @Amount, 
	                                        ExpDescription = @ExpDescription, 
	                                        ModifiedBy=@ModifiedBy,
	                                        ModifiedDate=GETUTCDATE()
                                        WHERE [UID]=@UID;";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);
            return res;
        }

        public async Task<int> Delete(Expense param, ISqlConnectionFactory sqlConnectionFactory)
        {
            
            await using var connection = sqlConnectionFactory.CreateConnection();
            string SQLQuery = @" UPDATE [dbo].[StockMgt.Expense]
                                        SET  
	                                        [ModifiedBy]=@ModifiedBy,
	                                        [ModifiedDate]=GETUTCDATE(),
	                                        [DeletedDate]=GETUTCDATE()
                                        WHERE [UID]=@UID;";

            await connection.ExecuteAsync(SQLQuery, param, null);
            return 1;
        }

        public async Task<int> Insert(Expense param, ISqlConnectionFactory sqlConnectionFactory)
        {
             
            await using var connection = sqlConnectionFactory.CreateConnection();
            string SQLQuery = @" INSERT INTO [dbo].[StockMgt.Expense]
	                                        (
                                               [Fk_Purchase]
                                              ,[ExpDescription]
                                              ,[Amount]    
	                                          ,[CreatedDate]
                                              ,[CreatedBy]
	                                          ,[BranchId]
	                                          ,[Type]
	                                          )
                                        VALUES (@Fk_Purchase, @ExpDescription, @Amount,GETUTCDATE(),@CreatedBy ,@BranchId,@Type)";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);
            return res;
        }
    }
}
