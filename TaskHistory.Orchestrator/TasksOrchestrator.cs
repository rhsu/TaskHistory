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

		public IEnumerable<ITask> OrchestratorGetTasks (IUser theUser)
		{
			if (theUser == null)
				throw new ArgumentNullException ("theUser");

			return _taskViewRepo.ReadTasksForUser (theUser);
		}

		public ITask OrchestratorCreateTask(string content)
		{
			return _taskRepo.CreateNewTask (content);
		}

		public TasksOrchestrator (ITaskRepo taskRepo, ITaskViewRepo taskViewRepo)
		{
			_taskRepo = taskRepo;
			_taskViewRepo = taskViewRepo;
		}
	}
}