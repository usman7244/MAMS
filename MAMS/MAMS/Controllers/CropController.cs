using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class CropController : Controller
    {
        private BOL.CropBOL _objCropBOL;
        private Crop _crop;
        public CropController()
        {
            _objCropBOL = new BOL.CropBOL();
            _crop= new Crop();
        }
        public IActionResult Index()
        {
            _crop = new Crop();
            _crop.BranchId = Guid.Empty;
            _crop.CreatedBy = Guid.Empty;
            List<Crop> crops = _objCropBOL.GetCropInfo(_crop);
            return View(crops);
        }

        public IActionResult CropAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CropAdd(Crop crop)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows = _objCropBOL.CropAdd(crop);
                if (affectedRows > 0)
                {
                    ModelState.Clear();
                }
            }
            ViewBag.CropAddStatus = affectedRows;
            return View();
        }
        public IActionResult EditCrop(int Id)
        {
            var crop = _objCropBOL.GetSpecificCropInfo(Id);

            return View(crop);
        }
        [HttpPost]
        public IActionResult EditCrop(Crop crop)
        {
            int affectedRows = 0;
            if (crop != null)
            {
                affectedRows = _objCropBOL.EditCrop(crop);
                if (affectedRows > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CropAddStatus = affectedRows;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCrop(int cropId)
        {
            _crop = new Crop();
            _crop.ModifiedBy = Guid.Empty;
            _crop.UID = cropId;

            int affectedRows = _objCropBOL.DeleteCrop(_crop);
            return Ok(affectedRows);
        }
    }
}
