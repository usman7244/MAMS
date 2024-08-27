using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace MAMS_Models.Model
{
    public class Customer
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CusType { get; set; }
        public string ComShopName { get; set; }
        public string ComAddress { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Guid BranchId { get; set; }
        public List<IFormFile> UserFiles {  get; set; }
        public List<string> UserFilesUrl {  get; set; }
        public List<Documents> Documents { get; set; }

    }
}
