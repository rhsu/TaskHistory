using System;
using TaskHistory.Api.Application;
using TaskHistory.Api.Users;

namespace TaskHistory.Impl.Application
{
	public interface IApplicationContextFactory
	{
		IApplicationContext BuildApplicationContext(IUser user);
	}
}