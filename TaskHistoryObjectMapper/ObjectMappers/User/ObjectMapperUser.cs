using System;
using TaskHistoryApi.Users;
using TaskHistoryOrchestrator.ViewModels;

namespace TaskHistoryObjectMapper
{
	public class ObjectMapperUser
	{
		public IUser Map(UserRegisterViewModel viewModel)
		{
			if (viewModel == null)
				throw new ArgumentNullException ("viewModel");

			return null;
		}
		public ObjectMapperUser ()
		{
		}
	}
}