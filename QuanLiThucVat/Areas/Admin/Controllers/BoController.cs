using PagedList;
using QuanLiThucVat.Authozie;
using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Areas.Admin.Controllers
{
    [Auth(Role = false)]
    public class BoController : Controller
    {     
        BoResponsitory db = new BoResponsitory();
        // GET: Admin/NguoiDung
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<BoViewModel> list = db.getAllListBo(null);
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        public PartialViewResult _PartialBo(int? page, string keyword)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<BoViewModel> list = db.getAllListBo(keyword);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddBo()
        {

            BoViewModel model = new BoViewModel();
            model.TenBo = Request.Form["TenLop"];
            int result = db.AddBo(model);
            if (result == 1)
            {
                return Json(new { status = "SUCCESS" });
            }
            else
            {
                return Json(new { status = "ERROR" });
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult EditBo()
        {
          
            BoViewModel model = new BoViewModel();
            model.ID = Int32.Parse(Request.Form["id"]);
            model.TenBo = Request.Form["TenLop"];           
            int result = db.EditBo(model);
            if (result == 1)
            {
                return Json(new { status = "SUCCESS" });
            }
            else
            {
                return Json(new { status = "ERROR" });
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteBo()
        {
            int id = Int32.Parse(Request.Form["id"]);
            int result = db.DeleteBo(id);
            if (result == 1)
            {
                return Json(new { status = "SUCCESS" });
            }
            else
            {
                return Json(new { status = "ERROR" });
            }
        }
    }
}