using DAL.Sql;
using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class CropBOL
    {
        private DAL.CropDAL _objCropDAL;
        public CropBOL()
        {
            _objCropDAL = new DAL.CropDAL();

        }
        public async Task<List<CropAndBag>> GetCropInfo(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            var result =await _objCropDAL.GetCropInfo(crop, connectionFactory);
            return result;
        }

        public async Task<int> CropAdd(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows =await _objCropDAL.CropAdd(crop, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public async Task<CropAndBag> GetSpecificCropInfo(int Id, ISqlConnectionFactory connectionFactory)
        {
            var result=await _objCropDAL.GetSpecificCropInfo(Id, connectionFactory);
            return result;
        }
        public async Task<int> EditCrop(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows =await _objCropDAL.EditCrop(crop, connectionFactory);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public Task <int> DeleteCrop(CropAndBag crop, ISqlConnectionFactory connectionFactory)
        {
            return _objCropDAL.DeleteCrop(crop,connectionFactory);
        }
    }
}
