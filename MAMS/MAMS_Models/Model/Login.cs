using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMS_Models.Model
{
    public class Login
    {
         
        [MaxLength(150)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        
         
    }
}
