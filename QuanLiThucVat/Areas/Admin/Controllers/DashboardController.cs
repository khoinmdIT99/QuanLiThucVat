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
    public class DashboardController : Controller
    {       
        DashBoardResponsitory db = new DashBoardResponsitory();
        [Auth(Role = false)]
        public ActionResult Index()
        {
           DashBoardViewModel model = db.GetDashBoard();
            return View(model);
        }
    }
}