using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VkDialogViewer.BLL.AutoMapperConfig;
using VkDialogViewer.DAL;
using VkDialogViewer.ServiceLocator;
using VkDialogViewer.ServiceLocator.CastleWindsorInstaller;

namespace vkDialogViewer
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperWebConfiguration.Configure();
            ServiceLocatorConfig.RegisterContainer(new WebInstaller());
            Database.SetInitializer(new DbInitializer());
        }
    }
}