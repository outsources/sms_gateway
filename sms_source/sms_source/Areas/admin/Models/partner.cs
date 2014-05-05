using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class partner
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public string provider_name { get; set; }
        public string email { get; set; }
        public int phone_number { get; set; }
        public int tel { get; set; }

        public string info { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        
    }
}