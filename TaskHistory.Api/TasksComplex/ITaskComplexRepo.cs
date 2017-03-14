using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.TasksComplex
{
	public interface ITaskComplexRepo
	{
		IEnumerable<ITaskComplex> ReadComplexTasksForUser(IUser user);
	}
}