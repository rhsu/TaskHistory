using System;
using TaskHistory.Api.Tasks;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Api.ViewRepos;

namespace TaskHistory.Orchestrator.Tasks
{
	public class TasksOrchestrator
	{
		private ITaskRepo _taskRepo;
		private ITaskViewRepo _taskViewRepo;

		public IEnumerable<ITask> OrchestratorGetTasks (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("theUser");

			return _taskViewRepo.ReadTasksForUser (user);
		}

		public ITask OrchestratorCreateTask(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException ("theUser");

			return _taskRepo.CreateNewTaskForUser (user, content);
		}

		public TasksOrchestrator (ITaskRepo taskRepo, ITaskViewRepo taskViewRepo)
		{
			_taskRepo = taskRepo;
			_taskViewRepo = taskViewRepo;
		}
	}
}