using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class cmd_prefix
    {
        public int id { get; set; }
        public string prefix { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public bool active { get; set; }
    }
}