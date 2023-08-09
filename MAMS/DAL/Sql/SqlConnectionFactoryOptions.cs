using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Sql
{
    public class SqlConnectionFactoryOptions
    {
        public string ConnectionString { get; set; }
        public int ConnectTimeout { get; set; }
    }
}
