using BOL;
using DAL.Sql;
using MAMS.CustomFilters;
using MAMS_Models.Extenions;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MAMS_Models.Enums.EnumTypes;

namespace MAMS.Controllers
{
    
    [IdentityUser]
    public class CropController : BaseController
    {
        private Sale _sale;
        private List<Sale> _saleList;
        private SaleBOL _objSALEBOL;

        private readonly ISqlConnectionFactory _connectionFactory;
    
        private BOL.CropBOL _objCropBOL;
        private CropAndBag _crop;
        public CropController(ISqlConnectionFactory connectionFactory)
        {
            _objCropBOL = new BOL.CropBOL();
            _crop= new CropAndBag();

            _objSALEBOL = new SaleBOL();
            _sale = new Sale();
            _saleList = new List<Sale>();
            _connectionFactory = connectionFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _crop = new CropAndBag();
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            _crop.Type = string.Empty;
            List<CropAndBag> crops =await _objCropBOL.GetCropInfo(_crop, _connectionFactory);
        


            return View(crops);
        }

        public IActionResult CropAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CropAdd(CropAndBag crop)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows =await _objCropBOL.CropAdd(crop, _connectionFactory);
                if (affectedRows > 0)
                {
                    ViewBag.CropAddStatus = affectedRows;
                }
            }
          
            return View();
        }
        public async Task<IActionResult> EditCrop(int Id)
        {
            var crop =await _objCropBOL.GetSpecificCropInfo(Id, _connectionFactory);

            return View(crop);
        }
        [HttpPost]
        public async Task<IActionResult> EditCrop(CropAndBag crop)
        {

            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows = await _objCropBOL.EditCrop(crop, _connectionFactory);
                if (affectedRows > 0)
                {

                    //return RedirectToAction("Index");
                    ViewBag.CropAddStatus = affectedRows;

                }
               
            }
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCrop(int cropId)
        {
            _crop = new CropAndBag();
            _crop.ModifiedBy = Guid.Empty;
            _crop.UID = cropId;

            var  affectedRows =await _objCropBOL.DeleteCrop(_crop, _connectionFactory);
            return Ok(affectedRows);
        }
    }
}
