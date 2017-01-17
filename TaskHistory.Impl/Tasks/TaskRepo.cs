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

		const string UpdateIsDeletedStoredProcedure = "Tasks_IsDeleted_Update";
		const string UpdateIsCompletedStoredProcedure = "Tasks_IsCompleted_Update";

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

			var returnVal = _dataProxy.ExecuteReaderForTypeCollection(_taskFactory, ReadStoredProcedure, parameter);
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

		public void DeleteTask_OLD(int taskId, int userId)
		{
			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pTaskId", taskId));
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			_dataProxy.ExecuteNonQuery(DeleteStoredProcedure, parameters);
		}

		public bool UpdateIsDeleted(int taskId, int userId, bool isDeleted)
		{
			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pTaskId", taskId));
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pIsDeleted", isDeleted));

			_dataProxy.ExecuteNonQuery(UpdateIsDeletedStoredProcedure, parameters);

			// TODO this should come back from ExecuteNonQuery (either true, if record actually was updated).
			// for example wasDeleted => stillDeleted is false
			return true;
		}

		public TaskRepo(TaskFactory taskFactory,
			ApplicationDataProxy applicationDataProxy)
		{
			_taskFactory = taskFactory;
			_dataProxy = applicationDataProxy;
		}
	}
}