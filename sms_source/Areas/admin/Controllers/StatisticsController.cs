using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using sms_source.Areas.admin.Models;
using System.Data;

namespace sms_source.Areas.admin.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /admin/Statistics/

        readonly DbContext<counter> _dbCounter = new DbContext<counter>();
        readonly DbContext<telcos> _dbTelcos = new DbContext<telcos>();
        readonly DbContext<service_numbers> _dbService = new DbContext<service_numbers>();

        
        //Trang đối soát MO / MT
        public ActionResult MoMt()
        {
            return View();
        }

        //Trang tìm kiếm soát MO / MT       
        [HttpPost]
        public ActionResult SearchMoMt(FormCollection collec)
        {
            var fromDate = DateTime.Parse(collec.Get("txtFromDate"));
            var toDate = DateTime.Parse(collec.Get("txtToDate"));

            var function = new Bussiness_Statistics();
            var overView = function.getOverView(fromDate, toDate);
            ViewBag.overView = overView;

            _dbTelcos.Select();
            var listTelco = _dbTelcos.FetchObject();
            var totalTelco = listTelco.Count;

            _dbService.Select();
            var listService = _dbService.FetchObject();
            var totalService = listService.Count;


            var listTableResult = new List<DataTable>();
            for (var i = 0; i < totalTelco; i++)
            {
                var dtResult = new DataTable();
                dtResult.Columns.Add("telcos_id", typeof(int));
                dtResult.Columns.Add("service_number_id", typeof(int));
                dtResult.Columns.Add("total_mt", typeof(int));
                dtResult.Columns.Add("total_mo", typeof(int));
                dtResult.Columns.Add("total_cdr", typeof(int));

                for (int j = 0; j < totalService; j++)
                {
                    var dataTableTemp = function.SearchMOMT(fromDate, toDate, listTelco[i].id, listService[j].id);
                    if(dataTableTemp.Rows.Count == 0) continue;
                    var serviceRowItem = dataTableTemp.Rows[0];
                    dtResult.Rows.Add(serviceRowItem.ItemArray);
                }       
                listTableResult.Add(dtResult);         
            }

            //dtResult
            return View(listTableResult);
        }

        //Trang Báo Cáo
        public ActionResult Report()
        {
            _dbTelcos.Select();
            var listTelco = _dbTelcos.FetchObject();
            return View(listTelco);
        }

        //Trang tìm kiếm soát MO / MT       
        [HttpPost]
        public ActionResult SearchReport(FormCollection collec)
        {            
            var fromDate = DateTime.Parse(collec.Get("txtFromDate"));
            var toDate = DateTime.Parse(collec.Get("txtToDate"));
            var telcoID = int.Parse(collec.Get("cbTelco"));
                               
            _dbService.Select();
            var listService = _dbService.FetchObject();
            var totalService = listService.Count;
            
            var dtResult = new DataTable();
            dtResult.Columns.Add("telcos_id", typeof(int));
            dtResult.Columns.Add("service_number_id", typeof(int));
            dtResult.Columns.Add("total_mt", typeof(int));
            dtResult.Columns.Add("total_mo", typeof(int));
            dtResult.Columns.Add("total_cdr", typeof(int));

            var function = new Bussiness_Statistics();    
            for (int j = 0; j < totalService; j++)
            {
                var dataTableTemp = function.SearchMOMT(fromDate, toDate, telcoID, listService[j].id);
                if (dataTableTemp.Rows.Count == 0) continue;
                var serviceRowItem = dataTableTemp.Rows[0];
                dtResult.Rows.Add(serviceRowItem.ItemArray);
            }

            ViewBag.telcoID = telcoID;
            
                                    
            return View(dtResult);
        }

    }
}
