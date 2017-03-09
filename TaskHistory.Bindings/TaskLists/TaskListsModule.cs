using System;
using Ninject;
using TaskHistory.Api.TaskLists;
using TaskHistory.Impl.TaskLists;

namespace TaskHistory.Bindings
{
	public class TaskListsModule : IModule
	{
		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException(nameof(kernel));

			kernel.Bind<ITaskListRepo>()
				  .To<TaskListRepo>();

			kernel.Bind<ITaskListWithTasksRepo>()
				  .To<TaskListWithTasksRepo>();
		}
	}
}
