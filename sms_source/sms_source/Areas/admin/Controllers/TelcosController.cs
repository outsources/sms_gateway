using Helper;
using sms_source.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sms_source.Areas.admin.Controllers
{
    public class TelcosController : Controller
    {
        //
        // GET: /admin/Telcos/
        readonly DbContext<telcos> _dbContext = new DbContext<telcos>(new string[] { "telcos_name", "info" });
        readonly DbContext<service_rates> _dbContextServiceRate = new DbContext<service_rates>();

        public ActionResult Index(int? delID)
        {         
            if (delID != null)
            {
                //Delete Bảng giữa
                _dbContextServiceRate.Where("telcos_id", delID.Value.ToString());
                _dbContextServiceRate.Delete();
                _dbContextServiceRate.Save();

                //Delete Bảng chính
                _dbContext.Where("id", delID.Value.ToString());
                _dbContext.Delete();
                _dbContext.Save();
            }
            _dbContext.Select();
            var lstTelco = _dbContext.FetchObject();
            return View(lstTelco);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(telcos model)
            {
            if (ModelState.IsValid)
            {
                //Thực hiện Insert
                var modelInsert = new telcos
                {
                    telcos_name = model.telcos_name,
                    info = model.info,
                    create_date = DateTime.Now,
                    update_date = DateTime.Now,
                };

                _dbContext.Create(modelInsert);
                _dbContext.Save();
               
                return Content("OK");
            }

            return View(model);
        }


        public ActionResult Update(int? id)
        {
            if (id != null)
            {
                _dbContext.Select();
                _dbContext.Where("id", id.Value.ToString());
                var lstTelco = _dbContext.FetchObject();
                return View(lstTelco[0]);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(telcos model)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện Update
                _dbContext.Where("id", model.id.ToString());
                _dbContext.Update(new telcos
                    {
                        telcos_name = model.telcos_name, 
                        info = model.info, 
                        create_date = model.create_date,
                        update_date = DateTime.Parse(DateTime.Now.ToLongDateString())
                    });                
                _dbContext.Save();
                return Content("OK");
            }

            return View(model);
        }

    }
}
