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
			            .Include("~/Scripts/App.js")
			            .IncludeDirectory("~/Scripts/Services", "*.js")
						.IncludeDirectory("~/Scripts/Controllers", "*.js"));
			           
			//BundleTable.EnableOptimizations = true;
		}
	}
}
