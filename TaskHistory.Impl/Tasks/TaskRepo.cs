using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskRepo : ITaskRepo
	{
		const string CreateStoredProcedure = "Tasks_Insert";
		const string ReadStoredProcedure = "Tasks_Select";
		const string UpdateStoredProcedure = "Tasks_Update";
		const string DeleteStoredProcedure = "Tasks_Delete";

		// TODO move this to a shared base
		const string NullFromApplicationDataProxy = "Null returned from DataProvider";

		readonly TaskFactory _taskFactory;
		readonly ApplicationDataProxy _dataProxy;

		public ITask CreateTask(string taskContent, int userId)
		{
			if (taskContent == null)
				throw new ArgumentNullException(nameof(taskContent));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pTaskContent", taskContent));
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));

			var returnVal = _dataProxy
				.Execute(_taskFactory, CreateStoredProcedure, parameters);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public IEnumerable<ITask> ReadTasks(int userId)
		{
			var parameter = _dataProxy.CreateParameter("pUserId", userId);

			var returnVal = _dataProxy.ExecuteOnCollection(_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public ITask UpdateTask(TaskUpdatingParameters taskParameterDto, int userId, int taskId)
		{
			if (taskParameterDto == null)
				throw new ArgumentNullException(nameof(taskParameterDto));

			var parameters = new List<ISqlDataParameter>();

			// task update fields
			parameters.Add(_dataProxy.CreateParameter("pContent", taskParameterDto.Content));
			parameters.Add(_dataProxy.CreateParameter("pIsCompleted", taskParameterDto.IsCompleted));
			parameters.Add(_dataProxy.CreateParameter("pIsDeleted", taskParameterDto.IsDeleted));

			// "where" clause fields
			parameters.Add(_dataProxy.CreateParameter("pTaskId", taskId));
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));

			ITask task = _dataProxy.Execute(_taskFactory, UpdateStoredProcedure, parameters);
			if (task == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return task;
		}

		public TaskRepo(TaskFactory taskFactory,
		                ApplicationDataProxy applicationDataProxy)
		{
			_taskFactory = taskFactory;
			_dataProxy = applicationDataProxy;
		}
	}
}