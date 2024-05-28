using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS_Models.Model
{
    public class Expense
    {
        public int UID { get; set; }
        public string ExpDescription { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public int Fk_Purchase { get; set; }     
        public int Fk_Sale { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public Guid BranchId { get; set; }
        public bool IsOld { get; set; }
    }
}
