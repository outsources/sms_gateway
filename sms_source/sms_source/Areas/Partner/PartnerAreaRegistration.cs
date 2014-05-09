using System.Web.Mvc;

namespace sms_source.Areas.Partner
{
    public class PartnerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Partner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Partner_default",
                "partner-manage/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
                new[] { "sms_source.Areas.Partner.Controllers" }
            );
        }
    }
}
