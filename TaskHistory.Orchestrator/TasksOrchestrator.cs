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
		readonly ITaskRepo _taskRepo;
		readonly ITaskViewRepo _taskViewRepo;
		readonly ObjectMapperTasks _taskObjectMapper;

		public IEnumerable<ITask> OrchestratorGetTasks_OLD(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));
			
			return _taskViewRepo.ReadTasksForUser(user);
		}

		public IEnumerable<TaskGridViewModel> OrchestrateGetTasks(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IEnumerable<ITask> tasks = _taskViewRepo.ReadTasksForUser(user);
			if (tasks == null)
				throw new NullReferenceException($"null returned from TaskViewRepo when reading {user.UserId}");

			IEnumerable<TaskGridViewModel> tasksVM = _taskObjectMapper.Map(tasks);
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

		public TaskGridViewModel OrchestrateCreateTask(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException(nameof(content));

			ITask task = _taskRepo.CreateTask(content, user.UserId);
			if (task == null)
				throw new NullReferenceException("Null returned from task repo");

			TaskGridViewModel vmTask = _taskObjectMapper.Map(task);
			if (vmTask == null)
				throw new NullReferenceException("Null returned from task presenter");

			return vmTask;
		}

		public TaskGridViewModel OrchestrateEditTask(IUser user, int taskId, TaskEditViewModel taskEditViewModel)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (taskEditViewModel == null)
				throw new ArgumentNullException(nameof(taskEditViewModel));

			TaskUpdatingParameters updateParams = _taskObjectMapper.Map(taskEditViewModel);
			if (updateParams == null)
				throw new NullReferenceException("null returned from TaskObjectMapper");

			_taskRepo.UpdateTask(updateParams, taskId, user.UserId);

			//TaskGridViewModel retVal = _taskObjectMapper.Map(
			return null;
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

		public TasksOrchestrator(ITaskRepo taskRepo, ITaskViewRepo taskViewRepo, ObjectMapperTasks taskPresenter)
		{
			_taskRepo = taskRepo;
			_taskViewRepo = taskViewRepo;
			_taskObjectMapper = taskPresenter;
		}
	}
}