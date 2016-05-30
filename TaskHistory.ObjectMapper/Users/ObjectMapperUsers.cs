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

		public ObjectMapperUsers ()
		{
		}
	}
}

