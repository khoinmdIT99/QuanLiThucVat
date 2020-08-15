using PagedList;
using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ThucVatResponsitory db = new ThucVatResponsitory();
        public ActionResult Index(int? page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            IEnumerable<ThucVatViewModel> list = db.getAllListThucVat("", "", "0", "0");
            list = list.ToPagedList(pageNumber, pageSize);
            ViewBag.ListKhaNangSinhTruong = db.getListKhaNangSinhTruong();
            ViewBag.ListKhaNangTaiSinh = db.getListKhaNangTaiSinh();
            ViewBag.ListGiaTriKinhTe = db.getListGiaTriKinhTe();
            ViewBag.ListHo = db.getListHo();
            ViewBag.ListBo = db.getListBo();
            ViewBag.tenVietNam = "";
            ViewBag.tenLaTinh = "";
            ViewBag.IDBo = "0";
            ViewBag.IDHo = "0";

            return View(list);
        }
        public ActionResult _PartialIndex(int? page, string tenVietNam="", string tenLaTinh="", string IDBo="0", string IDHo="0")
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            ViewBag.tenVietNam = tenVietNam;
            ViewBag.tenLaTinh = tenLaTinh;
            ViewBag.IDBo = IDBo;
            ViewBag.IDHo = IDHo;
            IEnumerable<ThucVatViewModel> list = db.getAllListThucVat(tenVietNam, tenLaTinh, IDBo, IDHo);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }
        public ActionResult Detail(int id)
        {
            try
            {
                
                ThucVatViewModel model = db.getListThucVatById(id);
                ViewBag.ListSameGrowth = db.getAllListThucVat(null).Where(x => x.ID != id && x.IDKhaNangSinhTruong == model.IDKhaNangSinhTruong).Take(3).ToList();
                ViewBag.ListSameEconomy = db.getAllListThucVat(null).Where(x => x.ID != id && x.IDGiaTriKinhTe == model.IDGiaTriKinhTe).ToList();
                return View(model);
            }
            catch
            {
                return new HttpNotFoundResult("optional description");
            }

        }
        public JsonResult getListHoByBoID(int id)
        {
            //int id = Int32.Parse(Request.Form["id"]);
            List<HoViewModel> list = db.getListHoByBoID(id);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}