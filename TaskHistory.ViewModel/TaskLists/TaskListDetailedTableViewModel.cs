using System.Collections.Generic;
using TaskHistory.ViewModel.Tasks;

namespace TaskHistory.ViewModel.TaskLists
{
	public class TaskListDetailedTableViewModel
	{
		public int ListId { get; }
		public string ListName { get; }
		public bool IsDeleted { get; }

		public IEnumerable<TaskTableViewModel> Tasks { get; }

		public TaskListDetailedTableViewModel(int id, 
		                                      string name, 
		                                      bool isDeleted,
		                                      IEnumerable<TaskTableViewModel> tasks)
		{
			ListId = id;
			ListName = name;
			IsDeleted = isDeleted;
			Tasks = tasks;
		}
	}
}