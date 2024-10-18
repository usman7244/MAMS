using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using Dapper;

using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace DAL
{
    public class PurchaseDAL
    {
        private Purchase _purchase;
        private List<Purchase> _purchaseList;
        private CustomerType _custType;
        private List<CustomerType> _custTypeList;
        private CashHistory _cashHistory;
        private List<CashHistory> _cashHistoryList;
        private CropAndBag _bag;
        private List<CropAndBag> _bags;
        private Expense _expense;
        private List<Expense> _expenseList;

        public PurchaseDAL()
        {
            _purchaseList = new List<Purchase>();
            _purchase = new Purchase();
            _custType = new CustomerType();
            _custTypeList = new List<CustomerType>();
            _cashHistory = new CashHistory();
            _cashHistoryList = new List<CashHistory>();
            _bag = new CropAndBag();
            _bags = new List<CropAndBag>();
            _expense = new Expense();
            _expenseList = new List<Expense>();

        }

        public async Task<List<CustomerType>> GetCustomerType(string cusType, Guid branchId, Guid createdBy, ISqlConnectionFactory connectionFactory)
        {
            var custTypeList = new List<CustomerType>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCustType] @CusType, @BranchId, @CreatedBy";

            var custTypes = await connection.QueryAsync<CustomerType>(SQLQuery, new { CusType = cusType, BranchId = branchId, CreatedBy = createdBy });

            custTypeList = custTypes.ToList();

            return custTypeList;
        }

        
        public async Task<List<CropAndBag>> GetBags(Guid branchId, Guid createdBy,string Type, ISqlConnectionFactory connectionFactory)
        {
            var bags = new List<CropAndBag>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetBag] @BranchId, @CreatedBy,@Type";

            var bagReader = await connection.ExecuteReaderAsync(SQLQuery, new { BranchId = branchId, CreatedBy = createdBy,Type=Type });

            while (await bagReader.ReadAsync())
            {
                var bag = new CropAndBag();
                bag.UID = Convert.ToInt32(bagReader["UID"]);
                bag.Name = bagReader["Name"].ToString();
                bags.Add(bag);
            }

            await bagReader.CloseAsync();

            return bags;
        }



        public async Task<CashHistory> GetCashHistory(Guid branchId, Guid createdBy, ISqlConnectionFactory connectionFactory)
        {
            CashHistory cashHistory = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCashHistory] @BranchId, @CreatedBy";

            cashHistory = await connection.QueryFirstOrDefaultAsync<CashHistory>(SQLQuery, new { BranchId = branchId, CreatedBy = createdBy });

            return cashHistory;
        }


        public async Task<List<Purchase>> GetAllPurchasedCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            var purchaseList = new List<Purchase>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetPurchaseCrop] @BranchId, @CreatedBy";

            var purchases = await connection.QueryAsync<Purchase>(SQLQuery, new { BranchId = purchase.BranchId, CreatedBy = purchase.CreatedBy });

            purchaseList = purchases.ToList();

            return purchaseList;
        }



        public async Task<Purchase> GetPurchasedCropById(int purchCropId, ISqlConnectionFactory sqlConnectionFactory)
        {
            Purchase purchase = null;
            await using var connection = sqlConnectionFactory.CreateConnection();

            string SQLQuery = @"EXEC [dbo].[spGetPurchaseCropById] @UID";

            purchase = await connection.QueryFirstOrDefaultAsync<Purchase>(SQLQuery, new { UID = purchCropId });

            return purchase;
        }






  
        public async Task<List<Expense>> GetPurchasedExpenseById(int purchCropId, ISqlConnectionFactory connectionFactory)
        {
            var expenseList = new List<Expense>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetPurchaseExpenseById] @PUID";

            var expenses = await connection.QueryAsync<Expense>(SQLQuery, new { PUID = purchCropId });

            expenseList = expenses.ToList();

            return expenseList;
        }




        //public async Task<(int? PurchaseUID, string AffectedRows)> AddPurchaseCrop(Purchase purchase, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        //{
        //    string _purchase = JsonConvert.SerializeObject(purchase);
        //    string _expenses = JsonConvert.SerializeObject(expenses);


        //    await using var connection = connectionFactory.CreateConnection();

        //    string SQLQuery = "EXEC [dbo].[spCreatePurchaseCrop] @JsonStringPurchase, @JsonStringExpense";
        //    var parameters = new { JsonStringPurchase = _purchase };
        //    var result = await connection.QueryFirstOrDefaultAsync<(int? PurchaseUID, string AffectedRows)>(SQLQuery, parameters);

        //    var purchaseUID = result.PurchaseUID;

        //    return (purchaseUID, result.AffectedRows);

        //}
        public async Task<(int? PurchaseUID, string Message)> AddPurchaseCrop(Purchase purchase, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            // Initialize result variables
            int? purchaseUID = null;
            string message = string.Empty;

            try
            {
            
                string _purchase = JsonConvert.SerializeObject(purchase);
                string _expenses = JsonConvert.SerializeObject(expenses);

               
                await using var connection = connectionFactory.CreateConnection();

               
                string SQLQuery = "EXEC [dbo].[spCreatePurchaseCrop] @JsonStringPurchase, @JsonStringExpense";

              
                var parameters = new { JsonStringPurchase = _purchase, JsonStringExpense = _expenses };

     
                var result = await connection.QueryFirstOrDefaultAsync<(string Message, int? PurchaseUID)>(SQLQuery, parameters);

    
                message = result.Message;
                purchaseUID = result.PurchaseUID;
            }
            catch (SqlException sqlEx)
            {
              
                message = $"SQL Error: {sqlEx.Message}";
   
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                message = $"An error occurred: {ex.Message}";
                // Optionally log ex or handle it further
            }

             return (purchaseUID, message);
        }



        public async Task<string> DeletePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeletePurchaseCrop] @UID, @ModifiedBy";

            string effectedRows = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { UID = purchase.UID, ModifiedBy = purchase.ModifiedBy });

            return effectedRows;
        }

        public async Task<(string Message, int PurchaseUID)> UpdatePurchaseCrop(Purchase param, ISqlConnectionFactory connectionFactory)
        {
            
            try
            {
                await using var connection = connectionFactory.CreateConnection();
                string SQLQuery = @"EXEC [dbo].[UpdatePurchaseCrop] 
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
                                 @ModifiedBy";

                var result = await connection.QueryFirstOrDefaultAsync<(string Message, int PurchaseUID)>(SQLQuery, param, null);
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







    }
}
