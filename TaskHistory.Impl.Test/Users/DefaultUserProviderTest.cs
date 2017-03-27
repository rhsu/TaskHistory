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

		[SetUp]
		public void Init()
		{
			_appDataProxy = new ApplicationDataProxyFactory().Build();
			var userFactory = new UserFactory();
			var userRepo = new UserRepo(userFactory, _appDataProxy);
			_userProvider = new DefaultUserProvider(userRepo);
		}

		[Test]
		public void DefaultUserExists_False()
		{
			Assert.False(_userProvider.DefaultUserExists());
		}

		[Test]
		public void DefaultUserExists_True()
		{
			_userProvider.RegisterDefaultUser();

			Assert.True(_userProvider.DefaultUserExists());
		}
	}
}
