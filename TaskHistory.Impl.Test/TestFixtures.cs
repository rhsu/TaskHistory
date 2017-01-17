using System;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Tasks;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test
{
	public class TestFixtures
	{
		readonly IUserRepo _userRepo;
		readonly ITaskRepo _taskRepo;
		readonly ITaskListRepo _taskListRepo;

		IUser _user;
		ITask _task;
		ITaskList _taskList;

		IUser _user;

		public IUser User
		{
			get { return _user; }
		}

		public TestFixtures()
		{
			var userFactory = new UserFactory();
			var taskFactory = new TaskFactory();
			var taskListFactory = new TaskListFactory();

			var appDataProxyFactory = new ApplicationDataProxyFactory();


			_userRepo = new UserRepo(userFactory, appDataProxyFactory.Build());
			_taskListRepo = new TaskListRepo(taskListFactory, appDataProxyFactory.Build());
			_taskRepo = new TaskRepo(taskFactory, appDataProxyFactory.Build());

			CreateUser();
			CreateTask();
		}

		void CreateUser()
		{
			var time = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

			var username = $"u{time}";
			var password = "password";
			var firstName = "first";
			var lastName = "last";
			var email = "email@email.com";

			var userParms = new UserRegistrationParameters(username, 
			                                               password,
			                                               firstName,
			                                               lastName,
			                                               email);

			_user = _userRepo.RegisterUser(userParms);
		}

		void CreateTask()
		{
			_task = _taskRepo.CreateTask("My First Task", _user.UserId);
		}

		void CreateTaskList()
		{
			_taskListRepo.Create(_user.UserId, "My First Task List");
		}

		public TestFixtures()
		{
			var userFactory = new UserFactory();
			var appDataProxyFactory = new ApplicationDataProxyFactory();

			_userRepo = new UserRepo(userFactory, appDataProxyFactory.Build());

			CreateUser();
		}
	}
}
