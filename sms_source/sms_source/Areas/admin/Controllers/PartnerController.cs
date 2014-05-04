using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sms_source.Areas.admin.Models;

namespace sms_source.Areas.admin.Controllers
{
    public class PartnerController : Controller
    {
        //
        // GET: /admin/Partner/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(partner objPartner,account acc)
        {
            if (ModelState.IsValid) {
                return Content(objPartner.email,acc.username);
            }
            return Content("");
            
        }

    }
}
