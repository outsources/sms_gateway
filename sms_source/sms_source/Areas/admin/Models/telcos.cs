using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class telcos
    {                
        public int id { get; set; }
        public string telcos_name { get; set; }
        public string info { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
    }
}