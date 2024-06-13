using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMS_Models.Model
{
    public class Role
    {
        public int UID { get; set; }

        public string Name { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
    }
}
