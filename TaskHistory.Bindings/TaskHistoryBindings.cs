using Ninject;
using TaskHistory.Api.Users;
using TaskHistoryImpl.Users;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Bindings
{
	public static class TaskHistoryBindings
	{
		public static void BindAll(IKernel kernel)
		{
			kernel.Bind<IUserRepo>()
				//.To<UserRepo>();
				.To<FakeUserRepo>();

			kernel.Bind<ITaskRepo> ()
				.To<TaskRepo> ();
		}
	}
}

