using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class service_rates
    {
        public int id { get; set; }
        public int service_id { get; set; }
        public int telcos_id { get; set; }
        public float price { get; set; }
    }
}