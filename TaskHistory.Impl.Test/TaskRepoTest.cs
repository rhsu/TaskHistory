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
			// TODO: https://github.com/rhsu/TaskHistory/issues/54
			// _taskRepo = new TaskRepo ();
		}

		//[Test]
		public void InsertNewTaskTest ()
		{
			//string taskContent = "Hello World";

			//ITask testTask = _taskRepo.CreateNewTask (taskContent);

			//Assert.AreEqual (taskContent, testTask.Content);
			// Assert that SELECT taskContent FROM tasks WHERE Id = testTask.Id 
			// contains the correct taskContent
		}

		//[Test]
		public void DeleteTask ()
		{
			// INSERT INTO taskTable
			// Return last inserted ID

			// call _taskRepo.DeleteTask(lastInsertedId);
		}

		//[Test]
		public void UpdateTask ()
		{
			// INSERT INTO taskTable
			// call _taskRepo.UpdateTask

			// Assert that SELECT taskContent = dto's content
			// Assert that SELECT taskIsCompleted = dtos' isCompleted
		}

		//[Test]
		public void GetTasksForUser()
		{
			// TODO: https://github.com/rhsu/TaskHistory/issues/52
		}
	}
}

