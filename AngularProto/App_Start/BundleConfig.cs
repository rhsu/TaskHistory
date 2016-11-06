using System;
using System.Web.Optimization;

namespace AngularProto
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			if (bundles == null)
				throw new ArgumentNullException(nameof(bundles));

			bundles.Add(new ScriptBundle("~/bundles/App")
			            .Include("~/Scripts/Demo/App.js")
			            .IncludeDirectory("~/Scripts/Demo/Services", "*.js")
			            .IncludeDirectory("~/Scripts/Demo/Controllers", "*.js"));
			           
			//BundleTable.EnableOptimizations = true;
		}
	}
}
