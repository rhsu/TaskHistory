using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskPriorityRepo : ITaskPriorityRepo
	{
		TaskPriorityFactory _factory;
		ApplicationDataProxy _dataProxy;

		public TaskPriorityRepo(TaskPriorityFactory factory, 
		                        ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public ITaskPriority Create()
		{
			throw new NotImplementedException();
		}

		public ITaskPriority Delete()
		{
			throw new NotImplementedException();
		}

		public ITaskPriority Read()
		{
			throw new NotImplementedException();
		}

		public ITaskPriority Update()
		{
			throw new NotImplementedException();
		}
	}
}
