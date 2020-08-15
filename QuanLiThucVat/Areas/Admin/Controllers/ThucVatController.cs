using PagedList;
using QuanLiThucVat.Authozie;
using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Areas.Admin.Controllers
{
    [Auth(Role = false)]
    public class ThucVatController : Controller
    {
        ThucVatResponsitory db = new ThucVatResponsitory();
        // GET: Admin/ThucVat
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<ThucVatViewModel> list = db.getAllListThucVat(null);
            list = list.ToPagedList(pageNumber, pageSize);
            ViewBag.ListKhaNangSinhTruong = db.getListKhaNangSinhTruong();
            ViewBag.ListKhaNangTaiSinh = db.getListKhaNangTaiSinh();
            ViewBag.ListGiaTriKinhTe = db.getListGiaTriKinhTe();
            ViewBag.ListHo = db.getListHo();
            return View(list);
        }
        public PartialViewResult _PartialThucVat(string keyword, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<ThucVatViewModel> list = db.getAllListThucVat(keyword);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddThucVat()
        {
            ThucVatViewModel model = new ThucVatViewModel();
            model.TenVietNam = Request.Form["nameTV"];
            model.TenLaTinh = Request.Form["nameLT"];
            model.MoTa = Request.Form["description"];
            model.DoDayLa = double.Parse(Request.Form["DoDayLa"]);
            model.DoDayVo = double.Parse(Request.Form["DoDayVo"]);
            model.LuongNuocTrongLa = double.Parse(Request.Form["LuongNuocTrongLa"]);
            model.LuongNuocTrongVo = double.Parse(Request.Form["LuongNuocTrongVo"]);
            model.LuongTroThoTrongLa = double.Parse(Request.Form["LuongTroThoTrongLa"]);
            model.LuongTroThoTrongVo = double.Parse(Request.Form["LuongTroThoTrongVo"]);
            model.ThoiGianChayTrenLa = double.Parse(Request.Form["ThoiGianChayTrenLa"]);
            model.ThoiGianChayTrenVo = double.Parse(Request.Form["ThoiGianChayTrenVo"]);
            model.IDKhaNangSinhTruong = Int32.Parse(Request.Form["growth"]);
            model.IDKhaNangTaiSinh = Int32.Parse(Request.Form["reborn"]);
            model.IDGiaTriKinhTe = Int32.Parse(Request.Form["economy"]);
            model.IDHo = Int32.Parse(Request.Form["IDBo"]);
            model.DuongDanHInhAnh = UploadImage()!=null?UploadImage(): "/Media/images/imagedefaut.jpg";

            int result = db.AddThucVat(model);
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
        public JsonResult EditThucVat()
        {

            ThucVatViewModel model = new ThucVatViewModel();
            model.ID = Int32.Parse(Request.Form["id"]);
            model.TenVietNam = Request.Form["nameTV"];
            model.TenLaTinh = Request.Form["nameLT"];
            model.MoTa = Request.Form["description"];
            model.DoDayLa = double.Parse(Request.Form["DoDayLa"]);
            model.DoDayVo = double.Parse(Request.Form["DoDayVo"]);
            model.LuongNuocTrongLa = double.Parse(Request.Form["LuongNuocTrongLa"]);
            model.LuongNuocTrongVo = double.Parse(Request.Form["LuongNuocTrongVo"]);
            model.LuongTroThoTrongLa = double.Parse(Request.Form["LuongTroThoTrongLa"]);
            model.LuongTroThoTrongVo = double.Parse(Request.Form["LuongTroThoTrongVo"]);
            model.ThoiGianChayTrenLa = double.Parse(Request.Form["ThoiGianChayTrenLa"]);
            model.ThoiGianChayTrenVo = double.Parse(Request.Form["ThoiGianChayTrenVo"]);
            model.IDKhaNangSinhTruong = Int32.Parse(Request.Form["growth"]);
            model.IDKhaNangTaiSinh = Int32.Parse(Request.Form["reborn"]);
            model.IDGiaTriKinhTe = Int32.Parse(Request.Form["economy"]);
            model.IDHo= Int32.Parse(Request.Form["IDBo"]);
            model.DuongDanHInhAnh = UploadImage();

            int result = db.EditThucVat(model);
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
        public JsonResult DeleteThucVat()
        {
            int id = Int32.Parse(Request.Form["id"]);
            int result = db.DeleteThucVat(id);
            if (result == 1)
            {
                return Json(new { status = "SUCCESS" });
            }
            else
            {
                return Json(new { status = "ERROR" });
            }
        }
        public string UploadImage()
        {
            DateTime dateTime = DateTime.Now;
            string tick = dateTime.Ticks.ToString();
            string fname = "";
            string path = null; ;
            int size = 0;
            List<string> LIST_IMAGE_TYPE = new List<string>() { ".jpg", ".jpeg", ".gif", ".png" };
            List<dynamic> media = new List<dynamic>();

            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                            size = file.ContentLength / 1024;
                        }
                        if (LIST_IMAGE_TYPE.Contains(extension))
                        {
                            fname = Path.Combine(Server.MapPath("~/Media/images"), tick + extension);
                            file.SaveAs(fname);
                            path = "/Media/images/" + tick + extension;
                        }

                        media.Add(new { url = path });
                    }

                }

                catch (Exception)
                {
                    return path;
                }
                
            }
            return path;
        }

    }
}