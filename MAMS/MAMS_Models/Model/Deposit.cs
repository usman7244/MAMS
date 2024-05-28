using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS_Models.Model
{
    public class Deposit
    {
        public Guid BranchId { get; set; }
        public string CustomerType { get; set; }
        public int UID { get; set; }
        public string TotalCash { get; set; }

        public string CustomerName { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid FKCustomer { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
