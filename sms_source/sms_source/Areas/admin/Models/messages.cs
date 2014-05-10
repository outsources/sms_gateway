using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class messages
    {
        public int id { get; set; }
        public int cmd_id { get; set; }
        public string msg_Content { get; set; }
        public string type { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public DateTime apply_date { get; set; }
        public int active { get; set; }
    }
}