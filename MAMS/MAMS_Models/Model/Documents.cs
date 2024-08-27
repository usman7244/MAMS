using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMS_Models.Model
{
    public class Documents
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        public IFormFile File { get; set; }
        public string ContentType { get; set; }
        public string DocumentId { get; set; }
        public Guid BranchId { get; set; }

         
        public string Base64Image { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public string FK_Type { get; set; }
        public string Fk_Id { get; set; }
        public string fileUrl { get; set; }
        public string FileId { get; set; }
    }
}
