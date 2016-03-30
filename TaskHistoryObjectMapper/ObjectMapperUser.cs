using System;
using TaskHistory.Api.Users;
using TaskHistoryViewModel.ViewModels;
using TaskHistoryImpl;

namespace TaskHistory.ObjectMapper
{
	public class ObjectMapperUser
	{
		//TODO: https://github.com/rhsu/TaskHistory/issues/40
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

