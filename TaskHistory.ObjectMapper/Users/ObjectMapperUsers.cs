using System;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.ObjectMapper.Users
{
	public class ObjectMapperUsers
	{
		public UserRegistrationParameters Map(UserRegistrationParametersViewModel userParamsViewModel)
		{
			if (userParamsViewModel == null)
				throw new ArgumentNullException ("viewModel");

			var returnVal = new UserRegistrationParameters (userParamsViewModel.Username,
				userParamsViewModel.Password,
				userParamsViewModel.FirstName,
				userParamsViewModel.LastName,
				userParamsViewModel.Email);

			return returnVal;
		}

		public UserRegistrationStatusViewModel Map (IUser newUser, UserRegistrationParametersViewModel vmUserRegister)
		{
			// newUser == null means that the user was unable to be registered.
			// currently the only thing that would cause this to happen is because of a duplicate user name.

			if (vmUserRegister == null)
				throw new ArgumentNullException ("vmUserRegister");



			return null;
		}

		public ObjectMapperUsers ()
		{
		}
	}
}

