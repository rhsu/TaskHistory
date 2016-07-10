using System;
using NUnit.Framework;
using TaskHistory.Impl.Tasks;
using Moq;
using TaskHistory.Api.Tasks;

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
			var otherTask = new Mock<ITask> ();

			otherTask.SetupGet (mock => mock.TaskId).Returns (taskId);
			otherTask.SetupGet (mock => mock.Content).Returns (taskContent);
			otherTask.SetupGet (mock => mock.IsCompleted).Returns (isCompleted);

			otherTask.Setup (mock => mock.Equals(It.IsAny<Object>())).Returns(true);

			// TODO Make need a SO Question I have no idea what is going on here.
			bool b = _task.Equals (otherTask.Object);

			bool c = otherTask.Object.Equals (_task);

			Assert.AreEqual (otherTask.Object, _task);
		}

		[Test]
		public void TestDifferentTestsAreNotEqual()
		{
			//var task = new Task ();
		}
	}
}

