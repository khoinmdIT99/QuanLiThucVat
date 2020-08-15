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
    public class TinTucController : Controller
    {
        TinTucResponsitory db = new TinTucResponsitory();
        public ActionResult Index(int?page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            IEnumerable<TinTucViewModel> list = db.getAllListTinTuc(null);
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        public ActionResult _PartialNew(int? page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            IEnumerable<TinTucViewModel> list = db.getAllListTinTuc(null);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }
        public ActionResult Detail(int id)
        {
            TinTucViewModel model = db.getTinTucById(id);
            ViewBag.listNew = db.getListTinTuc();
            return View(model);
        }
    }
}