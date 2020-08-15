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
    public class HoController : Controller
    {
        HoResponsitory db = new HoResponsitory();
        // GET: Admin/NguoiDung
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            ViewBag.ListBo = db.getAllListBo();
            int pageNumber = (page ?? 1);
            IEnumerable<HoViewModel> list = db.getAllListHo(null);
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        public PartialViewResult _PartialHo(int? page, string keyword)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<HoViewModel> list = db.getAllListHo(keyword);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddHo()
        {

            HoViewModel model = new HoViewModel();
            model.TenHo = Request.Form["TenBo"];
            model.IDBo = Int32.Parse(Request.Form["IDLop"]);
            int result = db.AddHo(model);
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
        public JsonResult EditHo()
        {

            HoViewModel model = new HoViewModel();
            model.ID = Int32.Parse(Request.Form["id"]);
            model.TenHo = Request.Form["TenBo"];
            model.IDBo = Int32.Parse(Request.Form["IDLop"]);
            int result = db.EditHo(model);
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
        public JsonResult DeleteHo()
        {
            int id = Int32.Parse(Request.Form["id"]);
            int result = db.DeleteHo(id);
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