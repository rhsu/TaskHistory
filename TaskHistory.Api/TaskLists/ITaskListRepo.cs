﻿using System.Collections.Generic;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskListRepo
	{
		IEnumerable<ITaskList> Read(int userId);

		ITaskList Create(int userId, string name);

		ITaskList Update(int userId, string name);

		bool AssociateTasksToList(int userId, int listId, IEnumerable<int> taskIds);
	}
}