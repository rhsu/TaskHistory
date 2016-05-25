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
		private readonly SqlParameterFactory _paramFactory;
		private readonly IDataProvider _dataLayer;

		public TaskViewRepo (TaskFactory taskFactory,
			SqlParameterFactory paramFactory,
			IDataProvider dataLayer)
		{
			_taskFactory = taskFactory;
			_paramFactory = paramFactory;
			_dataLayer = dataLayer;
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var parameter = _paramFactory.CreateParameter("pUserId", user.UserId);

			var returnVal = _dataLayer.ExecuteReaderForTypeCollection (_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from dataLayer");

			return returnVal;
		}
	}
}

