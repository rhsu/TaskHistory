using System;
using TaskHistory.Api.Users;

namespace TaskHistory.Impl.Users
{
	public class DefaultUserProvider : IDefaultUserProvider
	{
		const string _default_name = "robert";
		const string _default_password = "password";

		IUserRepo _userRepo;

		public DefaultUserProvider(IUserRepo userRepo)
		{
			_userRepo = userRepo;
		}

		public bool DefaultUserExists()
		{
			IUser user = _userRepo.ValidateUsernameAndPassword(_default_name, _default_password);
			return user != null;
		}

		public IUser RegisterDefaultUser()
		{
			// TODO this should from as a dependency
			var userRegistrationParams = new UserRegistrationParameters(_default_name,
																		_default_password,
																		"robert",
																		"hsu",
																		"robert@gmail.com");

			IUser user = _userRepo.RegisterUser(userRegistrationParams);
			if (user == null)
				throw new NullReferenceException("Null returned from user repo when registering default user");

			return user;
		}
	}
}
