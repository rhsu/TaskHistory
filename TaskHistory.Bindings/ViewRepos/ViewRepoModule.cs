using System;
using Ninject;
using TaskHistory.Api.ViewRepos;
using TaskHistory.Impl.ViewRepos;

namespace TaskHistory.Bindings
{
	public class ViewRepoModule : IModule
	{
		public ViewRepoModule ()
		{
		}

		public void Bind (IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			kernel.Bind<ITaskViewRepo> ()
				  .To<TaskViewRepo> ();
		}
	}
}

