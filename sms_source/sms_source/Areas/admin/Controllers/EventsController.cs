using sms_source.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;

namespace sms_source.Areas.admin.Controllers
{
    public class EventsController : Controller
    {
        //
        // GET: /admin/Events/
        DbContext<events> _dbEvents = new DbContext<events>();
        public ActionResult Index()
        {
            _dbEvents.Select();
            _dbEvents.OrderBy("DESC");
            ViewBag.data = _dbEvents.FetchObject();
            
            return View();
        }

        [HttpGet]
        public ActionResult ajaxLoad()
        {
            _dbEvents.Select();
            _dbEvents.OrderBy("DESC");
            ViewBag.data = _dbEvents.FetchObject();
            return View();
        }

        [HttpPost]
        public ActionResult ajaxLoad(events e)
        {
            _dbEvents.Select();
            _dbEvents.Like("event_name", e.event_name, "%{0}%");
            _dbEvents.OrderBy("DESC");
            ViewBag.data = _dbEvents.FetchObject();
            return View();

            //return Content(_dbEvents.test());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Insert(events ev)
        {
            ev.create_date = DateTime.Now;
            ev.update_date = DateTime.Now;

            _dbEvents.Create(ev);
            _dbEvents.Save();

            return RedirectToAction("ajaxLoad");
        }
    }
}
