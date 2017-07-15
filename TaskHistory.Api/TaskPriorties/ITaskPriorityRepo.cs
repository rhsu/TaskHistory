using System.Collections.Generic;

namespace TaskHistory.Api.TaskPriorities
{
	public interface ITaskPriorityRepo
	{
		ITaskPriority Create(int userId, string name, int rank);
		IEnumerable<ITaskPriority> Read(int userId);
		ITaskPriority Update(int userId, string name, int rank);
		int Delete(int userId, int id);
	}
}