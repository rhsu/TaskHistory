using System;
using Ninject;
using TaskHistory.Api.Configuration;
using TaskHistory.Impl.Configuration;

namespace TaskHistory.Bindings
{
	public class ConfigurationModule : IModule
	{
		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException (nameof(kernel));

			kernel.Bind<IConfigurationProvider> ()
				  .To<ConfigurationProvider> ();
		}
	}
}