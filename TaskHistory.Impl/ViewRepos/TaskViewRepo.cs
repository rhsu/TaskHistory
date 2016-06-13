using System;
using TaskHistory.Impl.Tasks;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using TaskHistory.Api.ViewRepos;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

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
				throw new ArgumentNullException ("user");

			var parameter = _dataProxy.ParamFactory.CreateParameter("pUserId", user.UserId);

			var returnVal = _dataProxy.DataReaderProvider.ExecuteReaderForTypeCollection (_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from dataLayer");

			return returnVal;
		}
	}
}

