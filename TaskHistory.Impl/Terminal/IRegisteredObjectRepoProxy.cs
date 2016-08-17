using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Labels;

namespace TaskHistory.Impl.Terminal
{
	//TODO maybe refactor this to the API. I don't know yet
	public interface IRegisteredObjectRepoProxy
	{
		ITaskRepo TaskRepo { get; }

		ILabelRepo LabelRepo { get; }
	}
}

