using System;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test
{
	public class TestFixtures
	{
		readonly IUserRepo _userRepo;

		public IUser CreateUser1()
		{
			return _userRepo.RegisterUser(null);
		}

		public TestFixtures()
		{
			var userFactory = new UserFactory();
			var appDataProxyFactory = new ApplicationDataProxyFactory();

			_userRepo = new UserRepo(userFactory, appDataProxyFactory.Build());
		}
	}
}
