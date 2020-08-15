using PagedList;
using QuanLiThucVat.Authozie;
using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Areas.Admin.Controllers
{
    [Auth(Role =true)]
    public class NguoiDungController : Controller
    {
        NguoiDungResponsitory db = new NguoiDungResponsitory();
        // GET: Admin/NguoiDung
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<NguoiDungViewModel> list = db.getAllListNguoiDung(null);
            list = list.ToPagedList(pageNumber, pageSize);         
            return View(list);
        }
        public PartialViewResult _PartialNguoiDung(int? page,string keyword)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<NguoiDungViewModel> list = db.getAllListNguoiDung(keyword);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddNguoiDung()
        {
            DateTime? ngaySinh;
            bool gioiTinh = (Request.Form["sex"] == "true" ? true : false);
            NguoiDungViewModel model = new NguoiDungViewModel();
            model.Email = Request.Form["email"];
            model.MatKhau = Request.Form["password"];
            model.HoTen = Request.Form["fullname"];
            model.DiaChi = Request.Form["address"];
            model.GioiTinh = gioiTinh;
            string [] arrBirthday = Request.Form["birthday"].Split('/');
            if (arrBirthday.Length > 1)
            {
                ngaySinh = Convert.ToDateTime(arrBirthday[2] + "/" + arrBirthday[1] + "/" + arrBirthday[0]);
            }
            else
            {
                ngaySinh = null;
            }
            model.NgaySinh = ngaySinh;
            model.SoDienThoai = Request.Form["phone"];
            model.DuongDanHInhAnh = UploadImage() != null ? UploadImage() : "/Media/images/imagedefaut.jpg";

            int result = db.AddNguoiDung(model);
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
        public JsonResult EditNguoiDung()
        {
            DateTime? ngaySinh;
            bool gioiTinh = (Request.Form["sex"] == "true" ? true : false);
            NguoiDungViewModel model = new NguoiDungViewModel();
            model.ID = Int32.Parse(Request.Form["id"]); 
            model.Email = Request.Form["email"];
            model.MatKhau = Request.Form["password"];
            model.HoTen = Request.Form["fullname"];
            model.DiaChi = Request.Form["address"];
            model.GioiTinh = gioiTinh;
            string[] arrBirthday = Request.Form["birthday"].Split('/');
            if (arrBirthday.Length > 1)
            {
                ngaySinh = Convert.ToDateTime(arrBirthday[2] + "/" + arrBirthday[1] + "/" + arrBirthday[0]);
            }
            else
            {
                ngaySinh = null;
            }
            model.NgaySinh = ngaySinh;
            model.SoDienThoai = Request.Form["phone"];
            model.DuongDanHInhAnh = UploadImage() != null ? UploadImage() : Request.Form["path"];

            int result = db.EditNguoiDung(model);
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
        public JsonResult DeleteNguoiDung()
        {
            int id = Int32.Parse(Request.Form["id"]);
            int result = db.DeleteNguoiDung(id);
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
        public JsonResult CheckEmailExist()
        {
            string email = Request.Form["email"];
            return Json(!db.CheckEmailExist(email));

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