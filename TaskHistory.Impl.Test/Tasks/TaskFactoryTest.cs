using System;
using NUnit.Framework;
using TaskHistory.Impl.Tasks;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;
using Moq;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TaskFactoryTest
	{
		private const string Content = "Content";
		private const int TaskId = 1;
		private const bool Status = true;

		//private IKernel _kernel;

		public void Init()
		{
			

			//_taskFactory = _kernel.Get<TaskFactory> ();
		}

		public void Dispose()
		{
			
		}

		public TaskFactoryTest ()
		{
		}

		[Test]
		public void TestCreateTaskFromDataReader()
		{
			var mockSqlDataReader = new Mock<ISqlDataReader> ();
			mockSqlDataReader.Setup (mock => mock.GetInt (It.IsAny<string>())).Returns (TaskId);
			mockSqlDataReader.Setup (mock => mock.GetString (It.IsAny<string>())).Returns (Content);
			mockSqlDataReader.Setup (mock => mock.GetBool (It.IsAny<string>())).Returns (Status);

			var _taskFactory = new TaskFactory ();

			var task = _taskFactory.CreateTypeFromDataReader(mockSqlDataReader.Object);

			Assert.AreEqual (Content, task.Content);
		}
	}
}

