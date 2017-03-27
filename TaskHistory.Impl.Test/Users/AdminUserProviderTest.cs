using System;
using NUnit.Framework;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test.Users
{
	[TestFixture]
	public class AdminUserProviderTest
	{
		AdminUserProvider _provider;

		[SetUp]
		public void Init()
		{
			var userFactory = new UserFactory();

			_provider = new AdminUserProvider(userFactory);
		}

		[Test]
		public void AuthenticateAdminUser_With_Default_Credentials_Works()
		{
			var user = _provider.AuthenticateAdminUser("admin", "password");
			Assert.NotNull(user);
		}

		[Test]
		public void AuthenticateAdminUser_With_Invalid_Crendentials_Fails()
		{
			var user = _provider.AuthenticateAdminUser("asdfadsfsdf", "asdfasdfasdf");
			Assert.IsNull(user);
		}
	}
}
