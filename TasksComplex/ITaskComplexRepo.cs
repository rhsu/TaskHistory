using System;
using TaskHistoryApi.Tasks;
using System.Collections.Generic;
using TaskHistoryApi.Users;

namespace TaskHistoryApi.TasksComplex
{
	public interface ITaskComplexRepo
	{
		IEnumerable<ITaskComplex> GetComplexTasksForUser(IUser user);
	}
}