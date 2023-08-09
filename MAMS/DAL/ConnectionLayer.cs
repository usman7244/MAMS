using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class ConnectionLayer
    {
       
        public SqlConnection _connection;        
        public ConnectionLayer()
        {
            //_connection = new SqlConnection(@"Data Source=192.168.0.201;Initial Catalog=MAMS;User ID=xprt;Password=xprt;");
            _connection = new SqlConnection(@"Server=DESKTOP-QI6H2EA;Database=MAMS;Trusted_Connection=True;");
        }        
        public  void ConnectionOpen()
        {
            if (_connection.ConnectionString=="")
            {
                //_connection = new SqlConnection(@"Data Source=192.168.0.201;Initial Catalog=MAMS;User ID=xprt;Password=xprt;");
                _connection = new SqlConnection(@"Server=DESKTOP-QI6H2EA;Database=MAMS;Trusted_Connection=True;");
            }

            _connection.Open();

        }
        public void ConnectionClose()
        {
            _connection.Close();
        }


         
    }
}
