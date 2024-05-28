﻿using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<string> CreditAdd(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            var result = await _objCashDAL.CreditAdd(credit, connectionFactory);
            return result;
        }
        public async Task<Credit> EditCredit(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.EditCredit(Id, connectionFactory);

            return result;
        }
        public async Task<int> DeleteCredit(Credit credit, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.DeleteCredit(credit, connectionFactory);

            return result;
        }
        public async Task<Credit> GetAllCreditById(int Id, ISqlConnectionFactory connectionFactory)
        {

            var result = await _objCashDAL.GetAllCreditById(Id, connectionFactory);

            return result;
        }
        public async Task<int> UpdateCredit(Credit credit, ISqlConnectionFactory connectionFactory)
        {
            int affectedrow;
            affectedrow = await _objCashDAL.UpdateCredit(credit, connectionFactory);

            if (affectedrow == 0)
            {

                if (decimal.TryParse(credit.DiffCash, out decimal diffCash) && decimal.TryParse(credit.TotalCash, out decimal totalCash))
                {
                    var diff = Convert.ToInt32(diffCash - totalCash);
                    if (diff < 0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = credit.BranchId,
                            CashLost = diff.ToString().Replace("-",""),

                        };


                        var re = await _objCommonDAL.UpdateCashHistorybyLoss(_cashHistory, connectionFactory);
                        return re;
                    }
                    else if (diff>0)
                    {
                        var _cashHistory = new CashHistory
                        {
                            BranchId = credit.BranchId,
                            CashProfit = diff.ToString(),

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
