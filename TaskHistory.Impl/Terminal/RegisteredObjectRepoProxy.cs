using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Labels;

namespace TaskHistory.Impl.Terminal
{
	public class RegisteredObjectRepoProxy : IRegisteredObjectRepoProxy
	{
		private readonly ITaskRepo _taskRepo;
		private readonly ILabelRepo _labelRepo;

		public ITaskRepo TaskRepo => _taskRepo;

		public ILabelRepo LabelRepo => _labelRepo;

		public RegisteredObjectRepoProxy (ITaskRepo taskRepo, ILabelRepo labelRepo)
		{
			_taskRepo = taskRepo;
			_labelRepo = labelRepo;
		}
	}
}