using System;
using Ninject;
using TaskHistory.Api.Configuration;
using TaskHistory.Impl.Configuration;

namespace TaskHistory.Bindings
{
	public class ConfigurationModule : IModule
	{
		public ConfigurationModule ()
		{
		}

		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			kernel.Bind<IConfigurationProvider> ()
				  .To<ConfigurationProvider> ();
		}
	}
}