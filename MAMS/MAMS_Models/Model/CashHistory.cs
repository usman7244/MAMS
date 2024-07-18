using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS_Models.Model
{
    public class CashHistory
    {
        public int UID { get; set; }
        public string Details { get; set; }
        public string CashProfit { get; set; }
        public string CashLost { get; set; }
        public string TotalCash { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Guid BranchId { get; set; }
        public DateTime FromDate {  get; set; }
        public DateTime ToDate {  get; set; }


    }
}
