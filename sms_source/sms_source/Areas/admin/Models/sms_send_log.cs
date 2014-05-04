using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class sms_send_log
    {
        public int id { get; set; }
        public int sender_number { get; set; }
        public int service_number { get; set; }

        public string telcos { get; set; }
        public string command_code { get; set; }

        public int messages_id { get; set; }
        public int number_messages { get; set; }
        public bool messages_type { get; set; }
        public DateTime create_date { get; set; }

    }
}