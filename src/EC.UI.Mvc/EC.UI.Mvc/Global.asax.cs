using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EC.Application.AutoMapper;

namespace EC.UI.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_EndRequest()
        {
            const string contextKey = "ContextManager.Context";
        }
    }

}
