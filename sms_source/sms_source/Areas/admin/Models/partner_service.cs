
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class partner_service
    {
        public int id { get; set; }
        public int partner_id { get; set; }
        public string server_number_id { get; set; }
        public float price { get; set; }
        
    }
}