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
        private ConnectionLayer _connection;
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
            _connection = new ConnectionLayer();
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



        
        public async Task<string> AddPurchaseCrop(Purchase purchase, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            string _purchase = JsonConvert.SerializeObject(purchase);
            string _expenses = JsonConvert.SerializeObject(expenses);
            string response = "";

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spCreatePurchaseCrop] @JsonStringPurchase, @JsonStringExpense";

            var result = await connection.QueryFirstOrDefaultAsync<string>(SQLQuery, new { JsonStringPurchase = _purchase, JsonStringExpense = _expenses });

            if (result != null)
            {
                response = result;
            }

            return response;
        }


        public async Task<int> DeletePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeletePurchaseCrop] @UID, @ModifiedBy";

            var effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = purchase.UID, ModifiedBy = purchase.ModifiedBy });

            return effectedRows;
        }

        public async Task<int> UpdatePurchaseCrop(Purchase param, ISqlConnectionFactory connectionFactory)
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

                var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);
                return res;
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
