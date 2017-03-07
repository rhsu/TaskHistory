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
		readonly ObjectMapperTaskLists _mapper;

		// TODO Might not need this
		/*public IEnumerable<TaskListViewModel> Retrieve(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var lists = _repo.Read(user.UserId);
			if (lists == null)
				throw new NullReferenceException("Null returned from repo");

			var viewModels = _mapper.Map(lists);
			if (viewModels == null)
				throw new NullReferenceException("Null return from mapper");

			return viewModels;
		}*/

		public TaskListViewModel Create(IUser user, string name)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			var list = _repo.Create(user.UserId, name);
			if (list == null)
				throw new NullReferenceException("null returned from repo");

			var viewModel = _mapper.Map(list);
			if (viewModel == null)
				throw new NullReferenceException("null returned from mapper");

			return viewModel;
		}

		public TaskListOrchestrator(ITaskListRepo repo,
		                            ObjectMapperTaskLists mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}
	}
}
