using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using sms_source.Areas.admin.Models;

namespace sms_source.Areas.admin.Controllers
{
    public class ServiceNumberController : Controller
    {
        //
        // GET: /admin/ServiceNumber/
        readonly DbContext<service_numbers> _dbContext = new DbContext<service_numbers>();
        readonly DbContext<service_rates> _dbContextServiceRate = new DbContext<service_rates>();
        readonly DbContext<telcos> _dbContextTelcos = new DbContext<telcos>();

        public ActionResult Index()
        {
            _dbContext.Select();
            var lstServiceNumber = _dbContext.FetchObject();
            //var lstServiceNumber = new List<service_numbers>();
            return View(lstServiceNumber);
        }

        public ActionResult Insert()
        {
            _dbContextTelcos.Select(new[] { "id", "telcos_name" });
            ViewBag.lstTelcos = _dbContextTelcos.FetchObject();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(int countTelco, service_numbers model)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện Insert Bảng Service_Number
                var modelInsert = new service_numbers
                {
                    service = model.service,
                    create_date = DateTime.Now,
                    update_date = DateTime.Now, // model.update_date
                    active = bool.Parse(Request["cbStatus"])
                };
                _dbContext.Create(modelInsert);
                _dbContext.Save();
                var topID = _dbContext.id;

                //Thực hiện Insert Bảng Service_Telco
                for (var i = 0; i < countTelco; i++)
                {
                    if (string.IsNullOrEmpty((Request["txtPrice" + i]))) continue;
                    var objServiceTelco = new service_rates
                        {
                            service_id = topID,
                            telcos_id = int.Parse(Request["hdTelcoID" + i]),
                            price = float.Parse(Request["txtPrice" + i])
                        };
                    _dbContextServiceRate.Create(objServiceTelco);
                    _dbContextServiceRate.Save();
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }



    }
}
