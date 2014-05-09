using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using sms_source.Areas.admin.Models;
using System.Web.Script.Serialization;

namespace sms_source.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DbContext<account> _dbAccount = new DbContext<account>();
        public ActionResult Login()
        {

            //var json = new HttpCookie("flc_user");
            //if (json != null)
            //{
            //    System.Web.Script.Serialization.JavaScriptSerializer serializer =
            //        new System.Web.Script.Serialization.JavaScriptSerializer();
            //    account acc = serializer.Deserialize<account>(json.ToString());
            //    if (acc.role == 1)
            //        Response.Redirect("admin-manage/");
            //    else
            //        Response.Redirect("partner-manage/");
            //}
            ViewBag.status = new HtmlString("Vui lòng <b>Tài khoản</b> và <b>Mật khẩu</b>..");
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            if (form.Get("login") != "" && form.Get("password") != "")
            {
                _dbAccount.Select(new[] { "username", "id","role" });
                _dbAccount.Where("username", form.Get("login"));
                _dbAccount.Where("password", form.Get("password"));
                List<account> obj = _dbAccount.FetchObject();
                if(obj.Count ==1){
                    account acc = obj[0];
                    if (form.Get("remember_me").ToString() == "check")
                    {
                        System.Web.Script.Serialization.JavaScriptSerializer serializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                        var json = serializer.Serialize(acc);
                        var userCookie = new HttpCookie("flc_user", json);
                        userCookie.Expires.AddDays(2);
                        HttpContext.Response.Cookies.Add(userCookie);
                    }
                    if(acc.role == 1)
                        Response.Redirect("admin-manage/");
                    else
                        Response.Redirect("partner-manage/");
                }else
                    ViewBag.status = new HtmlString("<b>Tài khoản</b> hoặc <b>Mật khẩu</b> không tồn tại ...");                
            }
            else
                ViewBag.status = new HtmlString("<b>Tài khoản</b> hoặc <b>Mật khẩu</b> không được để trống..");
            ViewBag.user = form.Get("login");
            ViewBag.pass = form.Get("password");
            
            return View();
        }

    }
}
