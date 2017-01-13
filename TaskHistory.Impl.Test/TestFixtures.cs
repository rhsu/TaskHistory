using System;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test
{
	public class TestFixtures
	{
		readonly IUserRepo _userRepo;

		IUser _user;

		public IUser User
		{
			get { return _user; }
		}

		void CreateUser()
		{
			var time = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

			var username = $"u{time}";
			var password = "password";
			var firstName = "first";
			var lastName = "last";
			var email = "email@email.com";

			var userParms = new UserRegistrationParameters(username, 
			                                               password,
			                                               firstName,
			                                               lastName,
			                                               email);

			_user = _userRepo.RegisterUser(userParms);
		}

		public TestFixtures()
		{
			var userFactory = new UserFactory();
			var appDataProxyFactory = new ApplicationDataProxyFactory();

			_userRepo = new UserRepo(userFactory, appDataProxyFactory.Build());

			CreateUser();
		}
	}
}
