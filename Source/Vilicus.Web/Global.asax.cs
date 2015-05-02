using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vilicus.Dal;
using Vilicus.Web.App_Start;

namespace Vilicus.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DalHelper.InitializeDatabaseContext();
        }
    }
}
