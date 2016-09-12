using System;
using Ninject;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Users;

namespace TaskHistory.Bindings
{
	public class UserModule : IModule
	{
		public UserModule ()
		{
		}

		public void Bind (IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			kernel.Bind<IUserRepo> ()
				  .To<UserRepo> ();

			kernel.Bind<IUser> ()
				  .To<User> ();
		}
	}
}