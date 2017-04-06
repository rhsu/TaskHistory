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
		readonly ITaskListRepo _repo;
		readonly ObjectMapperTaskLisWithTasks _objectMapper;

		public TaskListDetailedTableViewModel Create(IUser user, string name)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			var list = _repo.Create(user.Id, name);
			if (list == null)
				throw new NullReferenceException("null returned from Repo");

			var viewModel = _objectMapper.Map(list);
			if (viewModel == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return viewModel;
		}

		public IEnumerable<TaskListDetailedTableViewModel> ReadAll(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var lists = _repo.ReadAll(user.Id);
			if (lists == null)
				throw new NullReferenceException("null returned from Repo");

			var retVal = _objectMapper.Map(lists);
			if (retVal == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return retVal;
		}

		public TaskListDetailedTableViewModel Read(IUser user, int listId)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var list = _repo.Read(user.Id, listId);
			if (list == null)
				throw new NullReferenceException("null returned from Repo");

			var retVal = _objectMapper.Map(list);
			if (retVal == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return retVal;
		}

		public TaskListDetailedTableViewModel Update(IUser user, int listId, string listContent)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			// var taskList = _repo.Update(user.Id, listId, 

			return null;
		}

		public TaskListOrchestrator(ITaskListRepo repo,
		                            ObjectMapperTaskLisWithTasks mapper)
		{
			_repo = repo;
			_objectMapper = mapper;
		}
	}
}
