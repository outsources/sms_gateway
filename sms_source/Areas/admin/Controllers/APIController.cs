using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace sms_source.Areas.admin.Controllers
{
    public class APIController : Controller
    {
        //
        // GET: /admin/API/

        [HttpPost]
        public ActionResult abc(FormCollection colect)
        {
            
            return View();
        }

        public ActionResult Index() { 
            XElement xBookParticipants =  new XElement("BookParticipants",  
                                            new XElement("BookParticipant",  
                                                new XAttribute("type", "Author"), 
                                                    new XElement("FirstName", "Joe"), 
                                                    new XElement("LastName", "Rattz")), 
                                            new XElement("BookParticipant",       
                                                 new XAttribute("type", "Editor"), 
                                                    new XElement("FirstName", "Ewan"), 
                                                    new XElement("LastName", "Buckingham"))); 
            return Content(xBookParticipants.ToString() , "text/xml");
        }

    }
}
