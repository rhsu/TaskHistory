using System;
using TaskHistory.Api.Sql;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Tasks
{
	public class TaskFactory : IFromDataReaderFactory<ITask>
	{
		public ITask Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			int taskId = reader.GetInt("TaskId");
			int userId = reader.GetInt("UserId");
			int taskPriorityId = reader.GetInt("TaskPriorityId");
			string content = reader.GetString("Content");
			bool isCompleted = reader.GetBool("IsCompleted");

			return new Task(taskId, userId, taskPriorityId, content, isCompleted);
		}
	}
}