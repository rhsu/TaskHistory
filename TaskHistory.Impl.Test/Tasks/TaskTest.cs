using System;
using NUnit.Framework;
using TaskHistory.Impl.Tasks;
using Moq;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TaskTest
	{
		private Task _task;

		private const int taskId = 1;
		private const string taskContent = "task";
		private const bool isCompleted = true;

		[SetUp]
		public void SetUp()
		{
			_task = new Task (taskId, taskContent, isCompleted);
		}

		[Test]
		public void TestEqualTestsAreEqual()
		{
			try
			{
				var otherTask = new Mock<Task> ();
				otherTask.SetupGet (mock => mock.TaskId).Returns (taskId);
			}
			catch (Exception ex) 
			{
				var e = ex;
			}

			//otherTask.SetupGet (mock => mock.Content).Returns (taskContent);
			//otherTask.SetupGet (mock => mock.IsCompleted).Returns (isCompleted);

			// Assert.Equals (_task, otherTask.Object);
		}

		[Test]
		public void TestDifferentTestsAreNotEqual()
		{
			//var task = new Task ();
		}
	}
}

