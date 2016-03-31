using NUnit.Framework;
using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TaskRepoTest
	{
		private ITaskRepo _taskRepo;

		[SetUp]
		public void Init()
		{
			_taskRepo = new TaskRepo ();
		}

		[Test]
		public void InsertNewTaskTest ()
		{
		}

		[Test]
		public void DeleteTask ()
		{
			
		}

		[Test]
		public void UpdateTask ()
		{
		}

		[Test]
		public void GetTasksForUser()
		{
		}
	}
}

