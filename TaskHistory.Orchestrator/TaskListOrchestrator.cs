using System;
using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Users;
using TaskHistory.ObjectMapper.TaskLists;
using TaskHistory.ViewModel.TaskLists;

namespace TaskHistory.Orchestrator
{
	public class TaskListOrchestrator
	{
		readonly ITaskListRepo _listRepo;
		readonly ObjectMapperTaskLists _listMapper;

		readonly ITaskListWithTasksRepo _listWithTasksRepo;
		readonly ObjectMapperTaskLisWithTasks _listWithTasksMapper;

		public TaskListViewModel Create(IUser user, string name)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			var list = _listRepo.Create(user.Id, name);
			if (list == null)
				throw new NullReferenceException("null returned from Repo");

			var viewModel = _listMapper.Map(list);
			if (viewModel == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return viewModel;
		}

		public IEnumerable<TaskListDetailedTableViewModel> ReadAll(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var lists = _listWithTasksRepo.ReadAll(user.Id);
			if (lists == null)
				throw new NullReferenceException("null returned from Repo");

			var retVal = _listWithTasksMapper.Map(lists);
			if (retVal == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return retVal;
		}

		public TaskListDetailedTableViewModel Read(IUser user, int listId)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var list = _listWithTasksRepo.Read(user.Id, listId);
			if (list == null)
				throw new NullReferenceException("null returned from Repo");

			var retVal = _listWithTasksMapper.Map(list);
			if (retVal == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return retVal;
		}

		public TaskListOrchestrator(ITaskListRepo listRepo,
		                            ObjectMapperTaskLists listMapper,
		                            ITaskListWithTasksRepo listWithTaskRepo,
		                            ObjectMapperTaskLisWithTasks listWithTasksMapper)
		{
			_listRepo = listRepo;
			_listMapper = listMapper;

			_listWithTasksRepo = listWithTaskRepo;
			_listWithTasksMapper = listWithTasksMapper;
		}
	}
}
