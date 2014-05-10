using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class account
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public int role { get; set; }
    }
}