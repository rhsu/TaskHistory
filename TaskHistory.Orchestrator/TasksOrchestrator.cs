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

		public IEnumerable<ITask> OrchestratorGetTasks_OLD(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));
			
			return _taskViewRepo.ReadTasksForUser(user);
		}

		public IEnumerable<TaskTableViewModel> OrchestrateGetTasks(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IEnumerable<ITask> tasks = _taskViewRepo.ReadTasksForUser(user);
			if (tasks == null)
				throw new NullReferenceException($"null returned from TaskViewRepo when reading {user.UserId}");

			IEnumerable<TaskTableViewModel> tasksVM = _taskObjectMapper.Map(tasks);
			if (tasksVM == null)
				throw new NullReferenceException("Null returned from task presenter");

			return tasksVM;
		}

		public ITask OrchestratorCreateTask_OLD(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return _taskRepo.CreateTask(content, user.UserId);
		}

		public TaskTableViewModel OrchestrateCreateTask(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			ITask task = _taskRepo.CreateTask(content, user.UserId);
			if (task == null)
				throw new NullReferenceException("Null returned from task repo");

			TaskTableViewModel vmTask = _taskObjectMapper.Map(task);
			if (vmTask == null)
				throw new NullReferenceException("Null returned from task presenter");

			return vmTask;
		}

		public TaskTableViewModel OrchestrateEditTask(IUser user, 
		                                             int taskId, 
		                                             TaskEditViewModel taskEditViewModel)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (taskEditViewModel == null)
				throw new ArgumentNullException(nameof(taskEditViewModel));

			TaskUpdatingParameters updateParams = _taskObjectMapper.Map(taskEditViewModel);
			if (updateParams == null)
				throw new NullReferenceException("null returned from TaskObjectMapper");

			ITask updatedTask = _taskRepo.UpdateTask(updateParams, taskId, user.UserId);
			if (updatedTask == null)
				throw new NullReferenceException("null returned from TaskRepo");

			TaskTableViewModel retVal = _taskObjectMapper.Map(updatedTask);
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

		public bool OrchestrateSetTaskIsDeleted(IUser user, int taskId, bool status)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));
			
			_taskRepo.UpdateIsDeleted(taskId, user.UserId, status);

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