using System;
using TaskHistoryApi.Users;
using TaskHistoryViewModel.ViewModels;
using TaskHistoryImpl;

namespace TaskHistoryObjectMapper
{
	public class ObjectMapperUser
	{
		public IUser Map(UserRegisterViewModel viewModel)
		{
			if (viewModel == null)
				throw new ArgumentNullException("viewModel");

			// var userFactory = new UserFactory ();
			// userFactory

			return null;
		}

		public ObjectMapperUser ()
		{
		}
	}
}

