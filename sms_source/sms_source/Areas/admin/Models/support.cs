using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class support
    {
        public int id { get; set; }        
        public int sms_send_log_id { get; set; }
        public int active { get; set; }
        public DateTime create_date { get; set; }
    }
}