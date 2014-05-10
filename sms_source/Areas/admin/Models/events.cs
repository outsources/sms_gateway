using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class events
    {
        public int id { get; set; }

        public string event_name { get; set; }
        public string description { get; set; }

        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; } 
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
    }
}