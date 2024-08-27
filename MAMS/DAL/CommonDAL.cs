using DAL.Sql;
using Dapper;
using Google.Apis.Drive.v3;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace DAL
{
    public class CommonDAL
    {

        //private GoogleDriveService _ObjDriveDAL;


        //public CommonDAL()
        //{

        //    _ObjDriveDAL = new GoogleDriveService();

        //}
        public string Encrypt(string clearText, string EncryptionKey)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypt(string cipherText, string encryptionKey)
        {
            try
            {
                // Replacing spaces with '+' to handle Base64 encoded strings
                cipherText = cipherText.Replace(" ", "+");

                // Convert Base64 encoded string to byte array
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (Aes encryptor = Aes.Create())
                {
                    // Derive key and IV using encryptionKey
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    // Create a MemoryStream to hold decrypted data
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Create a CryptoStream to perform decryption
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            // Write decrypted bytes to CryptoStream
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        // Convert MemoryStream to string using Unicode encoding
                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., invalid cipher text, key, etc.)
                Console.WriteLine("An error occurred while decrypting the text: " + ex.Message);
                return null;
            }
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

        public async Task<List<CashHistory>> GetAllCashHistoryInfo(CashHistory cashHistory, ISqlConnectionFactory connectionFactory)
        {
            var cashHistoryList = new List<CashHistory>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetAllCashHistory]  @BranchId, @CreatedBy";

            var cashHistoryResult = await connection.QueryAsync<CashHistory>(SQLQuery, new { BranchId = cashHistory.BranchId, CreatedBy = cashHistory.CreatedBy });

            cashHistoryList = cashHistoryResult.ToList();

            return cashHistoryList;
        }
        public async Task<List<CashHistory>> GetFilterCashHistory(CashHistory cashHistory, ISqlConnectionFactory connectionFactory)
        {
            var cashHistoryList = new List<CashHistory>();

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetFilterCashHistory]  @BranchId,@FromDate,@ToDate";

            var cashHistoryResult = await connection.QueryAsync<CashHistory>(SQLQuery, new { BranchId = cashHistory.BranchId, FromDate = cashHistory.FromDate, ToDate = cashHistory.ToDate });

            cashHistoryList = cashHistoryResult.ToList();

            return cashHistoryList;
        }
        public async Task<CashHistory> GetCashHistory(Guid branchId, Guid createdBy, ISqlConnectionFactory connectionFactory)
        {
            CashHistory cashHistory = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCashHistory] @BranchId, @CreatedBy";

            cashHistory = await connection.QueryFirstOrDefaultAsync<CashHistory>(SQLQuery, new { BranchId = branchId, CreatedBy = createdBy });

            return cashHistory;
        }

        public async Task<string> UpdateCashHistorybyProfit(CashHistory param, ISqlConnectionFactory connectionFactory)
        {
            try
            {
                await using var connection = connectionFactory.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@BranchId", param.BranchId, DbType.Guid);
                parameters.Add("@CreatedBy", param.CreatedBy, DbType.Guid);
                parameters.Add("@CashProfit", param.CashProfit, DbType.Decimal);
                parameters.Add("@Detail", param.Details, DbType.String);

                string sqlQuery = @"
                                        EXEC [dbo].[spUpdateCashByProfit]
                                        @BranchId,
                                        @CreatedBy,
                                        @CashProfit,
                                        @Detail
                                ";

                string result = await connection.QueryFirstOrDefaultAsync<string>(sqlQuery, parameters);

                return result;
            }
            catch (SqlException ex)
            {
                // Log the SQL exception (you can use any logging framework)
                Console.WriteLine($"SQL Exception: {ex.Message}");
                // Optionally, rethrow or handle the exception as needed
                throw;
            }
            catch (Exception ex)
            {
                // Log the general exception
                Console.WriteLine($"Exception: {ex.Message}");
                // Optionally, rethrow or handle the exception as needed
                throw;
            }
        }

        public async Task<string> UpdateCashHistorybyLoss(CashHistory param, ISqlConnectionFactory connectionFactory)
        {
            await using var connection = connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@BranchId", param.BranchId, DbType.Guid);
            parameters.Add("@CreatedBy", param.CreatedBy, DbType.Guid);
            parameters.Add("@CashLost", param.CashLost, DbType.Decimal);
            parameters.Add("@Detail", param.Details, DbType.String);

            string sqlQuery = @"
                EXEC [dbo].[spUpdateCashByLoss]
                    @BranchId,
                    @CreatedBy,
                    @CashLost,
                     @Detail
            ";

            string result = await connection.QueryFirstOrDefaultAsync<string>(sqlQuery, parameters);

            return result;


        }
        public async Task<List<Role>> GetRole(ISqlConnectionFactory connectionFactory)
        {

            var _roleList = new List<Role>();

            try
            {

                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spGetRole] ";

                var Role = await connection.QueryAsync<Role>(SQLQuery, new { });

                _roleList = Role.ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return _roleList;
        }
        public async Task<int> DocumentsAdd(Documents document, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            try
            {
                using (var connection = connectionFactory.CreateConnection())
                {
                    (string FileId, string fileUrl) = await GoogleDriveServiceHelper.UploadFileAsync(document);
                    string sqlQuery = @"
                                            INSERT INTO [dbo].[Documents] 
                                            (
                                             ContentType,Fk_Id, CreatedBy, CreatedDate,FK_Type,FileId,fileUrl
                                            ) 
                                            VALUES 
                                            (
                                             @ContentType, @Fk_Id, @CreatedBy, @CreatedDate, @FK_Type,@FileId,@fileUrl
                                             )";

                    var parameters = new
                    {
                        DocumentId = document,
                        ContentType = document.ContentType,
                        Fk_Id = document.Fk_Id,
                        CreatedBy = document.CreatedBy,
                        CreatedDate = document.CreatedDate,
                        FileUrl = fileUrl,
                        FK_Type = document.FK_Type,
                        FileId = FileId

                    };
                    affectedRows += await connection.ExecuteAsync(sqlQuery, parameters);

                    
                   

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error in data access layer: " + ex.Message);
            }
            return affectedRows;

        }
        public async Task<List<string>> GetDocumentsInfo(Guid id, ISqlConnectionFactory connectionFactory)
        {
            List<string> result = new List<string>();

            try
            {
                using (var connection = connectionFactory.CreateConnection())
                {
                    string sqlQuery = @"
                                        SELECT 
                                            FileId,
                                            fileUrl
                                        FROM [dbo].[Documents]
                                        WHERE Fk_Id = @Fk_Id";

                    var parameters = new { Fk_Id = id };
                    var documents = await connection.QueryAsync(sqlQuery, parameters);
                    result = documents.Select(doc => $"{doc.FileId}:{doc.fileUrl}").ToList();
                }
            }
            catch (Exception ex)
            {
                result.Add("Error in data access layer: " + ex.Message);
            }

            return result;
        }





    }
}