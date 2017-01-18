using System;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Api.ViewRepos;
using TaskHistory.Impl.Sql;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.ViewRepos
{
	// TODO: Create a TaskView object
	public class TaskViewRepo : ITaskViewRepo
	{
		private const string ReadStoredProcedure = "Tasks_Select";

		private readonly TaskFactory _taskFactory;
		private readonly ApplicationDataProxy _dataProxy;

		public TaskViewRepo (TaskFactory taskFactory,
			ApplicationDataProxy dataProxy)
		{
			_taskFactory = taskFactory;
			_dataProxy = dataProxy;
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException (nameof(user));

			var parameter = _dataProxy.CreateParameter("pUserId", user.UserId);

			var returnVal = _dataProxy.ExecuteOnCollection (_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from dataProxy");

			return returnVal;
		}
	}
}

