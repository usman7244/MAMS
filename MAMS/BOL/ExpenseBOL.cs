﻿using DAL;
using DAL.Sql;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace BOL
{
    public class ExpenseBOL
    {
        private ExpenseDAL _objExpenseDAL;
        private DAL.CommonDAL _objCommonDAL;

        public ExpenseBOL()
        {
            _objExpenseDAL = new ExpenseDAL();
            _objCommonDAL = new DAL.CommonDAL();
        }
        public async Task<List<Expense>> GetExpenseInfo(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objExpenseDAL.GetExpenseInfo(expense, sqlConnectionFactory);
        }
        public async Task<string> Update(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            
            var Status = await _objExpenseDAL.Update(expense, sqlConnectionFactory);
            if (expense.Type == "DailyExpense")
            {
                if (Status.Message == "Success")
                {

                    if (decimal.TryParse(expense.DiffCash.ToString(), out decimal diffCash) && decimal.TryParse(expense.Amount.ToString(), out decimal totalCash))
                    {
                        var diff = Convert.ToInt32(diffCash- totalCash);
                        if (diff < 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = expense.BranchId,
                                CashLost = diff.ToString().Replace("-", ""),
                                Details = EnumExtension.GetDisplayName(ExpenseType.DailyExpense),

                            };


                            var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, sqlConnectionFactory);
                            if (re == "Success")
                            {
                                foreach (var file in expense.UserFiles)
                                {
                                    var document = new Documents
                                    {
                                        File = file,
                                        CreatedBy = expense.CreatedBy,
                                        Fk_Id = Status.ExpenseUID.ToString(),
                                        CreatedDate = DateTime.Now,
                                        FK_Type = EnumExtension.GetDisplayName(ExpenseType.Sale),
                                        BranchId = expense.BranchId ,
                                    };
                                    var affectedRows = await _objCommonDAL.DocumentsAdd(document, sqlConnectionFactory);
                                    // Add each document and accumulate affected rows


                                }
                            }
                        }
                        else if (diff > 0)
                        {
                            var _cashHistory = new CashHistory
                            {
                                BranchId = expense.BranchId,
                                CashProfit = diff.ToString(),
                                Details = EnumExtension.GetDisplayName(ExpenseType.DailyExpense),

                            };


                            var re = await _objCommonDAL.UpdateCashHistorybyProfit(_cashHistory, sqlConnectionFactory);
                            if (re == "Success")
                            {
                                foreach (var file in expense.UserFiles)
                                {
                                    var document = new Documents
                                    {
                                        File = file,
                                        CreatedBy = expense.CreatedBy ,
                                        Fk_Id = Status.ExpenseUID.ToString(),
                                        CreatedDate = DateTime.Now,
                                        FK_Type = EnumExtension.GetDisplayName(ExpenseType.Sale),
                                        BranchId = expense.BranchId ,
                                    };
                                    var affectedRows = await _objCommonDAL.DocumentsAdd(document, sqlConnectionFactory);
                                    // Add each document and accumulate affected rows


                                }
                            }
                        }

                    }
                    

                }
              
            }

            return Status.Message;
        }

        public async Task<int> Delete(Expense expense, ISqlConnectionFactory sqlConnectionFactory)
        {
            var res = await _objExpenseDAL.Delete(expense, sqlConnectionFactory);
            return res;
        }

        public async Task<(int? ExpenseUID, int AffectedRows)> Insert(Expense model, ISqlConnectionFactory sqlConnectionFactory)
        {
            if (model == null)
            {
                return (null, 0);
            }


            var result = await _objExpenseDAL.Insert(model, sqlConnectionFactory);

            if (result.ExpenseUID == null)
            {
                return (null, 0);
            }

            int affectedRows = result.AffectedRows;
            var documents = new List<Documents>();

            foreach (var file in model.UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = model.CreatedBy,
                    Fk_Id = result.ExpenseUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Customer),
                    BranchId = model.BranchId
                };

                // Add each document and accumulate affected rows
                affectedRows += await _objCommonDAL.DocumentsAdd(document, sqlConnectionFactory);
            }

            // Return the credit UID and the total affected rows
            return (result.ExpenseUID, affectedRows);




        }
        public async Task<(int? ExpenseUID, int AffectedRows)> Inserts(Expense model, IFormFile[] UserFiles, ISqlConnectionFactory sqlConnectionFactory)
        {
            if (model == null)
            {
                return (null, 0);
            }


            var result = await _objExpenseDAL.Insert(model, sqlConnectionFactory);

            if (result.ExpenseUID == null)
            {
                return (null, 0);
            }

            int affectedRows = result.AffectedRows;
            var documents = new List<Documents>();

            foreach (var file in UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = model.CreatedBy,
                    Fk_Id = result.ExpenseUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.DailyExpense),
                    BranchId = model.BranchId,

                }; 
                // Add each document and accumulate affected rows
                affectedRows += await _objCommonDAL.DocumentsAdd(document, sqlConnectionFactory);
            }

            // Return the credit UID and the total affected rows
            return (result.ExpenseUID, affectedRows);




        }


        public async Task<Expense> GetSpecificExpenseInfo(int Id, ISqlConnectionFactory sqlConnectionFactory)
        {
            var result= await _objExpenseDAL.GetSpecificExpenseInfo(Id, sqlConnectionFactory);
            if (result != null)
            {
                result.UserFilesUrl ??= new List<string>();
                string ExpenseId = result.UID.ToString();
                List<string> fileInfo = await _objCommonDAL.GetDocumentsInfo(ExpenseId, sqlConnectionFactory);

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
        public async Task<int> ExpenseEdit(Expense model, ISqlConnectionFactory sqlConnectionFactory)
        {
            int affectedRows = 0;
            if (model != null)
            {
                affectedRows = await _objExpenseDAL.ExpenseEdit(model, sqlConnectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
    }
}
