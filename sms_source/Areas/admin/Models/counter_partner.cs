﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class counter_partner
    {
        public int id { get; set; }
        public int partner_id { get; set; }
        public int telcos_id { get; set; }
        public int service_id { get; set; }
        public int total_mt { get; set; }        
        public int total_cdr { get; set; }
        public DateTime datetime { get; set; }
    }
}