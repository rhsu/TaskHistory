using System;
using TaskHistory.Api.Tasks;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Api.ViewRepos;

namespace TaskHistory.Orchestrator.Tasks
{
	public class TasksOrchestrator
	{
		readonly ITaskRepo _taskRepo;
		readonly ITaskViewRepo _taskViewRepo;

		public IEnumerable<ITask> OrchestratorGetTasks_OLD(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			//TODO Lets make a TaskViewModel and display that to the user
			// I think that's what ObjectMapperTask was suppose to Do
			return _taskViewRepo.ReadTasksForUser(user);
		}

		public ITask OrchestratorCreateTask_OLD(IUser user, string content)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			// TODO this means that I will have to retire the current project
			// but eventually these should be VMs instead of the full ITask object
			return _taskRepo.CreateTask(content, user.UserId);
		}

		public void OrchestratorDeleteTask(IUser user, int taskId)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			_taskRepo.DeleteTask(taskId, user.UserId);
		}

		public TasksOrchestrator(ITaskRepo taskRepo, ITaskViewRepo taskViewRepo)
		{
			_taskRepo = taskRepo;
			_taskViewRepo = taskViewRepo;
		}
	}
}