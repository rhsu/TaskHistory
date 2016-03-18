using System;
using Ninject;
using TaskHistoryApi.Tasks;
using TaskHistoryImpl.Tasks;

namespace TaskHistoryImplTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (IKernel kernel = new StandardKernel ()) 
			{
				kernel.Bind<ITaskRepo> ()
					.To<TaskRepo> ();

				kernel.Bind<ITask> ()
					.To<Task> ();

				var taskFactory = kernel.Get<TaskFactory> ();

				bool isCompleted = true;
				//var testDto = new Task (1, "Hello", isCompleted);
				taskFactory.CreateTask(

				ITaskRepo myRepo = kernel.Get<ITaskRepo> ();

				myRepo.CreateTask (testDto);
			}

			Console.WriteLine ("Successfully inserted a task");
		}
	}
}
