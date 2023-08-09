using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DAL.Sql
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
