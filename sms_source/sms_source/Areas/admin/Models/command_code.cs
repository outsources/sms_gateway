using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class command_code
    {
        public int id { get; set; }
        public int provider_id { get; set; }
        public int events_id { get; set; }

        public string cmd_code { get; set; }
        public string prefix { get; set; }
        public string info { get; set; }    
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public int active { get; set; }
    }
}