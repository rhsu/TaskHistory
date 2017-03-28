using System.Collections.Generic;
using TaskHistory.ViewModel.Tasks;

namespace TaskHistory.ViewModel.TaskLists
{
	public class TaskListDetailedTableViewModel
	{
		public int ListId { get; set; }
		public string ListName { get; set; }
		public IEnumerable<TaskTableViewModel> Tasks { get; set; }
	}
}