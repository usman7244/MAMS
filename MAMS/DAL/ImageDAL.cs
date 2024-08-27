using DAL.Sql;
using Dapper;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace DAL
{
    public class ImageDAL
    {
        public async Task<List<Documents>> GetAllImg(ISqlConnectionFactory connectionFactory)
        {
            var imgList = new List<Documents>();

            await using var connection = connectionFactory.CreateConnection();

           
            string SQLQuery = "EXEC [dbo].[GetAllImages]";

         
            var img = await connection.QueryAsync<Documents>(SQLQuery);

            imgList = img.ToList();

            return imgList;
        }

        //public async Task<int> ImageAdd(List<IFormFile> userFiles, ISqlConnectionFactory connectionFactory)
        //{
        //    int affectedRows = 0;
        //    try
        //    {
        //        using (var connection = connectionFactory.CreateConnection())
        //        {
        //            foreach (var file in userFiles)
        //            {
        //                // Read the file into a memory stream
        //                using (var memoryStream = new MemoryStream())
        //                {
        //                    await file.CopyToAsync(memoryStream);

        //                    var image = new Documents
        //                    {
        //                        ImageData = memoryStream.ToArray(),
        //                        ContentType = file.ContentType,
        //                        FileName = file.FileName
                                
        //                    };

        //                    // Insert the image data directly into the database
        //                    string sqlQuery = "INSERT INTO [dbo].[UploadImage] (ImageData, ContentType, FileName, UploadDate) VALUES (@ImageData, @ContentType, @FileName, @UploadDate)";
        //                    var parameters = new
        //                    {
        //                        ImageData = image.ImageData,
        //                        ContentType = image.ContentType,
        //                        FileName = image.FileName,
                               
        //                    };

        //                    affectedRows += await connection.ExecuteAsync(sqlQuery, parameters);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception if needed
        //        throw new Exception("Error in data access layer: " + ex.Message);
        //    }

        //    return affectedRows;
        //}

    }
}
