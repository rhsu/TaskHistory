using System;
using NUnit.Framework;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test.Users
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
			var userParams = GetUserRegistrationParams();

			IUser newUser = _userRepo.RegisterUser(userParams);

			Assert.NotNull(newUser);
			Assert.AreEqual(newUser.Username, userParams.Username);
			// TODO: Once I can execute select queries against the database, 
			//       then, do the below assert
			// Assert.AreEqual(newUser.Password, password);
			Assert.AreEqual(newUser.FirstName, userParams.FirstName);
			Assert.AreEqual(newUser.LastName, userParams.LastName);
			Assert.AreEqual(newUser.Email, userParams.Email);
		}

		public void RegisterUser_Fails()
		{
			var userParams = GetUserRegistrationParams();

			_userRepo.RegisterUser(userParams);

			IUser sameUser = _userRepo.RegisterUser(userParams);
			Assert.Null(sameUser);
		}

		public void ValidateUsernameAndPassword_Works()
		{
			var userParams = GetUserRegistrationParams();

			IUser registeredUser = _userRepo.RegisterUser(userParams);
			IUser validatedUser = _userRepo.ValidateUsernameAndPassword(userParams.Username, 
			                                                            userParams.Password);

			Assert.NotNull(validatedUser);
			Assert.AreEqual(registeredUser.Id, validatedUser.Id);
			Assert.AreEqual(registeredUser.FirstName, validatedUser.FirstName);
			Assert.AreEqual(registeredUser.LastName, validatedUser.LastName);
			Assert.AreEqual(registeredUser.Username, validatedUser.Username);
		}

		public void ValidateUsernameAndPassword_Fails()
		{
			IUser registeredUser = _userRepo.ValidateUsernameAndPassword("nonsense", "nonsense");
			Assert.Null(registeredUser);
		}

		static UserRegistrationParameters GetUserRegistrationParams()
		{
			var time = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

			var username = $"u{time}";
			var password = "password";
			var firstName = "first";
			var lastName = "last";
			var email = "email@email.com";

			return new UserRegistrationParameters(username,
			                                      password,
			                                      firstName,
			                                      lastName,
			                                      email);
		}
	}
}
