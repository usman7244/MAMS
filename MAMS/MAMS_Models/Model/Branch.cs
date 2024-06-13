using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMS_Models.Model
{
    public class Branch
    {
        public Guid UID { get; set; }
        public Guid CompanyUID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
