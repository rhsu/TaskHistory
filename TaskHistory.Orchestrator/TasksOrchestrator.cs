using System;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Tasks;
using TaskHistoryObjectMapper;

namespace TaskHistory.Orchestrator.Tasks
{
	public class TasksOrchestrator
	{
		readonly ITaskRepo _repo;
		readonly ObjectMapperTasks _objectMapper;

		public TaskTableViewModel Create(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			ITask task = _repo.CreateTask(user.Id, content);
			if (task == null)
				throw new NullReferenceException("null returned from Repo");

			TaskTableViewModel viewModel = _objectMapper.Map(task);
			if (viewModel == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return viewModel;
		}

		public TaskTableViewModel CreateOnList(IUser user, int listId, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			var task = _repo.CreateTaskOnList(user.Id, listId, content);
			if (task == null)
				throw new NullReferenceException("null returned from Repo");

			var viewModel = _objectMapper.Map(task);
			if (viewModel == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return viewModel;
		}

		public IEnumerable<TaskTableViewModel> Read(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IEnumerable<ITask> tasks = _repo.ReadAll(user.Id);
			if (tasks == null)
				throw new NullReferenceException("null returned from Repo");

			IEnumerable<TaskTableViewModel> viewModel = _objectMapper.Map(tasks);
			if (viewModel == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return viewModel;
		}

		public TaskTableViewModel Update(IUser user, 
		                              	 int taskId, 
		                              	 TaskEditViewModel viewModel)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (viewModel == null)
				throw new ArgumentNullException(nameof(viewModel));

			TaskUpdatingParameters updateParams = _objectMapper.Map(viewModel);
			if (updateParams == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			ITask task = _repo.UpdateTask(user.Id, updateParams, taskId);
			if (task == null)
				throw new NullReferenceException("null returned from Repo");

			TaskTableViewModel retVal = _objectMapper.Map(task);
			if (retVal == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return retVal;
		}

		public TasksOrchestrator(ITaskRepo repo, 
		                         ObjectMapperTasks mapper)
		{
			_repo = repo;
			_objectMapper = mapper;
		}
	}
}