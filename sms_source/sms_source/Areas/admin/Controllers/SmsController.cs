using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Helper;
using sms_source.Areas.admin.Models;

namespace sms_source.Areas.admin.Controllers
{
    public class SmsController : Controller
    {
        //
        // GET: /admin/SMS/

        readonly DbContext<sms_receive_log> _dbReceive = new DbContext<sms_receive_log>();
        readonly DbContext<sms_send_log> _dbSend = new DbContext<sms_send_log>();
        readonly DbContext<telcos> _dbTelco = new DbContext<telcos>();

        public ActionResult SmsReceive()
        {
            _dbReceive.Select();
            var listReceive = _dbReceive.FetchObject();

            _dbTelco.Select();
            var listTelco = _dbTelco.FetchObject();

            ViewBag.listTelco = listTelco;
            return View(listReceive);
        }

        public ActionResult SmsPending()
        {
           
            _dbSend.Select();
            _dbSend.Where("messages.type","standby");
            _dbSend.Join<messages>("messages.id", "sms_send_log.messages_id");
            _dbSend.OrderBy("sms_send_log.id", "DESC");
            var dt = _dbSend.FetchTable();

            ////_dbSend.Where("messages_type", "False");
            //var listSend = _dbSend.FetchObject();

            //_dbTelco.Select();
            //var listTelco = _dbTelco.FetchObject();

            //ViewBag.listTelco = listTelco;
            return View();
        }

        public ActionResult SmsError()
        {
            _dbSend.Select();
            _dbSend.Where("messages_type","False");
            var listSend = _dbSend.FetchObject();

            _dbTelco.Select();
            var listTelco = _dbTelco.FetchObject();

            ViewBag.listTelco = listTelco;
            return View(listSend);
        }

        [HttpPost]
        public ActionResult SmsReceiveSearch(FormCollection frmCollec)
        {

            ////Phan Tích DAte Time theo 2 kiểu
            //var month = !string.IsNullOrEmpty(frmCollec.Get("cbMonth")) ? frmCollec.Get("cbMonth") : "";
            //var year = !string.IsNullOrEmpty(frmCollec.Get("cbYear")) ? frmCollec.Get("cbYear") : "";
            //var dateTimePicker = !string.IsNullOrEmpty(frmCollec.Get("txtDate")) ? frmCollec.Get("txtDate") : "";
            //frmCollec.Remove("cbMonth");
            //frmCollec.Remove("cbYear");
            //frmCollec.Remove("txtDate");

            //if(dateTimePicker != "")
            //{
            //    frmCollec.Add("sender_date",dateTimePicker);
            //} else
            //{
            //    frmCollec.Add("sender_date", month+"/"+ "{0}/{1}/2014 00:00:00 AM"); /// ĐANG LÀM DỞ, CHỜ HÀM PHÂN TÍCH SQL DATETIME PHÍA HELPER.
            //}            

            //Chuyen Ham: PhanTichTimKiem(frmCollec, _dbReceive);

            _dbReceive.Select();
            for (var i = 0; i < frmCollec.Count-1; i++) // -1 vì thành phần cuối cùng của form do hệ thống tự sinh
            {
                if (!String.IsNullOrEmpty(frmCollec[i]))
                {
                    _dbReceive.Where(frmCollec.GetKey(i), frmCollec[i]);
                }
            }

            var listReceive = _dbReceive.FetchObject();
            
            
            return View(listReceive);
        }

        [HttpPost]
        public ActionResult SmsErrorSearch(FormCollection frmCollec)
        {

            ////Phan Tích DAte Time theo 2 kiểu
            //var month = !string.IsNullOrEmpty(frmCollec.Get("cbMonth")) ? frmCollec.Get("cbMonth") : "";
            //var year = !string.IsNullOrEmpty(frmCollec.Get("cbYear")) ? frmCollec.Get("cbYear") : "";
            //var dateTimePicker = !string.IsNullOrEmpty(frmCollec.Get("txtDate")) ? frmCollec.Get("txtDate") : "";
            //frmCollec.Remove("cbMonth");
            //frmCollec.Remove("cbYear");
            //frmCollec.Remove("txtDate");

            //if(dateTimePicker != "")
            //{
            //    frmCollec.Add("sender_date",dateTimePicker);
            //} else
            //{
            //    frmCollec.Add("sender_date", month+"/"+ "{0}/{1}/2014 00:00:00 AM"); /// ĐANG LÀM DỞ, CHỜ HÀM PHÂN TÍCH SQL DATETIME PHÍA HELPER.
            //}            

            //Chuyen Ham: PhanTichTimKiem(frmCollec, _dbReceive);

            _dbSend.Select();
            _dbSend.Where("messages_type", "False");
            for (var i = 0; i < frmCollec.Count - 1; i++) // -1 vì thành phần cuối cùng của form do hệ thống tự sinh
            {
                if (!String.IsNullOrEmpty(frmCollec[i]))
                {
                    _dbSend.Where(frmCollec.GetKey(i), frmCollec[i]);
                }
            }

            var listError = _dbSend.FetchObject();


            return View(listError);
        }


        //public List<object> PhanTichTimKiem(FormCollection frmCollec, DbContext<T> db)
        //{

        //}



    }
}
