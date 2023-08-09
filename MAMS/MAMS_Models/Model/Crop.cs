using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS_Models.Model
{
   public class Crop
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Guid BranchId { get; set; }
        public string UserName { get; set; }
    }
}
