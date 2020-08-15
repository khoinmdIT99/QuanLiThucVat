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
    public class NewController : Controller
    {
        TinTucResponsitory db = new TinTucResponsitory();
        public ActionResult Index(int ?page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<TinTucViewModel> list = db.getAllListTinTuc(null);
            list = list.ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        public ActionResult _PartialNew(int? page, string keyword)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<TinTucViewModel> list = db.getAllListTinTuc(keyword);
            list = list.ToPagedList(pageNumber, pageSize);
            return PartialView(list);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddNew()
        {
            TinTucViewModel model = new TinTucViewModel();
            var form = Request.Form;
            model.TieuDe = Request.Form["TieuDe"];
            model.DanNhap = Request.Form["DanNhap"];
            model.NoiDung = Request.Form["NoiDung"];
            model.DuongDanHinhAnh = UploadImage() != null ? UploadImage() : "/Media/images/imagedefaut.jpg";
            int result = db.AddTinTuc(model);
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
        public JsonResult EditNew()
        {
            TinTucViewModel model = new TinTucViewModel();
            model.ID = Int32.Parse(Request.Form["id"]);
            model.TieuDe = Request.Form["TieuDe"];
            model.DanNhap = Request.Form["DanNhap"];
            model.NoiDung = Request.Form["NoiDung"];
            model.DuongDanHinhAnh = UploadImage() != null ? UploadImage() : Request.Form["path"];
            int result = db.EditTinTuc(model);
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
        public JsonResult DeleteNew()
        {
            int id = Int32.Parse(Request.Form["id"]);
            int result = db.DeleteTinTuc(id);
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