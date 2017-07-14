using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskPriorityRepo
	{
		ITaskPriority Create(int userId, string name, int rank);
		IEnumerable<ITaskPriority> Read(int userId);
		ITaskPriority Update();
		int Delete(int userId, int id);
	}
}