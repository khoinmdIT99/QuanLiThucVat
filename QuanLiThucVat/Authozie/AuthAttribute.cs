using QuanLiThucVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThucVat.Authozie
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public bool Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            bool skipAuthorize = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                            || filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (skipAuthorize)
            {
                return;
            }

            if (HttpContext.Current.Session["NguoiDung"] != null)
            {
                var user = (NguoiDungViewModel)HttpContext.Current.Session["NguoiDung"];

                if (Role == true && user.LaQuanTriVienCapCao != true)
                {
                    filterContext.Result = new RedirectResult("~/Home/Http404NotFound");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Admin/Login");
            }
        }
    }
}