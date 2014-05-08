using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class cmd
    {
        public int id { get; set; }
        public int command_code_id { get; set; }
        public int cmd_prefix_id { get; set; }
        public string cmd_name { get; set; }
        public bool active { get; set; }
    }
}