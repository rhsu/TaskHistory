using NUnit.Framework;
using TaskHistory.Impl.Sql;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test.Users
{
	[TestFixture]
	public class DefaultUserProviderTest
	{
		DefaultUserProvider _userProvider;
		ApplicationDataProxy _appDataProxy;

		void DeleteAllUsers()
		{
			// TODO More proof that we need a mechanism to execute adhoc queries
			// TODO This is fine for now but should delete later as that procedure
			//		is very dangerous
			_appDataProxy.ExecuteNonQuery("USERS_ALL_DELETE");
		}

		[Test]
		public void DefaultUserExists_False()
		{
			DeleteAllUsers();

			//Assert.False(_userProvider.DefaultUserExists());
		}

		[Test]
		public void DefaultUserExists_True()
		{
			DeleteAllUsers();
			//_userProvider.RegisterDefaultUser();

			//Assert.True(_userProvider.DefaultUserExists());
		}

		public DefaultUserProviderTest()
		{
			_appDataProxy = new ApplicationDataProxyFactory().Build();
			var userFactory = new UserFactory();
			var userRepo = new UserRepo(userFactory, _appDataProxy);
			_userProvider = new DefaultUserProvider(userRepo);
		}
	}
}
