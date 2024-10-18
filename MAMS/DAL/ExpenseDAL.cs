﻿using DAL.Sql;
using Dapper;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace DAL
{
    public class ExpenseDAL
    {
     
        public ExpenseDAL()
        {

        }
        public async Task<List<Expense>> GetExpenseInfo(Expense expense, ISqlConnectionFactory connectionFactory)
        {
            var expenseList = new List<Expense>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetExpenseInfoByType] @BranchId, @CreatedBy,@Type";

            var expenses = await connection.QueryAsync<Expense>(SQLQuery, new { BranchId = expense.BranchId, CreatedBy = expense.CreatedBy,Type=expense.Type });

            expenseList = expenses.ToList();


            return expenseList;
        }


        public async Task<(string Message, int ExpenseUID)> Update(Expense param, ISqlConnectionFactory sqlConnectionFactory)
        {
            string resultMessage = string.Empty;
            try
            {
                await using var connection = sqlConnectionFactory.CreateConnection();
               string SQLQuery = @"EXEC [dbo].[sp_UpdateStockMgtExpense]
                                                        @UID = @UID,
                                                        @Amount = @Amount,
                                                        @ExpDescription = @ExpDescription,
                                                        @ModifiedBy = @ModifiedBy;";

                var result = await connection.QueryFirstOrDefaultAsync<(string Message, int ExpenseUID)>(SQLQuery, param, null);
                return result;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw; 
            }
            catch (Exception ex)
            {
       
                Console.WriteLine($"Exception: {ex.Message}");
                throw; 
            }
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

        public async Task<(int ExpenseUID, int AffectedRows)> Insert(Expense param, ISqlConnectionFactory sqlConnectionFactory)
        {
            string Status = "";
            string _expense = JsonConvert.SerializeObject(param);
           
                await using var connection = sqlConnectionFactory.CreateConnection();
                string SQLQuery = "EXEC [dbo].[spCreateExpense] @JsonStringExpense";
            var parameters = new { JsonStringExpense = _expense };
            var result = await connection.QueryFirstOrDefaultAsync<(int? ExpenseUID, int AffectedRows)>(SQLQuery, parameters);
            int expenseUID = result.ExpenseUID ?? 0;

            return (expenseUID, result.AffectedRows);
             
        }
        public async Task<Expense> GetSpecificExpenseInfo(int Id, ISqlConnectionFactory connectionFactory)
        {
            Expense expense = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[GetExpenseById] @UID";

            expense = await connection.QueryFirstOrDefaultAsync<Expense>(SQLQuery, new { UID = Id });

            return expense;
        }
        public async Task<int> ExpenseEdit(Expense model, ISqlConnectionFactory sqlConnectionFactory)
        {
            model.Type= EnumExtension.GetDisplayName(ExpenseType.DailyExpense);
            try
            {
                await using var connection = sqlConnectionFactory.CreateConnection();

                string SQLQuery = @"UPDATE [dbo].[StockMgt.Expense]
                           SET 
                               [ExpDescription] = @ExpDescription,
                               [Amount] = @Amount,
                               [Type] = @Type,
                               [CreatedBy] = @CreatedBy,
                               [CreatedDate] = @CreatedDate,
                               [ModifiedBy] = @ModifiedBy,
                               [ModifiedDate] = GETUTCDATE()
                               WHERE [UID] = @UID";

                var affectedRows = await connection.ExecuteAsync(SQLQuery, model);

                return affectedRows;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                throw;  // Re-throw the exception to ensure the calling code is aware of the failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;  // Re-throw the exception to ensure the calling code is aware of the failure
            }
        }

    }
}
