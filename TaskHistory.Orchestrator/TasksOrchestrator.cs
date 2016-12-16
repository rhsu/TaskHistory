using System;
using TaskHistory.Api.Tasks;
using System.Collections.Generic;
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
		readonly ObjectMapperTasks _taskPresenter;

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

			IEnumerable<TaskGridViewModel> tasksVM = _taskPresenter.Map(tasks);
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

			TaskGridViewModel vmTask = _taskPresenter.Map(task);
			if (vmTask == null)
				throw new NullReferenceException("Null returned from task presenter");

			return vmTask;
		}

		public void OrchestratorDeleteTask(IUser user, int taskId)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			_taskRepo.DeleteTask(taskId, user.UserId);
		}

		public TasksOrchestrator(ITaskRepo taskRepo, ITaskViewRepo taskViewRepo, ObjectMapperTasks taskPresenter)
		{
			_taskRepo = taskRepo;
			_taskViewRepo = taskViewRepo;
			_taskPresenter = taskPresenter;
		}
	}
}