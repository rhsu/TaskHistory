using System;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Application
{
	public interface IApplicationContext
	{
		IUser ApplicationUser { get; }	
	}
}