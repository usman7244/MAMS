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
    public class CreditCashBOL
    {
        private DAL.CreditCashDAL _objCashDAL;
        private object _objPurchaseDAL;
        private DAL.CommonDAL _objCommonDAL;
        public CreditCashBOL()
        {
            _objCashDAL = new DAL.CreditCashDAL();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<List<Credit>> GetAllCreditInfo(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCashDAL.GetAllCreditInfo(credit, connectionFactory);
            return result;
        }
        public async Task<(int? CreditUID, int AffectedRows)> CreditAdd(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            if (credit == null)
            {
                return (null, 0); 
            }

         
            var result = await _objCashDAL.CreditAdd(credit, connectionFactory);

            if (result.CreditUID == null)
            {
                return (null, 0);  
            }

            int affectedRows = result.AffectedRows;  
            var documents = new List<Documents>();  

            
            foreach (var file in credit.UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = credit.CreatedBy,
                    Fk_Id = result.CreditUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Credit),
                    BranchId = credit.BranchId
                };

                // Add each document and accumulate affected rows
                affectedRows += await _objCommonDAL.DocumentsAdd(document, connectionFactory);
            }

            // Return the credit UID and the total affected rows
            return (result.CreditUID, affectedRows);
        }
        public async Task<Credit> EditCredit(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.EditCredit(Id, connectionFactory);

            return result;
        }
        public async Task<string> DeleteCredit(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            
            var res = await _objCashDAL.DeleteCredit(credit, connectionFactory);

            return res;
        }
        public async Task<Credit> GetAllCreditById(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.GetAllCreditById(Id, connectionFactory);
            if (result != null)
            {
                result.UserFilesUrl ??= new List<string>();
                string CreditId = result.UID.ToString();
                List<string> fileInfo = await _objCommonDAL.GetDocumentsInfo(CreditId, connectionFactory);

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
        public async Task<string> UpdateCredit(Credit credit, ISqlConnectionFactory connectionFactory)
        {
             
            var affectedrow = await _objCashDAL.UpdateCredit(credit, connectionFactory);
            if (credit.Status == "Recevied")
            {
                if (affectedrow.Message == "Success")
                {

                    if (decimal.TryParse(credit.DiffCash, out decimal diffCash) && decimal.TryParse(credit.TotalCash, out decimal totalCash))
                    {
                        var diff = Convert.ToInt32(totalCash - diffCash);
                        if (diff < 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = credit.BranchId,
                                CashLost = diff.ToString().Replace("-", ""),
                                Details = EnumExtension.GetDisplayName(ExpenseType.Credit),

                            };


                            var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                            if (re == "Success")
                            {
                                foreach (var file in credit.UserFiles)
                                {
                                    var document = new Documents
                                    {
                                        File = file,
                                        CreatedBy = credit.CreatedBy,
                                        Fk_Id = affectedrow.UpdatedUID.ToString(),
                                        CreatedDate = DateTime.Now,
                                        FK_Type = EnumExtension.GetDisplayName(ExpenseType.Credit),
                                        BranchId = credit.BranchId
                                    };

                                    // Add each document and accumulate affected rows
                                    var affectedRows = await _objCommonDAL.DocumentsAdd(document, connectionFactory);

                                }
                            }
                            
                        }
                        else if (diff > 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = credit.BranchId,
                                CashProfit = diff.ToString(),
                                Details = EnumExtension.GetDisplayName(ExpenseType.Credit),

                            };


                            var re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, connectionFactory);
                            if (re == "Success")
                            {
                                foreach (var file in credit.UserFiles)
                                {
                                    var document = new Documents
                                    {
                                        File = file,
                                        CreatedBy = credit.CreatedBy,
                                        Fk_Id = affectedrow.UpdatedUID.ToString(),
                                        CreatedDate = DateTime.Now,
                                        FK_Type = EnumExtension.GetDisplayName(ExpenseType.Credit),
                                        BranchId = credit.BranchId
                                    };

                                    // Add each document and accumulate affected rows
                                    var affectedRows = await _objCommonDAL.DocumentsAdd(document, connectionFactory);
                                     
                                }
                            }

                            
                        }

                    }
                   

                }
               
            }
            return affectedrow.Message;
        }


    }
}
