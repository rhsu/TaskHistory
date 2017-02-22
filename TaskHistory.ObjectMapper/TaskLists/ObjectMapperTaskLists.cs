using System;
using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.ViewModel.TaskLists;

namespace TaskHistory.ObjectMapper.TaskLists
{
	public class ObjectMapperTaskLists
	{
		public IEnumerable<TaskListViewModel> Map(IEnumerable<ITaskList> lists)
		{
			if (lists == null)
				throw new ArgumentNullException(nameof(lists));

			var viewModels = new List<TaskListViewModel>();

			foreach (var list in lists)
			{
				var viewModel = Map(list);
				viewModels.Add(viewModel);
			}

			return viewModels;
		}

		public TaskListViewModel Map(ITaskList list)
		{
			if (list == null)
				throw new ArgumentNullException(nameof(list));

			var viewModel = new TaskListViewModel();
			viewModel.Id = list.Id;
			viewModel.Name = list.Name;

			return viewModel;
		}
	}
}
