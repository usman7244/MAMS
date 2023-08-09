using MAMS_Models.Model;
using MAMS_Models.Extenions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
   public class CropDAL
    {
        private ConnectionLayer _connection;
        private List<Crop> _croplist;
        private Crop _crop;

        public CropDAL()
        {
            _connection = new ConnectionLayer();
            _croplist = new List<Crop>();
            _crop = new Crop();
        }
        public List<Crop> GetCropInfo(Crop crop )
        {
            _croplist = new List<Crop>();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.Parameters.AddWithValue("@BranchId", crop.BranchId);
                    cmd.Parameters.AddWithValue("@CreatedBy", crop.CreatedBy);

                    cmd.CommandText = "spGetAllCrop";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _crop = new Crop();
                            _crop.UID = Convert.ToInt32(reader["UID"]);
                            _crop.Name = reader["Name"].ToString();
                            _crop.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                            _crop.UserName = reader["CreatedBy"].ToString();
                            _croplist.Add(_crop);
                        }
                    }
                    reader.Close();
                }
            }
            _connection.ConnectionClose();
            return _croplist;
        }
        public int CropAdd(Crop crop)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spCreateCrop";
                    cmd.Parameters.AddWithValue("@Name", crop.Name);
                    cmd.Parameters.AddWithValue("@CreatedBy", crop.CreatedBy);
                    cmd.Parameters.AddWithValue("@BranchId", crop.BranchId);
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }
        public Crop GetSpecificCropInfo(int Id)
        {
            _crop = new Crop();
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spGetCrop";
                    cmd.Parameters.AddWithValue("@UID", Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _crop.UID = Convert.ToInt32(reader["UID"]);
                            _crop.Name = reader["Name"].ToString();                           
                            _crop.CreatedBy = reader["CreatedBy"].ToString().ToGuid();                           
                            _crop.CreatedDate =Convert.ToDateTime( reader["CreatedDate"].ToString());                           
                        }
                    }
                    reader.Close();
                }
            }
            _connection.ConnectionClose();
            return _crop;
        }
        public int EditCrop(Crop crop)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spUpdateCrop";
                    cmd.Parameters.AddWithValue("@UID", crop.UID);
                    cmd.Parameters.AddWithValue("@Name", crop.Name);
                    cmd.Parameters.AddWithValue("@ModifiedBy", crop.ModifiedBy);
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }
        public int DeleteCrop(Crop crop)
        {
            int effectedRows = 0;
            using (_connection._connection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    _connection.ConnectionOpen();
                    cmd.Connection = _connection._connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.CreateCommand();
                    cmd.CommandText = "spDeleteCrop";
                    cmd.Parameters.AddWithValue("@UID", crop.UID);
                    cmd.Parameters.AddWithValue("@ModifiedBy", crop.ModifiedBy);
                    effectedRows = cmd.ExecuteNonQuery();
                }
            }
            _connection.ConnectionClose();
            return effectedRows;
        }
    }
}
