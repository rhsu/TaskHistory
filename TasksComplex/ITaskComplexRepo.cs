using System;
using TaskHistoryApi.Tasks;
using System.Collections.Generic;
using TaskHistoryApi.Users;

namespace TaskHistoryApi.TasksComplex
{
	public interface ITasksComplex
	{
		IEnumerable<ITaskComplex> GetComplexTasksForUser(IUser user);
	}
}