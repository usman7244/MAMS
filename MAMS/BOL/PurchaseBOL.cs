using DAL;
using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace BOL
{
    public class PurchaseBOL
    {
        private PurchaseDAL _objPurchaseDAL;
        private List<CropAndBag> _bags;
        private DAL.CommonDAL _objCommonDAL;

        public PurchaseBOL()
        {
            _objPurchaseDAL = new PurchaseDAL();
            _bags = new List<CropAndBag>();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<List<CustomerType>> GetCustomerType(string cusType, Guid branchId, Guid createdBy, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetCustomerType(cusType, branchId, createdBy, sqlConnectionFactory);
        }
        public async Task<List<CropAndBag>> GetBags(Guid branchId, Guid createdBy,string Type, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetBags(branchId, createdBy,Type, sqlConnectionFactory);
        }
        public async Task<CashHistory> GetCashHistory(Guid branchId, Guid createdBy, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetCashHistory(branchId, createdBy, sqlConnectionFactory);
        }
        public async Task<List<Purchase>> GetAllPurchasedCrop(Purchase purchase, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objPurchaseDAL.GetAllPurchasedCrop(purchase, sqlConnectionFactory);
        }


        public async Task<Purchase> GetPurchasedCropById(int purchCropId, ISqlConnectionFactory connectionFactory)
        {
           var result =await _objPurchaseDAL.GetPurchasedCropById(purchCropId, connectionFactory);
            if (result != null)
            {
                result.UserFilesUrl ??= new List<string>();
                Guid purchaseId = Guid.Parse(purchCropId.ToString());
                List<string> fileInfo = await _objCommonDAL.GetDocumentsInfo(purchaseId, connectionFactory);

                if (fileInfo != null && fileInfo.Any())
                {
                    foreach (var fileEntry in fileInfo)
                    {
                        try
                        {
                            var match = Regex.Match(fileEntry, @"^([^:]+):(.+)$");

                            if (match.Success)
                            {
                                var fileId = match.Groups[1].Value;
                                var fileUrl = match.Groups[2].Value;
                                result.UserFilesUrl.Add(fileUrl);

                            }
                            else
                            {

                                throw new FormatException($"Invalid file entry format: {fileEntry}");
                            }
                        }
                        catch (Exception ex)
                        {

                            throw new InvalidOperationException("Failed to process file entry.", ex);
                        }
                    }
                }
            }
            return result;
        }
        public async Task<List<Expense>> GetPurchasedExpenseById(int purchCropId, ISqlConnectionFactory connectionFactory)
        {
            var re=await _objPurchaseDAL.GetPurchasedExpenseById(purchCropId, connectionFactory);
            return re;
        }



        public async Task<(int? CreditUID, string AffectedRows)> AddPurchaseCrop(Purchase purchase, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            if (purchase == null)
            {
                return (null, null);
            }


            var result = await _objPurchaseDAL.AddPurchaseCrop(purchase, expenses, connectionFactory);

            if (result.PurchaseUID == null)
            {
                return (null, null);
            }

            string affectedRows = result.AffectedRows;
            var documents = new List<Documents>();


            foreach (var file in purchase.UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = purchase.CreatedBy ?? Guid.Empty,
                    Fk_Id = result.PurchaseUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Customer),
                    BranchId = purchase.BranchId ?? Guid.Empty,

                };

                // Add each document and accumulate affected rows
                affectedRows += await _objCommonDAL.DocumentsAdd(document, connectionFactory);
            }

            // Return the credit UID and the total affected rows
            return (result.PurchaseUID, affectedRows);

        }



        public async Task<string> DeletePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            string result = await _objPurchaseDAL.DeletePurchaseCrop(purchase, connectionFactory);
            return result;
        }


        public async Task<string> UpdatePurchaseCrop(Purchase purchase, ISqlConnectionFactory connectionFactory)
        {
            string affectedrow = null;
             affectedrow = await _objPurchaseDAL.UpdatePurchaseCrop(purchase, connectionFactory);
            if (affectedrow == "Success")
            {

                if (decimal.TryParse(purchase.DiffCash, out decimal diffCash) && decimal.TryParse(purchase.TotalCropPrice.ToString(), out decimal totalCash))
                {
                    var diff = Convert.ToInt32(diffCash - totalCash);
                    if (diff < 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashLost = diff.ToString().Replace("-", ""),
                            Details = EnumExtension.GetDisplayName(ExpenseType.Purchase),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                        return re;
                    }
                    else if (diff > 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashProfit = diff.ToString(),
                            Details = EnumExtension.GetDisplayName(ExpenseType.Purchase),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, connectionFactory);
                        return re;
                    }

                }
                else
                {

                    throw new ArgumentException("Invalid numeric value for DiffCash or TotalCash.");
                }

            }
            else
            {
                throw new ArgumentException("Invalid numeric value for DiffCash or TotalCash.");
            }
            return affectedrow;
        }

    }
}
