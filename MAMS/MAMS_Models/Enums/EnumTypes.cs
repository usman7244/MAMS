using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace MAMS_Models.Enums
{
    public class EnumTypes
    {
        public enum ExpenseType
        {

            [Display(Name = "Purchase")]
            Purchase = 1,

            [Display(Name = "Saled")]
            Saled = 2,

            [Display(Name = "DailyExpense")]
            DailyExpense = 3,

            [Display(Name = "Crop")]
            Crop = 4,

            [Display(Name = "Bag")]
            Bag = 5,

            [Display(Name = "Credit")]
            Credit = 6,

            [Display(Name = "Debit")]
            Deposit = 7,
            [Display(Name = "Sale")]
            Sale = 8,


        }

    }
    public enum StatusEnum
    {
        [Display(Name = "InStock")]
        Status = 1,
     
    }
    public enum CustomClaimType
    {
        
        [Display(Name = "Email")]
        Email = 1,
        [Display(Name = "Name")] 
        Name = 2,
        [Display(Name = "Fullname")]
        Fullname = 3,
        [Display(Name = "Userid")]
        Userid = 4, 
       [Display(Name = "RoleId")]
        RoleId = 5,
        [Display(Name = "BranchId")]
        BranchId = 6,
    }
}
