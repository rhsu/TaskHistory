using System;
using TaskHistoryApi.Tasks;
using System.Collections.Generic;
using TaskHistoryImpl.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistoryImpl.TaskRepo
{
	public class TaskRepo : ITaskRepo
	{
		private readonly TaskFactory _taskFactory;
		private readonly MySqlCommandFactory _mySqlCommandFactory;

		public void CreateTask (ITask task)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Task_Insert");
			command.CommandType = CommandType.StoredProcedure;

		}

		public void DeleteTask (int taskId)
		{
			throw new NotImplementedException ();
		}

		public void UpdateTask (int taskId, ITask newTaskDto)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<ITask> GetTasksByUserId (int userId)
		{
			throw new NotImplementedException ();
		}

		public TaskRepo (TaskFactory taskFactory, MySqlCommandFactory commandFactory)
		{
			_taskFactory = taskFactory;
			_mySqlCommandFactory = commandFactory;
		}
	}
}

