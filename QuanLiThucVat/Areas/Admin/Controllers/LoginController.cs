using QuanLiThucVat.Models;
using QuanLiThucVat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        LoginResponsitory db = new LoginResponsitory();
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session["NguoiDung"]!=null)
            {
                return RedirectToAction("index", "Dashboard");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(NguoiDungViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.MatKhau = MaHoaMD5(model.MatKhau);
                if (db.Login(model) != null)
                {
                    Session["NguoiDung"] = db.Login(model);
                    return RedirectToAction("index", "Dashboard");
                }
                ModelState.AddModelError("", "Email  hoặc mât khẩu không đúng");
            }

            return View(model);
        }
       
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Login");
        }
        public string MaHoaMD5(String text)
        {
            string result = "";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (byte b in buffer)
            {
                result += b.ToString("X2");
            }
            return result.ToLower();
        }
    }
}