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
    public class DepositCashBOL
    {
        private DAL.DepositCashDAL _objCashDAL;
        private DAL.CommonDAL _objCommonDAL;
        public DepositCashBOL()
        {
            _objCashDAL = new DAL.DepositCashDAL();
            _objCommonDAL = new DAL.CommonDAL();
        }

        public async Task<List<Deposit>> GetAllDepositInfo(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCashDAL.GetAllDepositInfo(deposit, connectionFactory);
            return result;
        }
        public async Task<(int? DepositUID, int AffectedRows)> DepositAdd(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            if (deposit == null)
            {
                return (null, 0);
            }
            var result = await _objCashDAL.DepositAdd(deposit, connectionFactory);

            if (result.DepositUID == null)
            {
                return (null, 0);
            }

            int affectedRows = result.AffectedRows;
            var documents = new List<Documents>();
            foreach (var file in deposit.UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = deposit.CreatedBy,
                    Fk_Id = result.DepositUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Deposit),
                    BranchId = deposit.BranchId
                };

          
                affectedRows += await _objCommonDAL.DocumentsAdd(document, connectionFactory);
            }

            // Return the credit UID and the total affected rows
            return (result.DepositUID, affectedRows);


        }
        public async Task<Deposit> EditDeposit(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.EditDeposit(Id, connectionFactory);
            if (result != null)
            {
                result.UserFilesUrl ??= new List<string>();

               // List<string> fileInfo = await _objCommonDAL.GetDocumentsInfo(Id, connectionFactory);

                //if (fileInfo != null && fileInfo.Any())
                //{
                //    foreach (var fileEntry in fileInfo)
                //    {
                //        try
                //        {
                //            var match = Regex.Match(fileEntry, @"^([^:]+):(.+)$");

                //            if (match.Success)
                //            {
                //                var fileId = match.Groups[1].Value;
                //                var fileUrl = match.Groups[2].Value;
                //                result.UserFilesUrl.Add(fileUrl);

                //            }
                //            else
                //            {

                //                throw new FormatException($"Invalid file entry format: {fileEntry}");
                //            }
                //        }
                //        catch (Exception ex)
                //        {

                //            throw new InvalidOperationException("Failed to process file entry.", ex);
                //        }
                //    }
                //}
            }
            return result;
        }
        public async Task<Deposit> GetAllDepositById(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.GetAllDepositById(Id, connectionFactory);
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
        public async Task<string> DeleteDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)
        {
            string result = "";
             result = await _objCashDAL.DeleteDeposit(deposit, connectionFactory);

            return result;
        }
        public async Task<string> UpdateDeposit(Deposit deposit, ISqlConnectionFactory connectionFactory)

        {
           // string affectedrow=string.Empty;
            var affectedrow = await _objCashDAL.UpdateDeposit(deposit, connectionFactory);
            if (deposit.Status == "Sent")
            {
                if (affectedrow.Message == "Success")
                {

                    if (decimal.TryParse(deposit.DiffCash, out decimal diffCash) && decimal.TryParse(deposit.TotalCash, out decimal totalCash))
                    {
                        var diff = Convert.ToInt32(diffCash- totalCash);
                        if (diff < 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = deposit.BranchId,
                                CashLost = diff.ToString().Replace("-", ""),
                                Details = EnumExtension.GetDisplayName(ExpenseType.Deposit),

                            };


                            string re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                            if (re == "Success")
                            {
                                foreach (var file in deposit.UserFiles)
                                {
                                    var document = new Documents
                                    {
                                        File = file,
                                        CreatedBy = deposit.CreatedBy,
                                        Fk_Id = affectedrow.UpdatedUID.ToString(),
                                        CreatedDate = DateTime.Now,
                                        FK_Type = EnumExtension.GetDisplayName(ExpenseType.Credit),
                                        BranchId = deposit.BranchId
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
                                BranchId = deposit.BranchId,
                                CashProfit = diff.ToString(),
                                Details = EnumExtension.GetDisplayName(ExpenseType.Deposit),
                            };


                            string re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, connectionFactory);
                            if (re == "Success")
                            {
                                foreach (var file in deposit.UserFiles)
                                {
                                    var document = new Documents
                                    {
                                        File = file,
                                        CreatedBy = deposit.CreatedBy,
                                        Fk_Id = affectedrow.UpdatedUID.ToString(),
                                        CreatedDate = DateTime.Now,
                                        FK_Type = EnumExtension.GetDisplayName(ExpenseType.Credit),
                                        BranchId = deposit.BranchId
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
            }
            return affectedrow.Message;
        }

    }
}
