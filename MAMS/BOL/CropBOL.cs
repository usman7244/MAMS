using MAMS_Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOL
{
    public class CropBOL
    {
        private DAL.CropDAL _objCropDAL;
        public CropBOL()
        {
            _objCropDAL = new DAL.CropDAL();

        }
        public List<Crop> GetCropInfo(Crop crop)
        {
            return _objCropDAL.GetCropInfo(crop);
        }
        public int CropAdd(Crop crop)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows = _objCropDAL.CropAdd(crop);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public Crop GetSpecificCropInfo(int Id)
        {
            return _objCropDAL.GetSpecificCropInfo(Id);
        }
        public int EditCrop(Crop crop)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows = _objCropDAL.EditCrop(crop);
                return affectedRows;
            }
            else
            {
                return affectedRows;
            }
        }
        public int DeleteCrop(Crop crop)
        {
            return _objCropDAL.DeleteCrop(crop);
        }
    }
}
