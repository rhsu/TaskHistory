using System;
using System.Collections.Generic;
using TaskHistory.Api.History;
using TaskHistory.Api.History.DataTransferObjects;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.TaskPriorities;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.History;
using TaskHistory.Impl.Sql;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.TaskPriorities;
using TaskHistory.Impl.Tasks;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test
{
	public class TestFixtures
	{
		readonly IUserRepo _userRepo;
		readonly ITaskRepo _taskRepo;
		readonly ITaskListRepo _taskListRepo;
		readonly IHistoryRepo _historyRepo;
		readonly ITaskPriorityRepo _taskPriorityRepo;

		readonly ApplicationDataProxy _dataProxy;

		IUser _user;
		ITask _task;
		ITaskList _taskList;
		List<IHistory> _histories;
		ITaskPriority _taskPriority;

		public IUser User
		{
			get { return _user; }
		}

		public ITaskList TaskList
		{
			get { return _taskList; }
		}

		public ITask Task
		{
			get { return _task; }
		}

		public IEnumerable<IHistory> Histories
		{
			get { return _histories; }
		}

		public ITaskPriority TaskPriority
		{
			get { return _taskPriority; }
		}

		public TestFixtures()
		{
			var userFactory = new UserFactory();
			var taskFactory = new TaskFactory();
			var taskListFactory = new TaskListQueryCacheFactory();
			var historyFactory = new HistoryFactory();
			var taskPriorityFactory = new TaskPriorityFactory();

			var appDataProxyFactory = new ApplicationDataProxyFactory();
			_dataProxy = appDataProxyFactory.Build();

			_dataProxy.ExecuteNonQuery("_Data_Reset");

			_userRepo = new UserRepo(userFactory, _dataProxy);
			_taskListRepo = new TaskListRepo(taskListFactory, _dataProxy);
			_taskRepo = new TaskRepo(taskFactory, _dataProxy);
			_historyRepo = new HistoryRepo(historyFactory, _dataProxy);
			_taskPriorityRepo = new TaskPriorityRepo(taskPriorityFactory, _dataProxy);

			_histories = new List<IHistory>();

			CreateUser();
			CreateTask();
			CreateTaskList();
			CreateTaskPriority();
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
			_task = _taskRepo.CreateTask(_user.Id, "My First Task");


			var historyDto = new HistoryCreationParams(BusinessAction.Create,
			                                           BusinessObject.Task);

			var history = _historyRepo.Create(_user.Id, historyDto);
			_histories.Add(history);
		}

		void CreateTaskList()
		{
			_taskList = _taskListRepo.Create(_user.Id, "My First Task List");

			var historyDto = new HistoryCreationParams(BusinessAction.Create,
													   BusinessObject.TaskList);

			var history =_historyRepo.Create(_user.Id, historyDto);
			_histories.Add(history);
		}

		void CreateTaskPriority()
		{
			_taskPriority = _taskPriorityRepo.Create(_user.Id,
													 "High",
													 0);
		}
	}
}
