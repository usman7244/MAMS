using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using MAMS_Models.Extenions;
using static MAMS_Models.Enums.EnumTypes;
using MAMS_Models.Enums;

namespace DAL
{
    public class SaleDAL
    {
        private Sale _sale;
        private List<Sale> _sales;
        public SaleDAL( )
        {
            _sale=new Sale();
            _sales=new List<Sale>();
        }
        public async Task<int> Insert(Sale param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @"EXEC [dbo].[spCreateSaleCrop]
                                     @UID ,
	                                 @CustomerType ,
	                                 @Fk_CustomerId ,
	                                 @Fk_Crop,
	                                 @WeightInMaun ,
	                                 @WeightInkg,
	                                 @TotalCropWeight ,
	                                 @PriceInMaun ,
	                                 @PriceInKg ,
	                                 @TotalCropPrice ,
	                                 @TotalExp ,
	                                 @TotalAmountwithExp ,
	                                 @FK_BagType ,
	                                 @BagWeight ,
	                                 @BagTotal ,
                                     @BagTotal ,
                                     @PurchaseExp ,
	                                 @CreatedBy,
                                     @BranchId
                                     ";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);

            return res;
        }
        public async Task<int> Delete(Sale param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spDeleteSaleCrop]
                                       @ModifiedBy,
                                       @UID;"  ;

            await connection.ExecuteAsync(SQLQuery, param, null);
            return 1;
        }
        public async Task<int> Update(Sale param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spUpdateSaleCrop]
                                         @UID ,
	                                     @Fk_CustomerId ,
	                                     @Fk_Crop ,
	                                     @WeightInMaun ,
	                                     @WeightInkg ,
	                                     @TotalCropWeight ,
	                                     @PriceInMaun ,
	                                     @PriceInKg ,
	                                     @TotalCropPrice ,
	                                     @TotalExp , 
	                                     @TotalAmountwithExp , 
	                                     @FK_BagType ,
	                                     @BagWeight ,
	                                     @BagTotal ,
	                                     @PurchaseExp ,
	                                     @PurchasePrice ,
	                                     @ModifiedBy  ";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);
            return res;
        }
        public async Task<Sale> GetById(Sale param, ISqlConnectionFactory connectionFactory)
        {
            _sale =new Sale();
            await using var connection = connectionFactory.CreateConnection();
            string SQLQuery = @" EXEC [dbo].[spGetSaleCropById]
		                                    @UID   ";

             _sale = await connection.QueryFirstOrDefaultAsync<Sale>(SQLQuery, param, null); 
            return _sale;
        }

        public async Task<List<Sale>> GetAllSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var saleList = new List<Sale>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetSaleCrop] @BranchId, @CreatedBy";

            var sales = await connection.QueryAsync<Sale>(SQLQuery, new { BranchId = sale.BranchId, CreatedBy = sale.CreatedBy });

            saleList = sales.ToList();
            return saleList;
        }


        public async Task<(int? SaleUID, string Message)> SaleCropAdd(Sale sale, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            string _sale = JsonConvert.SerializeObject(sale);
            string _expenses = JsonConvert.SerializeObject(expenses);

            try
            {
                await using var connection = connectionFactory.CreateConnection();

                // Define SQL query for executing the stored procedure
                string SQLQuery = "EXEC [dbo].[spCreateSaleCrop] @JsonStringSale, @JsonStringExpense";

                // Parameters for the stored procedure
                var parameters = new { JsonStringSale = _sale, JsonStringExpense = _expenses };

                // Execute the query and get the result
                var result = await connection.QueryFirstOrDefaultAsync<(int? SaleUID, string Message)>(SQLQuery, parameters);

                // Return the SaleUID and the message (Success or failure)
                return (result.SaleUID, result.Message);
            }
            catch (Exception ex)
            {
                // Log the exception for troubleshooting
                Console.WriteLine($"Error occurred: {ex.Message}");

                // Return null for SaleUID and an error message
                return (null, "Error occurred while adding the sale.");
            }
        }

        public async Task<string> DeleteSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {

            string Status = "";
            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteSaleCrop]  @UID, @ModifiedBy";

            Status = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { UID = sale.UID, ModifiedBy = sale.ModifiedBy });

            return Status;
        }
        public async Task<Sale> GetSaleCropById(int Id, ISqlConnectionFactory sqlConnectionFactory)
       {
            Sale sale = null;

            try
            {
                await using var connection = sqlConnectionFactory.CreateConnection();

                string SQLQuery = @"EXEC [dbo].[spGetSaleCropById]  @UID";

                sale = await connection.QueryFirstOrDefaultAsync<Sale>(SQLQuery, new { UID = Id });
            }
            catch (Exception ex)
            {
                // Handle the exception here, you can log it or throw a custom exception
                Console.WriteLine($"An error occurred while fetching Sale Crop by Id: {ex.Message}");
                // Optionally, rethrow the exception
                throw;
            }

            return sale;
        }

        public async Task<List<Expense>> GetSaleExpenseById(int Id, ISqlConnectionFactory connectionFactory)
        {
            var expenseList = new List<Expense>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetSaleExpenseById] @PUID";

            var expenses = await connection.QueryAsync<Expense>(SQLQuery, new { PUID = Id });

            expenseList = expenses.ToList();

            return expenseList;
        }
        //public async Task<string> UpdateSaleCrop(Sale param, ISqlConnectionFactory connectionFactory)
        //{
        //    string Status = "";
        //    try
        //    {
        //        await using var connection = connectionFactory.CreateConnection();
        //        string SQLQuery = @" EXEC [dbo].[UpdateSaleCrop]
        //                                                        @UID,
        //                                                        @Fk_Customer,
        //                                                        @Fk_Crop,
        //                                                        @WeightInMaun,
        //                                                        @WeightInkg,
        //                                                        @TotalCropWeight,
        //                                                        @PriceInMaun,
        //                                                        @PriceInKg,
        //                                                        @TotalCropPrice,
        //                                                        @TotalExp,
        //                                                        @TotalAmountwithExp,
        //                                                        @FK_BagType,
        //                                                        @BagWeight,
        //                                                        @BagTotal,
        //                                                        @ModifiedBy";


        //         Status = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, param);
        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (logging logic would be here)
        //        Console.WriteLine(ex.Message); // Replace with actual logging
        //        throw; 
        //    }
        //}
        public async Task<(string Message, int SaleUID)> UpdateSaleCrop(Sale param, ISqlConnectionFactory connectionFactory)
        {
            try
            {
                await using var connection = connectionFactory.CreateConnection();
                string SQLQuery = @" EXEC [dbo].[spUpdateSaleCrop]
                                                         @UID,
                                                          @Fk_Customer,
                                                         @Fk_Crop,
                                                         @WeightInMaun,
                                                         @WeightInkg,
                                                         @TotalCropWeight,
                                                         @PriceInMaun,
                                                         @PriceInKg,
                                                         @TotalCropPrice,
                                                         @TotalExp,
                                                         @TotalAmountwithExp,
                                                         @FK_BagType,
                                                         @BagWeight,
                                                         @BagTotal,
                                                         @PurchaseExp,
                                                         @PurchasePrice,
                                                         @ModifiedBy";

                var result = await connection.QueryFirstOrDefaultAsync<(string Message, int SaleUID)>(SQLQuery, param);
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception (logging logic would be here)
                Console.WriteLine(ex.Message); // Replace with actual logging
                throw;
            }
        }

        public async Task<string> StockSaleAdd(Sale model, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            model.Status = EnumExtension.GetDisplayName(StatusEnum.Status);
           
            expenses = expenses.Select(expense =>
            {
                expense.IsOld = true;
                return expense;
            }).ToList();
            string _sale = JsonConvert.SerializeObject(model);
            string _expenses = JsonConvert.SerializeObject(expenses);
            string response = "";

            try
            {
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spCreateSaleCrop] @JsonStringSale, @JsonStringExpense";

                var result = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { JsonStringSale = _sale, JsonStringExpense = _expenses });

                if (result != null)
                {
                    response = result;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Optionally rethrow the exception or handle it as per your requirements
            }

            return response;
        }

    }
}
