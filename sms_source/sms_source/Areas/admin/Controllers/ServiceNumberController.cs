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

        public ActionResult Index(int? delID)
        {
            if (delID != null)
            {
                //Delete Bảng giữa
                _dbContextServiceRate.Where("service_id",delID.Value.ToString());
                _dbContextServiceRate.Delete();
                _dbContextServiceRate.Save();

                //Delete Bảng chính
                _dbContext.Where("id", delID.Value.ToString());
                _dbContext.Delete();
                _dbContext.Save();
            }
            _dbContext.Select();
            var lstServiceNumber = _dbContext.FetchObject();            
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
                    create_date = DateTime.Parse(DateTime.Now.ToLongDateString()),
                    update_date = DateTime.Parse(DateTime.Now.ToLongDateString()), // model.update_date
                    active = bool.Parse(Request["cbStatus"])
                };
                _dbContext.Create(modelInsert);
                _dbContext.Save();
                var topID = _dbContext.id;

                //Thực hiện Insert Bảng Service_rate
                for (var i = 0; i < countTelco; i++)
                {
                    var objServiceTelco = new service_rates
                        {
                            service_id = topID,
                            telcos_id = int.Parse(Request["hdTelcoID" + i]),
                            price = string.IsNullOrEmpty((Request["txtPrice" + i])) ? 0 : float.Parse(Request["txtPrice" + i])
                        };
                    _dbContextServiceRate.Create(objServiceTelco);
                    _dbContextServiceRate.Save();
                }

                return Content("OK");
            }

            return View(model);
        }

        public ActionResult Update(int? id)
        {
            if (id != null)
            {                
                _dbContextTelcos.Select(new[] { "id", "telcos_name" });
                ViewBag.lstTelcos = _dbContextTelcos.FetchObject();

                _dbContext.Select();
                _dbContext.Where("id", id.Value.ToString());
                var listServiceNumber = _dbContext.FetchObject();
                return View(listServiceNumber[0]);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(int countTelco, service_numbers model)
        {
            
            if (ModelState.IsValid)
            {
                //Thực hiện Update Bảng Service_Number                
                _dbContext.Where("id", model.id.ToString());
                _dbContext.Update(new service_numbers
                {
                    service = model.service,
                    create_date = model.create_date,
                    update_date = DateTime.Parse(DateTime.Now.ToLongDateString()), // model.update_date
                    active = bool.Parse(Request["cbStatus"])
                });                
                _dbContext.Save();

                //Thực hiện Update Bảng Service_rate
                for (var i = 0; i < countTelco; i++)
                {
                    
                    var objServiceTelco = new service_rates
                    {
                        service_id = model.id,
                        telcos_id = int.Parse(Request["hdTelcoID" + i]),
                        price = float.Parse(Request["txtPrice" + i])
                    };
                    _dbContextServiceRate.Where("service_id", objServiceTelco.service_id.ToString());
                    _dbContextServiceRate.Where("telcos_id", objServiceTelco.telcos_id.ToString());
                    _dbContextServiceRate.Update(objServiceTelco);
                    _dbContextServiceRate.Save();
                }

                return Content("OK");
            }

            return View(model);
        }

    }
}
