using System.Collections.Generic;
using TaskHistory.ViewModel.Tasks;

namespace TaskHistory.ViewModel.TaskLists
{
	public class TaskListDetailedTableViewModel
	{
		public int ListId { get; }
		public string ListName { get; }
		public IEnumerable<TaskTableViewModel> Tasks { get; }

		public TaskListDetailedTableViewModel(int id, 
		                                      string name, 
		                                      IEnumerable<TaskTableViewModel> tasks)
		{
			ListId = id;
			ListName = name;
			Tasks = tasks;
		}
	}
}