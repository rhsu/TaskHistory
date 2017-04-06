using System;
using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.TaskLists.DataTransferObjects;
using TaskHistory.ViewModel.TaskLists;
using TaskHistoryObjectMapper;

namespace TaskHistory.ObjectMapper.TaskLists
{
	public class ObjectMapperTaskLisWithTasks
	{
		ObjectMapperTasks _taskObjMapper;

		public ObjectMapperTaskLisWithTasks(ObjectMapperTasks taskObjMapper)
		{
			_taskObjMapper = taskObjMapper;
		}

		public IEnumerable<TaskListDetailedTableViewModel> Map(IEnumerable<ITaskList> taskLists)
		{
			if (taskLists == null)
				throw new ArgumentNullException(nameof(taskLists));

			var retVal = new List<TaskListDetailedTableViewModel>();

			foreach (var taskList in taskLists)
			{
				var viewModel = Map(taskList);
				if (viewModel == null)
					throw new NullReferenceException("null returned from ObjectMapper");

				retVal.Add(viewModel);
			}

			return retVal;
		}

		public TaskListDetailedTableViewModel Map(ITaskList taskList)
		{
			if (taskList == null)
				throw new ArgumentNullException(nameof(taskList));

			var vmTasks = _taskObjMapper.Map(taskList.Tasks);
			if (vmTasks == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			var viewModel = new TaskListDetailedTableViewModel(taskList.ListId,
			                                                   taskList.ListName,
			                                                   taskList.IsDeleted,
			                                                   vmTasks);

			return viewModel;
		}

		public TaskListUpdatingParameters Map(TaskListEditViewModel editViewModel)
		{
			if (editViewModel == null)
				throw new ArgumentNullException(nameof(editViewModel));

			string listName = editViewModel.Name;
			bool isDeleted = editViewModel.IsDeleted;

			var updateParams = new TaskListUpdatingParameters(listName, isDeleted);

			return updateParams;
		}
	}
}