using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Controllers
{
    public class GioiThieuController : Controller
    {
        TinTucResponsitory db = new TinTucResponsitory();
        public ActionResult Index()
        {
            List<TinTucViewModel> list = db.getListTinTuc();
            return View(list);
        }
    }
}