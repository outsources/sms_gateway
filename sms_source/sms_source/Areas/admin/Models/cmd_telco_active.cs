using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class cmd_telco_active
    {
        public int command_code_id { get; set; }
        public int telcos_id { get; set; }
        public int active { get; set; }
    }
}