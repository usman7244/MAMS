using DAL;
using DAL.Sql;
using Google.Apis.Drive.v3;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;
using static MAMS_Models.Enums.EnumTypes;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace BOL
{
    public class CustomerBOL
    {
        private DAL.Customer_DAL _objCustomerDAL;
        private CommonDAL _ObjCommonDAL;

        public CustomerBOL()
        {
            _objCustomerDAL = new DAL.Customer_DAL();
            _ObjCommonDAL = new DAL.CommonDAL();

        }
        
        public async Task<(Guid? CustomerUID, int AffectedRows)> InsertCustomerInfo(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            if (customer == null)
            {
                return (null, 0);
            }

            var result = await _objCustomerDAL.InsertCustomerInfo(customer, sqlConnectionFactory);

            if (result.CustomerUID == null)
            {
                return (null, 0);
            }

            int affectedRows = 0;
            var documents = new List<Documents>();
           
            foreach (var file in customer.UserFiles)
            {
                var document = new Documents
                {
                   
                    File = file,
                    CreatedBy = customer.CreatedBy,
                    Fk_Id = result.CustomerUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Customer),
                    BranchId = customer.BranchId
                };

                affectedRows += await _ObjCommonDAL.DocumentsAdd(document, sqlConnectionFactory);
            }

            return (result.CustomerUID, affectedRows);
        }



        public async Task<List<Customer>> GetCustomerInfo(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objCustomerDAL.GetCustomerInfo(customer, sqlConnectionFactory);
        }
 
        public async Task<Customer> GetSpecificCustomerInfo(Guid id, ISqlConnectionFactory sqlConnectionFactory)
        {
            var customer = await _objCustomerDAL.GetSpecificCustomerInfo(id, sqlConnectionFactory);

            if (customer != null)
            {
                customer.UserFilesUrl ??= new List<string>();
                var CustomerID = id.ToString();
                List<string> fileInfo = await _ObjCommonDAL.GetDocumentsInfo(CustomerID, sqlConnectionFactory);

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
                                customer.UserFilesUrl.Add(fileUrl);

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

            return customer;
        }
         
      //  public async Task<int> CustomerEdit(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
       public async Task<(Guid? CustomerUID, int AffectedRows)> CustomerEdit(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            //int affectedRows = 0;
            //if (customer != null)
            //{
            //    affectedRows = await _objCustomerDAL.CustomerEdit(customer, sqlConnectionFactory);
            //    return affectedRows;
            //}
            //else
            //{
            //    return affectedRows;
            //}

            if (customer == null)
            {
                return (null, 0);
            }

            var result = await _objCustomerDAL.CustomerEdit(customer, sqlConnectionFactory);

            if (result.CustomerUID == null)
            {
                return (null, 0);
            }

            int affectedRows = 0;
            var documents = new List<Documents>();

            foreach (var file in customer.UserFiles)
            {
                var document = new Documents
                {
                    File = file,
                    CreatedBy = customer.CreatedBy,
                    Fk_Id = result.CustomerUID.ToString(),
                    CreatedDate = DateTime.Now,
                    FK_Type = EnumExtension.GetDisplayName(ExpenseType.Customer),
                    BranchId = customer.BranchId
                };

                affectedRows += await _ObjCommonDAL.DocumentsAdd(document, sqlConnectionFactory);
            }

            return (result.CustomerUID, affectedRows);



        }
        public async Task<int> DeleteCustomer(Customer customer, ISqlConnectionFactory sqlConnectionFactory)
        {
            return await _objCustomerDAL.DeleteCustomer(customer, sqlConnectionFactory);
        }
         
    }
}
