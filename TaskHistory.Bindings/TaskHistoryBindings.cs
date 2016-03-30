using Ninject;
using TaskHistory.Api.Users;
using TaskHistoryImpl.Users;

namespace TaskHistory.Bindings
{
	public static class TaskHistoryBindings
	{
		public static void BindAll(IKernel kernel)
		{
			kernel.Bind<IUserRepo>()
				.To<UserRepo>();
		}
	}
}

