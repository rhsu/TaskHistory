using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.ViewRepos
{
	public interface ITaskViewRepo
	{
		IEnumerable<ITask> ReadTasksForUser (IUser user);
	}
}

