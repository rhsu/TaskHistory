using System;
using Ninject;
using TaskHistory.Api.Labels;
using TaskHistory.Impl.Labels;

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

			kernel.Bind<ILabelRepo>()
				  .To<LabelRepo>();
		}
	}
}
