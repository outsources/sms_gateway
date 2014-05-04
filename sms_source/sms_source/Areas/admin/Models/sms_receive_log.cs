using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class sms_receive_log
    {
        public int id { get; set; }
        public int sender_number { get; set; }
        public int service_number { get; set; }

        public string telcos { get; set; }
        public string command_code { get; set; }
        public DateTime sender_date { get; set; }

    }
}