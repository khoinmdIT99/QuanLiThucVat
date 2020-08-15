using PagedList;
using QuanLiThucVat.Authozie;
using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Areas.Admin.Controllers
{
    [Auth(Role = false)]
    public class BangXepHangController : Controller
    {
        BangXepHangResponsitory db = new BangXepHangResponsitory();
  

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<BangXepHangViewModel> list = db.getBangXepHang();
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        public ActionResult CacPhuongPhap(int? page, int item)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<BangXepHangViewModel> list = db.getBangXepHang();
            IEnumerable<BangXepHangViewModel> listResult = null;
            ViewBag.item = item;
            ViewBag.tc1 = false;
            ViewBag.tc2 = false;
            ViewBag.tc3 = false;
            ViewBag.tc4 = false;
            ViewBag.tc5 = false;
            ViewBag.tc6 = false;
            ViewBag.tc7 = false;
            ViewBag.tc8 = false;
            ViewBag.tc9 = false;
            ViewBag.tc10 = false;
            ViewBag.tc11 = false;
            if (item == 1)
            {

                listResult = db.ConvertBangXepHangThuHangfilter(list, true, true, true, true, true, true, true, true, true, true, true, null);

            }
            else if (item == 2)
            {
                listResult = db.ConvertBangXepHangCanhTacfilter(list, true, true, true, true, true, true, true, true, true, true, true, null);

            }
            else
            {
                listResult = db.ConvertBangXepHangCanhTacCaiTienfilter(list, true, true, true, true, true, true, true, true, true, true, true, null);


            }

            listResult = listResult.ToPagedList(pageNumber, pageSize);
            return View(listResult);

        }
        public PartialViewResult _PartialCacPhuongPhap(int? page, int item, string keyword, bool tc1, bool tc2, bool tc3, bool tc4, bool tc5, bool tc6, bool tc7,
            bool tc8, bool tc9, bool tc10, bool tc11)
        {
            ViewBag.item = item;
            ViewBag.keyword = keyword;
            ViewBag.tc1 = tc1;
            ViewBag.tc2 = tc2;
            ViewBag.tc3 = tc3;
            ViewBag.tc4 = tc4;
            ViewBag.tc5 = tc5;
            ViewBag.tc6 = tc6;
            ViewBag.tc7 = tc7;
            ViewBag.tc8 = tc8;
            ViewBag.tc9 = tc9;
            ViewBag.tc10 = tc10;
            ViewBag.tc11 = tc11;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<BangXepHangViewModel> list = db.getBangXepHang();
            IEnumerable<BangXepHangViewModel> listResult = null;
            if (item == 1)
            {
                if (tc1 || tc2 || tc3 || tc4 || tc5 || tc6 || tc7 || tc8 || tc9 || tc10 || tc11)
                {
                    listResult = db.ConvertBangXepHangThuHangfilter(list, tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, keyword);
                }
                else
                {
                    listResult = db.ConvertBangXepHangThuHangfilter(list, true, true, true, true, true, true, true, true, true, true, true, keyword);


                }

            }
            else if (item == 2)
            {
                if (tc1 || tc2 || tc3 || tc4 || tc5 || tc6 || tc7 || tc8 || tc9 || tc10 || tc11)
                {
                    listResult = db.ConvertBangXepHangCanhTacfilter(list, tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, keyword);
                }
                else
                {
                    listResult = db.ConvertBangXepHangCanhTacfilter(list, true, true, true, true, true, true, true, true, true, true, true, keyword);


                }

            }
            else
            {
                if (tc1 || tc2 || tc3 || tc4 || tc5 || tc6 || tc7 || tc8 || tc9 || tc10 || tc11)
                {
                    listResult = db.ConvertBangXepHangCanhTacCaiTienfilter(list, tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, keyword);
                }
                else
                {
                    listResult = db.ConvertBangXepHangCanhTacCaiTienfilter(list, true, true, true, true, true, true, true, true, true, true, true, keyword);

                }
            }

            listResult = listResult.ToPagedList(pageNumber, pageSize);
            return PartialView(listResult);
        }
        public ActionResult TongHop(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.tc1 = false;
            ViewBag.tc2 = false;
            ViewBag.tc3 = false;
            ViewBag.tc4 = false;
            ViewBag.tc5 = false;
            ViewBag.tc6 = false;
            ViewBag.tc7 = false;
            ViewBag.tc8 = false;
            ViewBag.tc9 = false;
            ViewBag.tc10 = false;
            ViewBag.tc11 = false;
            IEnumerable<BangXepHangViewModel> list = db.BangXepHangTongHopfilter(db.getBangXepHang(), true, true, true, true, true, true, true, true, true, true, true, null);
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        public PartialViewResult _PartialTongHop(int? page, string keyword, bool tc1, bool tc2, bool tc3, bool tc4, bool tc5, bool tc6, bool tc7,
            bool tc8, bool tc9, bool tc10, bool tc11)
        {
            ViewBag.keyword = keyword;
            ViewBag.tc1 = tc1;
            ViewBag.tc2 = tc2;
            ViewBag.tc3 = tc3;
            ViewBag.tc4 = tc4;
            ViewBag.tc5 = tc5;
            ViewBag.tc6 = tc6;
            ViewBag.tc7 = tc7;
            ViewBag.tc8 = tc8;
            ViewBag.tc9 = tc9;
            ViewBag.tc10 = tc10;
            ViewBag.tc11 = tc11;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (tc1 || tc2 || tc3 || tc4 || tc5 || tc6 || tc7 || tc8 || tc9 || tc10 || tc11)
            {
                IEnumerable<BangXepHangViewModel> list = db.BangXepHangTongHopfilter(db.getBangXepHang(), tc1, tc2, tc3, tc4, tc5, tc6, tc7, tc8, tc9, tc10, tc11, keyword);
                list = list.ToPagedList(pageNumber, pageSize);
                return PartialView(list);
            }
            else
            {
                IEnumerable<BangXepHangViewModel> list = db.BangXepHangTongHopfilter(db.getBangXepHang(), true, true, true, true, true, true, true, true, true, true, true, keyword);
                list = list.ToPagedList(pageNumber, pageSize);
                return PartialView(list);
            }

        }
    }
}