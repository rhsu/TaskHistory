using System;
using System.Web.Optimization;

namespace TaskHistory.WebApp
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			if (bundles == null)
				throw new ArgumentNullException(nameof(bundles));

			bundles.Add(new ScriptBundle("~/bundles/App")
			            .Include("~/Scripts/app.js")
			            .Include("~/Scripts/routes.js")
			            .IncludeDirectory("~/Scripts/Directives", "*.js")
			            .IncludeDirectory("~/Scripts/Services", "*.js")
			            .IncludeDirectory("~/Scripts/Factories", "*.js")
			            .IncludeDirectory("~/Scripts/Controllers", "*.js"));

			//BundleTable.EnableOptimizations = true;
		}
	}
}
