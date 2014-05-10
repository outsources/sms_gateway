using Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sms_source
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "dashboard", action = "Index", id = UrlParameter.Optional }
            ).DataTokens.Add("area", "admin");

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // Use connectDB for Helper Framework by default
            database.SqlConnection = new DbConnection(@"NGUYENTRUONG-PC\SQLEXPRESS", "sms_gateway", "lab", "");
            //database.SqlConnection = new DbConnection(@"USER-PC", "sms_gateway", "lab", "");
            // Use LocalDB for Entity Framework by default
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}