using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sms_source.Areas.admin.Models;
using Helper;

namespace sms_source.Areas.admin.Controllers
{
    public class PartnerController : Controller
    {
        //
        // GET: /admin/Partner/
        DbContext<account> _dbAccount = new DbContext<account>();
        DbContext<partner> _dbPartner = new DbContext<partner>();
        public ActionResult Index()
        {
            _dbPartner.Select();
            _dbPartner.Join<account>("account.id", "partner.account_id");
            _dbPartner.OrderBy("partner.id", "DESC");
            ViewBag.data = _dbPartner.FetchTable();
            return View();
        }

        [HttpGet]
        public ActionResult ajaxLoad()
        {
            _dbPartner.Select();
            _dbPartner.Join<account>("account.id", "partner.account_id");
            _dbPartner.OrderBy("partner.id", "DESC");
            ViewBag.data = _dbPartner.FetchTable();
            
            return View();
        }

        [HttpPost] // danh cho search
        public ActionResult ajaxLoad(FormCollection fl)
        {
            _dbPartner.Select();
            _dbPartner.Join<account>("account.id", "partner.account_id");
            _dbPartner.OrderBy("partner.id", "DESC");
            ViewBag.data = _dbPartner.FetchTable();
            return View();
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(partner objPartner,FormCollection fl)
        {
            if (fl.Count > 0) {
                account acc = new account { 
                    username = fl.Get("username").ToString(),
                    password = fl.Get("password").ToString(),
                    active = false,
                    role = int.Parse(fl.Get("cbCategoryID"))
                };
                _dbAccount.Create(acc);
                _dbAccount.Save();
                int accid = _dbAccount.id;

                objPartner.account_id = accid;
                objPartner.create_date = DateTime.Now;
                objPartner.update_date = DateTime.Now;
                _dbPartner.Create(objPartner);
                _dbPartner.Save();                

            }

            return RedirectToAction("ajaxLoad", "partner");            
        }

        public ActionResult Update(string id)
        {
            _dbPartner.Select();
            _dbPartner.Where("id", id);
            var obj =_dbPartner.FetchObject()[0];
            ViewBag.partner = obj;

            _dbAccount.Select();
            _dbAccount.Where("id", obj.account_id.ToString());
            ViewBag.account = _dbAccount.FetchObject()[0];

            return View();
        }

    }
}
