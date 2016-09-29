using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.ViewRepos
{
	public interface ITaskViewRepo
	{
		IEnumerable<ITask> ReadTasksForUser (IUser user);
	}
}

