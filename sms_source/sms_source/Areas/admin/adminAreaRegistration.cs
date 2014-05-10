using System.Web.Mvc;

namespace sms_source.Areas.provider
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "admin-manage/{controller}/{action}/{id}",
                new { controller = "dashboard", action = "Index", id = UrlParameter.Optional },
                new[] { "sms_source.Areas.admin.Controllers" }
            );
        }
    }
}
