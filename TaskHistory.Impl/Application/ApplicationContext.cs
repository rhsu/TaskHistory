using System;
using TaskHistory.Api.Application;
using TaskHistory.Api.Users;

namespace TaskHistory.Impl.Application
{
	public class ApplicationContext : IApplicationContext
	{
		private readonly IUser _user;

		public IUser ApplicationUser 
		{ 
			get { return _user; }
		}	

		public ApplicationContext (IUser user)
		{
			_user = user;
		}
	}
}