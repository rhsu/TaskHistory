using System;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskRepo : ITaskRepo
	{
		const string CreateStoredProcedure = "Tasks_Insert";
		const string ReadStoredProcedure = "Tasks_Select";
		const string UpdateStoredProcedure = "Tasks_Update";
		const string DeleteStoredProcedure = "Tasks_Delete";

		const string NullFromApplicationDataProxy = "Null returned from DataProvider";

		readonly TaskFactory _taskFactory;
		readonly ApplicationDataProxy _dataProxy;

		public ITask CreateTask(string taskContent, int userId)
		{
			if (taskContent == null)
				throw new ArgumentNullException(nameof(taskContent));

			var parameters = new List<ISqlDataParameter>();
			var paramFactory = _dataProxy.ParamFactory;

			parameters.Add(paramFactory.CreateParameter("pTaskContent", taskContent));
			parameters.Add(paramFactory.CreateParameter("pUserId", userId));

			var returnVal = _dataProxy
				.DataReaderProvider
				.ExecuteReaderForSingleType(_taskFactory, CreateStoredProcedure, parameters);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public IEnumerable<ITask> ReadTasks(int userId)
		{
			var parameter = _dataProxy.ParamFactory.CreateParameter("pUserId", userId);

			var returnVal = _dataProxy.DataReaderProvider.ExecuteReaderForTypeCollection(_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public void UpdateTask(TaskUpdatingParameters taskParameterDto, int userId)
		{
			if (taskParameterDto == null)
				throw new ArgumentNullException(nameof(taskParameterDto));

			var parameters = new List<ISqlDataParameter>();
			var paramFactory = _dataProxy.ParamFactory;

			parameters.Add(paramFactory.CreateParameter("pContent", taskParameterDto.Content));
			parameters.Add(paramFactory.CreateParameter("pIsCompleted", taskParameterDto.IsCompleted));
			parameters.Add(paramFactory.CreateParameter("pIsDeleted", taskParameterDto.IsDeleted));
			parameters.Add(paramFactory.CreateParameter("pTaskId", taskParameterDto.TaskId));
			parameters.Add(paramFactory.CreateParameter("pUserId", userId));

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery(UpdateStoredProcedure, parameters);
		}

		public void DeleteTask(int taskId, int userId)
		{
			var parameter = _dataProxy.ParamFactory.CreateParameter("pTaskId", taskId);
			if (parameter == null)
				throw new NullReferenceException("Null returned from dataProxy when creating parameter");

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery(DeleteStoredProcedure, parameter);
		}

		public TaskRepo(TaskFactory taskFactory,
			ApplicationDataProxy applicationDataProxy)
		{
			_taskFactory = taskFactory;
			_dataProxy = applicationDataProxy;
		}
	}
}