using Helper;
using sms_source.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sms_source.Areas.admin.Controllers
{
    public class CommandCodeController : Controller
    {
        //
        // GET: /admin/CommandCode/

        DbContext<service_numbers> _dbServiceNumbers = new DbContext<service_numbers>();
        DbContext<partner> _dbPartner = new DbContext<partner>();
        DbContext<events> _dbEvents = new DbContext<events>();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {

            _dbServiceNumbers.Select();
            ViewBag.service = _dbServiceNumbers.FetchObject();

            _dbPartner.Select();
            ViewBag.partner = _dbPartner.FetchObject();

            _dbEvents.Select();
            ViewBag.events = _dbEvents.FetchObject(); 

            return View();
        }

    }
}
