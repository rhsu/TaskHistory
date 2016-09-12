using System;
using Ninject;
using TaskHistory.Api.Application;
using TaskHistory.Impl.Application;

namespace TaskHistory.Bindings
{
	public class ApplicationModule : IModule
	{
		public ApplicationModule ()
		{
		}

		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			kernel.Bind<IApplicationContext> ()
				  .To<ApplicationContext> ();
		}
	}
}

