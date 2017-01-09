using NUnit.Framework;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class UserRepoTest
	{
		IUserRepo _userRepo;

		public UserRepoTest()
		{
			var userFactory = new UserFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_userRepo = new UserRepo(userFactory, appDataProxy);
		}

		[Test]
		public void test_register_user()
		{
			// TODO: make username a GUID of length 32 so test won't flap when ran multiple times?
			var userParams = new UserRegistrationParameters("username",
															"password",
															"first",
															"last",
															"email");

			_userRepo.RegisterUser(userParams);
		}
	}
}
