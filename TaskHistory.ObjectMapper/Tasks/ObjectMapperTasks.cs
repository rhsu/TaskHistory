using System;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.ViewModel.Tasks;

namespace TaskHistoryObjectMapper
{
	public class ObjectMapperTasks
	{
		public IEnumerable<TaskTableViewModel> Map (IEnumerable<ITask> tasks)
		{
			if (tasks == null)
				throw new ArgumentNullException (nameof(tasks));

			var returnVal = new List<TaskTableViewModel>();

			foreach (var task in tasks)
			{
				var taskVM = Map(task);
				returnVal.Add(taskVM);
			}

			return returnVal;
		}

		public TaskTableViewModel Map(ITask task)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));

			var returnVal = new TaskTableViewModel(task.Id, task.Content);

			return returnVal;
		}

		public TaskUpdatingParameters Map(TaskEditViewModel taskEditViewModel)
		{
			if (taskEditViewModel == null)
				throw new ArgumentNullException(nameof(taskEditViewModel));

			var returnVal = new TaskUpdatingParameters(taskEditViewModel.TaskContent,
													   taskEditViewModel.IsCompleted,
													   taskEditViewModel.IsDeleted);

			return returnVal;
		}
	}
}