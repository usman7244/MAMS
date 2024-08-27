using DAL.Sql;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ImageBOL
    {
        private DAL.ImageDAL _objImgDAL;
 
        public ImageBOL()
        {
            _objImgDAL = new DAL.ImageDAL();
          
        }
        public async Task<List<Documents>> GetAllImg(ISqlConnectionFactory connectionFactory)
        {
            var result = await _objImgDAL.GetAllImg( connectionFactory);
            return result;
        }
        //public async Task<int> ImageAdd(List<IFormFile> UserFile, ISqlConnectionFactory connectionFactory)
        //{
        //    int affectedRows = 0;
        //    try
        //    {
        //        if (UserFile != null && UserFile.Count > 0)
        //        {
        //            affectedRows = await _objImgDAL.ImageAdd(UserFile, connectionFactory);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception if needed
        //        throw new Exception("Error in business logic layer: " + ex.Message);
        //    }
        //    return affectedRows;
        //}

    }

}
