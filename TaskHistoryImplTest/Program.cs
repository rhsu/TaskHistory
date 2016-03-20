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

				ITaskRepo myRepo = kernel.Get<ITaskRepo> ();
				ITask thing = myRepo.CreateTask ("Hello World");

				Console.WriteLine (thing.TaskId);
				Console.WriteLine (thing.Content);
				Console.WriteLine (thing.IsCompleted);
			}

			Console.WriteLine ("Successfully inserted a task");
		}
	}
}
