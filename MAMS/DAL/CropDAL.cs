using MAMS_Models.Model;
using MAMS_Models.Extenions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL.Sql;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace DAL
{
   public class CropDAL
    {
        private List<CropAndBag> _croplist;
        private CropAndBag _crop;

        public CropDAL()
        {
            _croplist = new List<CropAndBag>();
            _crop = new CropAndBag();
        }

        public async Task<List<CropAndBag>> GetCropInfo(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
          
            var cropList = new List<CropAndBag>();

            try
            {
                await using var connection = connectionFactory.CreateConnection();

                string SQLQuery = "EXEC [dbo].[spGetAllCrop] @BranchId, @CreatedBy, @Type";

                var crops = await connection.QueryAsync<CropAndBag>(SQLQuery, new { BranchId = crop.BranchId, CreatedBy = crop.CreatedBy, Type = crop.Type });

                cropList = crops.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception (assuming you have a logging mechanism in place)
                // For example: _logger.LogError(ex, "An error occurred while getting crop info.");
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Optionally, you can rethrow the exception or handle it as needed
                throw;
            }

            return cropList;
        }


        public async Task<int> CropAdd(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spCreateCrop] @Name, @CreatedBy, @BranchId,@Type";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { Name = crop.Name, CreatedBy = crop.CreatedBy, BranchId = crop.BranchId,Type=crop.Type });

            return effectedRows;
        }

        public async Task<CropAndBag> GetSpecificCropInfo(int Id, ISqlConnectionFactory connectionFactory)
        {
            CropAndBag crop = null;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spGetCrop] @UID";

            crop = await connection.QueryFirstOrDefaultAsync<CropAndBag>(SQLQuery, new { UID = Id });

            return crop;
        }


        public async Task<int> EditCrop(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spUpdateCrop] @UID, @Name, @ModifiedBy,@Type";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = crop.UID, Name = crop.Name, ModifiedBy = crop.ModifiedBy, Type = crop.Type });

            return effectedRows;
        }


      
        public async Task<int> DeleteCrop(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            int effectedRows = 0;

            await using var connection = connectionFactory.CreateConnection();

            string SQLQuery = "EXEC [dbo].[spDeleteCrop] @UID, @ModifiedBy";

            effectedRows = await connection.ExecuteAsync(SQLQuery, new { UID = crop.UID, ModifiedBy = crop.ModifiedBy });

            return effectedRows;
        }



    }
}
