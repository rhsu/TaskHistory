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

			bundles.Add(new ScriptBundle("~/bundles/DemoApp")
			            .Include("~/Scripts/Demo/App.js")
			            .IncludeDirectory("~/Scripts/Demo/Services", "*.js")
			            .IncludeDirectory("~/Scripts/Demo/Controllers", "*.js"));

			bundles.Add(new ScriptBundle("~/bundles/App")
			            .Include("~/Scripts/app.js")
			            .IncludeDirectory("~/Scripts/Services", "*.js")
			            .IncludeDirectory("~/Scripts/Factories", "*.js")
			            .IncludeDirectory("~/Scripts/Controllers", "*.js"));

			//BundleTable.EnableOptimizations = true;
		}
	}
}
