using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS_Models.Model
{
    public class Sale
    {
        public int UID { get; set; }
        public string FK_CustomerType { get; set; }
        public string CustomerName { get; set; } 
        public Guid Fk_Customer { get; set; }
        public int Fk_Crop { get; set; }
        public string CropName { get; set; }
        public int WeightInMaun { get; set; }
        public Decimal WeightInkg { get; set; }
        public Decimal TotalCropWeight { get; set; }
        public int PriceInMaun { get; set; }
        public int PriceInKg { get; set; }
        public int TotalCropPrice { get; set; }
        public int TotalExp { get; set; }
        public int TotalAmountwithExp { get; set; }
        public int FK_BagType { get; set; }
        public int BagWeight { get; set; }
        public int BagTotal { get; set; } 
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; } 
        public Guid? BranchId { get; set; }
        public string UserName { get; set; }
        public int PurchasePrice { get; set; }
        public int PurchaseExp { get; set; }
        public string Status { get; set; }
        public string DiffCash { get; set; }
    }
}
