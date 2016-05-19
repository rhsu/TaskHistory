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

		public IEnumerable<ITask> OrchestratorGetTasks()
		{
			var fakeUser = new FakeTempUser ();

			return _taskViewRepo.ReadTasksForUser (fakeUser);
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

	// TODO: https://github.com/rhsu/TaskHistory/issues/57
	public class FakeTempUser : IUser
	{
		public int UserId { get; }
		public string Username { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string FullName { get; }
		public string Email { get; }

		public FakeTempUser()
		{
			this.UserId = 1;
			this.Username = "User Name";
			this.FirstName = "First Name";
			this.LastName = "Last Name";
			this.FullName = "Full Name";
			this.Email = "Email";
		}
	}
}

