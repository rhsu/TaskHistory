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
		const string CreateTaskAndAssociateToList = "Tasks_Insert_List_Associate";

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
				.ExecuteReader(_taskFactory, CreateStoredProcedure, parameters);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public bool AssertTaskListExists(int userId, int listId)
		{
			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pListId", listId));

			// TODO can nonquery or DataReader return an int from
			// a SELECT COUNT(*) like query?
			/*SELECT t.* FROM Tasks t
	INNER JOIN TaskToTaskListAssociations a
	ON t.TaskId
    INNER JOIN TaskLists l
    ON l.Id;*/

			return true;
		}

		public ITask CreateTaskOnList(int userId, int listId, string content)
		{
			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pContent", content));
			parameters.Add(_dataProxy.CreateParameter("pListId", listId));

			var retVal = _dataProxy.ExecuteReader(_taskFactory,
			                                      CreateTaskAndAssociateToList,
			                                      parameters);

			if (retVal == null)
				throw new NullReferenceException("Null returned from dataProxy");

			return retVal;
		}

		public bool AssociateTaskToList(int userId, int taskId, int listId)
		{
			return false;
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

			ITask task = _dataProxy.ExecuteReader(_taskFactory, UpdateStoredProcedure, parameters);
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