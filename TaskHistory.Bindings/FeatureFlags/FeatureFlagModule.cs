using System;
using Ninject;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Impl.FeatureFlags;

namespace TaskHistory.Bindings
{
	public class FeatureFlagModule : IModule
	{
		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException(nameof(kernel));

			kernel.Bind<IFeatureFlagRepo>()
				  .To<FeatureFlagRepo>();
		}
	}
}
