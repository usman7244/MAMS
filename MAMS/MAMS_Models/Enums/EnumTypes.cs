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
        }
    }
}
