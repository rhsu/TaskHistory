using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.Labels
{
	public interface ILabelRepo
	{
		ILabel CreateNewLabel (string content);
		IEnumerable<ILabel> ReadAllLabelsForUser(IUser user);
		void UpdateLabel (ILabel labelDto);
		void DeleteLabel(int labelId);
	}

	public interface ILabelRepoAdvanced : ILabelRepo
	{
		void AssociateLabelsToTasks (IEnumerable<ILabel> labels, IEnumerable<ITask> tasks);
		IEnumerable<ILabel> GetAllLabelsForTask(ITask task);
	}
}