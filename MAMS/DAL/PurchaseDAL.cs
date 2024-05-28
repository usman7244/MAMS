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
        private Bag _bag;
        private List<Bag> _bags;
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
            _bag = new Bag();
            _bags = new List<Bag>();
            _expense = new Expense();
            _expenseList = new List<Expense>();

        }
        public List<CustomerType> GetCustomerType(string cusType, Guid branchId, Guid createdBy)
        {
            _custTypeList = new List<CustomerType>();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetCustType";
                    cmd.Parameters.AddWithValue("@CusType", cusType);
                    cmd.Parameters.AddWithValue("@BranchId", branchId);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _custType = new CustomerType();
                            _custType.UID = reader["UID"].ToString().ToGuid();
                            _custType.Name = reader["Cust_Name"].ToString();
                            _custTypeList.Add(_custType);
                        }
                    }
                    reader.Close();
                    _connection.ConnectionClose();
                }
            }
            return _custTypeList;
        }
        public List<Bag> GetBags(Guid branchId, Guid createdBy)
        {
            _bags = new List<Bag>();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetBag";
                    cmd.Parameters.AddWithValue("@BranchId", branchId);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _bag = new Bag();
                            _bag.UID = Convert.ToInt32(reader["UID"]);
                            _bag.Name = reader["BagName"].ToString();
                            _bags.Add(_bag);
                        }
                    }
                    reader.Close();

                }
            }
            _connection.ConnectionClose();
            return _bags;
        }
        public CashHistory GetCashHistory(Guid branchId, Guid createdBy)
        {
            _cashHistory = new CashHistory();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetCashHistory";
                    cmd.Parameters.AddWithValue("@BranchId", branchId);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _cashHistory.UID = Convert.ToInt32(reader["UID"]);
                            _cashHistory.TotalCash = reader["TotalCash"].ToString();
                        }
                    }
                    reader.Close();
                    _connection.ConnectionClose();
                }
            }
            return _cashHistory;
        }
        public List<Purchase> GetAllPurchasedCrop(Purchase purchase)
        {
            _purchaseList = new List<Purchase>();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetPurchaseCrop";
                    cmd.Parameters.AddWithValue("@BranchId", purchase.BranchId);
                    cmd.Parameters.AddWithValue("@CreatedBy", purchase.CreatedBy);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _purchase = new Purchase();
                            _purchase.UID = Convert.ToInt32(reader["UID"]);
                            _purchase.CustomerName = reader["CustomerName"].ToString();
                            _purchase.Status = reader["Status"].ToString();
                            _purchase.CropName = reader["CropName"].ToString();
                            _purchase.TotalCropWeight = Convert.ToDecimal(reader["TotalCropWeight"].ToString());
                            _purchase.TotalCropPrice = Convert.ToInt32(reader["TotalCropPrice"].ToString());
                            _purchase.TotalAmountwithExp = Convert.ToInt32(reader["TotalAmountwithExp"].ToString());
                            _purchase.TotalExp = Convert.ToInt32(reader["TotalExp"].ToString());
                            _purchase.UserName = reader["CreatedBy"].ToString();
                            _purchase.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                            _purchaseList.Add(_purchase);
                        }
                    }
                    reader.Close();

                }
            }
            _connection.ConnectionClose();
            return _purchaseList;
        }
        public Purchase GetPurchasedCropById(int purchCropId)
        {
            _purchase = new Purchase();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetPurchaseCropById";
                    cmd.Parameters.AddWithValue("@UID", purchCropId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _purchase.UID = Convert.ToInt32(reader["UID"]);
                            _purchase.CustomerType = reader["FK_CustomerType"].ToString();
                            _purchase.Fk_Crop = Convert.ToInt32(reader["Fk_Crop"].ToString());
                            _purchase.WeightInMaun = Convert.ToInt32(reader["WeightInMaun"].ToString());
                            _purchase.WeightInkg = Convert.ToDecimal(reader["WeightInkg"].ToString());
                            _purchase.TotalCropWeight = Convert.ToDecimal(reader["TotalCropWeight"].ToString());
                            _purchase.PriceInMaun = Convert.ToInt32(reader["PriceInMaun"].ToString());
                            _purchase.PriceInKg = Convert.ToDecimal(reader["PriceInKg"].ToString());
                            _purchase.TotalCropPrice = Convert.ToInt32(reader["TotalCropPrice"].ToString());
                            _purchase.TotalExp = Convert.ToInt32(reader["TotalExp"].ToString());
                            _purchase.TotalAmountwithExp = Convert.ToInt32(reader["TotalAmountwithExp"].ToString());
                            _purchase.FK_BagType = Convert.ToInt32(reader["FK_BagType"].ToString());
                            _purchase.BagWeight = Convert.ToInt32(reader["BagWeight"].ToString());
                            _purchase.BagTotal = Convert.ToInt32(reader["BagTotal"].ToString());
                            _purchase.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                            _purchase.Fk_CustomerId = reader["Fk_Customer"].ToString().ToGuid();
                            _purchase.UserName = reader["CreatedBy"].ToString();
                        }
                    }
                    reader.Close();

                }
            }
            _connection.ConnectionClose();
            return _purchase;
        }
        public List<Expense> GetPurchasedExpenseById(int purchCropId)
        {

            _expenseList = new List<Expense>();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetPurchaseExpenseById";
                    cmd.Parameters.AddWithValue("@PUID", purchCropId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _expense = new Expense();
                            _expense.UID = Convert.ToInt32(reader["UID"]);
                            _expense.ExpDescription = reader["ExpDescription"].ToString();
                            _expense.Amount = Convert.ToInt32(reader["Amount"].ToString());
                            _expense.CreatedBy = reader["CreatedBy"].ToString().ToGuid();
                            _expense.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());

                            _expenseList.Add(_expense);
                        }
                    }
                    reader.Close();

                }
            }
            _connection.ConnectionClose();
            return _expenseList;
        }


        public string AddPurchaseCrop(Purchase purchase, List<Expense> expenses)
        {
            string _purchase = JsonConvert.SerializeObject(purchase);
            string _expenses = JsonConvert.SerializeObject(expenses);
            string response = "";
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spCreatePurchaseCrop";
                    cmd.Parameters.AddWithValue("@JsonStringPurchase", _purchase);
                    cmd.Parameters.AddWithValue("@JsonStringExpense", _expenses);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            response = reader["Message"].ToString();
                        }
                    }
                    reader.Close();
                }
            }
            _connection.ConnectionClose();
            return response;
        }
        public int DeletePurchaseCrop(Purchase purchase)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spDeletePurchaseCrop";
                    cmd.Parameters.AddWithValue("@UID", purchase.UID);
                    cmd.Parameters.AddWithValue("@ModifiedBy", purchase.ModifiedBy);
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }

        public async Task<int> UpdatePurchaseCrop(Purchase param, ISqlConnectionFactory connectionFactory)
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
	                                 @ModifiedBy  
                                     ";

            var res = await connection.QueryFirstOrDefaultAsync<int>(SQLQuery, param, null);

            return res;
        }

    }
}
