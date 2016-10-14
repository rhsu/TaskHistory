using System;
using TaskHistory.Api.Users;

namespace TaskHistory.Impl
{
	public class UserContext : IUserContext
	{
		private IUser _user;

		public UserContext(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			_user = user;
		}

		public IUser User
		{
			get
			{
				return _user;
			}
		}
	}
}
