using System;
using Ninject;
using TaskHistory.Api.Terminal;
using TaskHistory.Impl.Terminal;

namespace TaskHistory.Bindings
{
	public class TerminalModule : IModule
	{
		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException(nameof(kernel));

			kernel.Bind<ITerminalInterpreter>()
				  .To<TerminalInterpreter>();

			throw new NotImplementedException();
		}
	}
}
