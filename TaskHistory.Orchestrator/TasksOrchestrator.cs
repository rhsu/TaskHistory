using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Api.ViewRepos;
using TaskHistory.ViewModel.Tasks;
using TaskHistoryObjectMapper;

namespace TaskHistory.Orchestrator.Tasks
{
	public class TasksOrchestrator
	{
		readonly ITaskRepo _taskRepo;
		readonly ITaskViewRepo _taskViewRepo;
		readonly IFeatureFlagRepo _featureFlagRepo;
		readonly ObjectMapperTasks _taskObjectMapper;

		readonly IFeatureFlag _productionDatabaseFlag;

		public IEnumerable<TaskTableViewModel> Retrieve(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IEnumerable<ITask> tasks = _viewRepo.ReadTasksForUser(user);
			if (tasks == null)
				throw new NullReferenceException($"null returned from TaskViewRepo when reading {user.UserId}");

			IEnumerable<TaskTableViewModel> viewModel = _objectMapper.Map(tasks);
			if (viewModel == null)
				throw new NullReferenceException("Null returned from task presenter");

			return viewModel;
		}

		public TaskTableViewModel Create(IUser user, string content)
    {
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			ITask task = _repo.CreateTask(content, user.UserId);
			if (task == null)
				throw new NullReferenceException("Null returned from task repo");

			TaskTableViewModel viewModel = _objectMapper.Map(task);
			if (viewModel == null)
				throw new NullReferenceException("Null returned from task presenter");

			return viewModel;
		}


		public TaskTableViewModel Edit(IUser user, 
		                              int taskId, 
		                              TaskEditViewModel viewModel)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (viewModel == null)
				throw new ArgumentNullException(nameof(viewModel));

			TaskUpdatingParameters updateParams = _objectMapper.Map(viewModel);
			if (updateParams == null)
				throw new NullReferenceException("null returned from TaskObjectMapper");

			ITask task = _repo.UpdateTask(updateParams, user.UserId, taskId);
			if (task == null)
				throw new NullReferenceException("null returned from TaskRepo");

			TaskTableViewModel retVal = _objectMapper.Map(task);
			if (retVal == null)
				throw new NullReferenceException("null returned from TaskObjectMapper");

			return retVal;
		}

		public bool OrchestratorDeleteTask(IUser user, int taskId)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			_taskRepo.DeleteTask_OLD(taskId, user.UserId);

			return true;
		}

		public TasksOrchestrator(ITaskRepo taskRepo, 
		                         ITaskViewRepo taskViewRepo, 
		                         ObjectMapperTasks taskPresenter,
		                         IFeatureFlagRepo featureFlagRepo)
		{
			_taskRepo = taskRepo;
			_taskViewRepo = taskViewRepo;
			_taskObjectMapper = taskPresenter;
			_featureFlagRepo = featureFlagRepo;

			_productionDatabaseFlag = featureFlagRepo.Read("production");
		}
	}
}