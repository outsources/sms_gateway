﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class service_numbers
    {
        public int id { get; set; }
        public int service { get; set; }       
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public bool active { get; set; }
        public float price { get; set; }
    }
}