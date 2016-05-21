using Ninject;
using TaskHistory.Api.Users;
using TaskHistoryImpl.Users;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;
using TaskHistory.Api.ViewRepos;
using TaskHistory.Impl.ViewRepos;

namespace TaskHistory.Bindings
{
	public static class TaskHistoryBindings
	{
		public static void BindAll(IKernel kernel)
		{
			kernel.Bind<IUserRepo>()
				.To<UserRepo>();
			
			kernel.Bind<ITaskRepo> ()
				.To<TaskRepo> ();

			//kernel.Bind<ITaskViewRepo> ()
			//	.To<TaskViewRepo> ();
		}
	}
}

