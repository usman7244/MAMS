using DAL;
using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace BOL
{
    public class SaleBOL
    {
        private Sale _sale;
        private List<Sale> _sales;
        private SaleDAL _objSaleDAL;
        private DAL.CommonDAL _objCommonDAL;
        public SaleBOL()
        {
            _sale = new Sale();
            _sales = new List<Sale>();
            _objSaleDAL = new SaleDAL();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<int> Update(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.Update(sale, connectionFactory);
            return res;
        }
        public async Task<int> Insert(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.Insert(sale, connectionFactory);
            return res;
        }
        public async Task<int> Delete(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            var res = await _objSaleDAL.Delete(sale, connectionFactory);
            return res;
        }
        public async Task<Sale> GetById(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            _sale = new Sale();
            _sale = await _objSaleDAL.GetById(sale, connectionFactory);
            return _sale;
        }

        public async Task<List<Sale>> GetAllSaleCrop(Sale sale, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objSaleDAL.GetAllSaleCrop(sale, sqlConnectionFactory);
        }
        public async Task<(int? SaleUID, string AffectedRows)> SaleCropAdd(Sale sale, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            if (sale == null)
            {
                return (null, null);
            }


            var result = await _objSaleDAL.SaleCropAdd(sale, expenses, connectionFactory);

            if (result.SaleUID == null)
            {
                return (null, null);
            }

            string affectedRows = result.Message;
            var documents = new List<Documents>();


            foreach (var file in sale.UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = sale.CreatedBy ?? Guid.Empty,
                    Fk_Id = result.SaleUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Sale),
                    BranchId = sale.BranchId ?? Guid.Empty,

                };

                // Add each document and accumulate affected rows
                affectedRows += await _objCommonDAL.DocumentsAdd(document, connectionFactory);
            }

            
            return (result.SaleUID, affectedRows);
              
        }
        public async Task<string> DeleteSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            string result = await _objSaleDAL.DeleteSaleCrop(sale, connectionFactory);
            return result;
        }
        public async Task<Sale> GetSaleCropById(int Id, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objSaleDAL.GetSaleCropById(Id, connectionFactory);
            if (result != null)
            {
                result.UserFilesUrl ??= new List<string>();
                string SaleId = Id.ToString();

                List<string> fileInfo = await _objCommonDAL.GetDocumentsInfo(SaleId, connectionFactory);

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
        public async Task<List<Expense>> GetSaleExpenseById(int Id, ISqlConnectionFactory connectionFactory)
        {
            var re = await _objSaleDAL.GetSaleExpenseById(Id, connectionFactory);
            return re;
        }
        public async Task<string> UpdateSaleCrop(Sale sale, ISqlConnectionFactory connectionFactory)
        {
            
            var affectedrow = await _objSaleDAL.UpdateSaleCrop(sale, connectionFactory);
            if (affectedrow.Message == "successful")
            {

                if (decimal.TryParse(sale.DiffCash, out decimal diffCash) && decimal.TryParse(sale.TotalCropPrice.ToString(), out decimal totalCash))
                {
                    var diff = Convert.ToInt32(totalCash - diffCash);
                    if (diff < 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashLost = diff.ToString().Replace("-", ""),
                            Details = EnumExtension.GetDisplayName(ExpenseType.Sale),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                        if (re == "Success")
                        {
                            foreach (var file in sale.UserFiles)
                            {
                                var document = new Documents
                                {
                                    File = file,
                                    CreatedBy = sale.CreatedBy ?? Guid.Empty,
                                    Fk_Id = affectedrow.SaleUID.ToString(),
                                    CreatedDate = DateTime.Now,
                                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Sale),
                                    BranchId = sale.BranchId ?? Guid.Empty,
                                };
                                var affectedRows = await _objCommonDAL.DocumentsAdd(document, connectionFactory);
                                // Add each document and accumulate affected rows


                            }
                        }
                    }
                    else if (diff > 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = Guid.Empty,
                            CashProfit = diff.ToString(),
                            Details = EnumExtension.GetDisplayName(ExpenseType.Sale),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, connectionFactory);
                        if (re == "Success")
                        {
                            foreach (var file in sale.UserFiles)
                            {
                                var document = new Documents
                                {
                                    File = file,
                                    CreatedBy = sale.CreatedBy ?? Guid.Empty,
                                    Fk_Id = affectedrow.SaleUID.ToString(),
                                    CreatedDate = DateTime.Now,
                                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Credit),
                                    BranchId =  sale.BranchId ?? Guid.Empty,
                                };

                                // Add each document and accumulate affected rows
                                var affectedRows = await _objCommonDAL.DocumentsAdd(document, connectionFactory);

                            }
                        }
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
            return affectedrow.Message;
        }
        public async Task<string> StockSaleAdd(Sale model, List<Expense> expenses, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objSaleDAL.StockSaleAdd(model, expenses, connectionFactory);
            return result;
        }

    }
}
