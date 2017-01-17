using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Users;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Users;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TaskListRepoTest
	{
		ITaskListRepo _taskListRepo;

		public TaskListRepoTest()
		{
			var factory = new TaskListFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_taskListRepo = new TaskListRepo(factory, appDataProxy);
		}

		/*public void AssociateTaskToList()
		{
		}*/

		public void Create()
		{
			var userFactory = new UserFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			IUserRepo _userRepo = new UserRepo(userFactory, appDataProxy);

			// IUser user = _userRepo.RegisterUser
		}

		/*public void Read()
		{
			
		}

		public void Update()
		{
			
		}*/
	}
}
