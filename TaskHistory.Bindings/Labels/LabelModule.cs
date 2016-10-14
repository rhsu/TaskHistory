using System;
using System.Reflection.Emit;
using Ninject;
using TaskHistory.Api.Labels;

namespace TaskHistory.Bindings
{
	public class LabelModule : IModule
	{
		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException(nameof(kernel));

			kernel.Bind<ILabel>()
				  .To<Label>();
		}
	}
}
