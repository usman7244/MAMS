using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Connections;
using BOL;
using DAL.Sql;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class ImageController : Controller
    {
        private Documents _UploadImage;
        private readonly ISqlConnectionFactory _connectionFactory;
        private ImageBOL _objImgBOL;
        private Documents _img;
        public ImageController(ISqlConnectionFactory connectionFactory)
        {

            _UploadImage = new Documents();
            _connectionFactory = connectionFactory;
            _img = new Documents();
            _objImgBOL = new ImageBOL();

        }
        //public async Task<IActionResult> Index()
        //{
        //    List<Documents> imgList = await _objImgBOL.GetAllImg(_connectionFactory);

        //    foreach (var image in imgList)
        //    {
        //        image.Base64Image = Convert.ToBase64String(image.ImageData);
        //    }

        //    return View(imgList);
        //}

       
        //public async Task<IActionResult> ImageAdd(List<IFormFile> UserFile)
        //{
        //    try
        //    {
             
        //        var affectedRows = await _objImgBOL.ImageAdd(UserFile, _connectionFactory);

        //        if (affectedRows > 0)
        //        {
        //            ViewBag.CreditAddStatus = "Images added successfully.";
        //        }
        //        else
        //        {
        //            ViewBag.CreditAddStatus = "Failed to add images.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "Error while uploading files: " + ex.Message;
        //        ViewBag.CreditAddStatus = "Failed to add images.";
        //    }

        //    return View();
        //}



    }
}
