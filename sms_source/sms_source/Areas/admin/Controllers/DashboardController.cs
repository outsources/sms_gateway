using Helper;
using sms_source.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sms_source.Areas.admin.Controllers
{
    public class DashboardController : Controller
    {

        public ActionResult Index()
        {
            var db = new DbContext<telcos>();
            db.Where("id", "10");
            db.Delete();
            var date = DateTime.Now;
            Response.Write(date);
            return View();
        }
    }
}
