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
}
