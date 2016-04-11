using Microsoft.Practices.Unity;
using Project.Framework;
using SampleWebApp.Controllers;
using SampleWebApp.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           

            IUnityContainer container = UnityRegistration.Register(GlobalConfiguration.Configuration);
            DependencyHelper.container = container;
            UnityConfig.RegisterComponents();
        }


    }
}
