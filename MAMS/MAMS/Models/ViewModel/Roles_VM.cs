using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Models.ViewModel
{
    public class Roles_VM
    {
        [Required]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        public int Priority { get; set; }
        public bool Status { get; set; } = true;
    }
}
