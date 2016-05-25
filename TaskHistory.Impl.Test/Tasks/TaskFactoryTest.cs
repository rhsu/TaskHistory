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

		// [Test]
		public void TestCreateTaskFromDataReader()
		{
			var mockSqlDataReader = new Mock<ISqlDataReader> ();
			mockSqlDataReader.Setup (mock => mock.GetInt (It.IsAny<string>())).Returns (1);
			mockSqlDataReader.Setup (Mock => Mock.GetString (It.IsAny<string>())).Returns (Content);
			mockSqlDataReader.Setup (mock => mock.GetBool (It.IsAny<string>())).Returns (true);

			var _taskFactory = new TaskFactory ();

			var fakeTask = _taskFactory.CreateTypeFromDataReader(mockSqlDataReader.Object);


		}
	}
}

