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

		[SetUp]
		public void SetUp()
		{
			int taskId = 1;
			string taskContent = "task";
			bool isCompleted = true;

			_task = new Task (taskId, taskContent, isCompleted);

			var otherTask = new Mock<Task> ();
			otherTask.SetupGet (mock => mock.TaskId).Returns (taskId);
			otherTask.SetupGet (mock => mock.Content).Returns (taskContent);
			otherTask.SetupGet (mock => mock.IsCompleted).Returns (isCompleted);

			Assert.Equals (_task, otherTask.Object);
		}

		public void TestEqualTestsAreEqual()
		{
			//var fakeTask = new Task
		}

		public void TestDifferentTestsAreNotEqual()
		{
			//var task = new Task ();
		}
	}
}

