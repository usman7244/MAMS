using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMS_Models.Model
{
    public class ConfigMgt
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RefreshToken { get; set; }
    }
}
