using System;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Api.ViewRepos;
using TaskHistory.ViewModel.Tasks;
using TaskHistoryObjectMapper;

namespace TaskHistory.Orchestrator.Tasks
{
	public class TasksOrchestrator
	{
		readonly ITaskRepo _repo;
		readonly ITaskViewRepo _viewRepo;
		readonly ObjectMapperTasks _objectMapper;

		public IEnumerable<TaskGridViewModel> Retrieve(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IEnumerable<ITask> tasks = _viewRepo.ReadTasksForUser(user);
			if (tasks == null)
				throw new NullReferenceException($"null returned from TaskViewRepo when reading {user.UserId}");

			IEnumerable<TaskGridViewModel> viewModel = _objectMapper.Map(tasks);
			if (viewModel == null)
				throw new NullReferenceException("Null returned from task presenter");

			return viewModel;
		}

		public TaskGridViewModel Create(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			ITask task = _repo.CreateTask(content, user.UserId);
			if (task == null)
				throw new NullReferenceException("Null returned from task repo");

			TaskGridViewModel viewModel = _objectMapper.Map(task);
			if (viewModel == null)
				throw new NullReferenceException("Null returned from task presenter");

			return viewModel;
		}

		public TaskGridViewModel Edit(IUser user, 
		                              int taskId, 
		                              TaskEditViewModel editViewModel)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (editViewModel == null)
				throw new ArgumentNullException(nameof(editViewModel));

			TaskUpdatingParameters updateParams = _objectMapper.Map(editViewModel);
			if (updateParams == null)
				throw new NullReferenceException("null returned from TaskObjectMapper");

			ITask task = _repo.UpdateTask(updateParams, taskId, user.UserId);
			if (task == null)
				throw new NullReferenceException("null returned from TaskRepo");

			TaskGridViewModel viewModel = _objectMapper.Map(task);
			if (viewModel == null)
				throw new NullReferenceException("null returned from TaskObjectMapper");

			return viewModel;
		}

		public TasksOrchestrator(ITaskRepo repo, ITaskViewRepo viewRepo, ObjectMapperTasks mapper)
		{
			_repo = repo;
			_viewRepo = viewRepo;
			_objectMapper = mapper;
		}
	}
}