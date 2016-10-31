using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AngularProto
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
