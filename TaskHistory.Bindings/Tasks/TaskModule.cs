using System;
using Ninject;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Bindings
{
	public class TaskModule : IModule
	{
		public TaskModule ()
		{
		}

		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			kernel.Bind<ITaskRepo> ()
				  .To<TaskRepo> ();
		}
	}
}

