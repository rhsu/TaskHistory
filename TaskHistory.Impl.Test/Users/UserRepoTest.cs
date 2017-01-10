using System;
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
		public void RegisterUser_Works()
		{
			var time = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

			var username = $"u{time}";
			var password = "password";
			var firstName = "first";
			var lastName = "last";
			var email = "email@email.com";

			var userParams = new UserRegistrationParameters(username, 
			                                                password, 
			                                                firstName, 
			                                                lastName, 
			                                                email);

			IUser newUser = _userRepo.RegisterUser(userParams);

			Assert.NotNull(newUser);
			Assert.AreEqual(newUser.Username, username);
			// TODO: Once I can execute select queries against the database, 
			//       then, do the below assert
			// Assert.AreEqual(newUser.Password, password);
			Assert.AreEqual(newUser.FirstName, firstName);
			Assert.AreEqual(newUser.LastName, lastName);
			Assert.AreEqual(newUser.Email, email);
		}

		public void RegisterUser_Fails()
		{
			var time = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

			var username = $"u{time}";
			var password = "password";
			var firstName = "first";
			var lastName = "last";
			var email = "email@email.com";

			var userParams = new UserRegistrationParameters(username,
															password,
															firstName,
															lastName,
															email);

			_userRepo.RegisterUser(userParams);

			IUser sameUser = _userRepo.RegisterUser(userParams);
			Assert.Null(sameUser);
		}

		public void ValidateUsernameAndPassword_Works()
		{
			var time = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

			var username = $"u{time}";
			var password = "password";
			var firstName = "first";
			var lastName = "last";
			var email = "email@email.com";

			var userParams = new UserRegistrationParameters(username,
															password,
															firstName,
															lastName,
															email);

			IUser registeredUser = _userRepo.RegisterUser(userParams);
			IUser validatedUser = _userRepo.ValidateUsernameAndPassword(username, password);

			Assert.NotNull(validatedUser);
			Assert.AreEqual(registeredUser.UserId, validatedUser.UserId);
			Assert.AreEqual(registeredUser.FirstName, validatedUser.FirstName);
			Assert.AreEqual(registeredUser.LastName, validatedUser.LastName);
			Assert.AreEqual(registeredUser.Username, validatedUser.Username);
		}

		public void ValidateUsernameAndPassword_Fails()
		{
			IUser registeredUser = _userRepo.ValidateUsernameAndPassword("nonsense", "nonsense");
			Assert.Null(registeredUser);
		}
	}
}
