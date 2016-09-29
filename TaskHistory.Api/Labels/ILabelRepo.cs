using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;

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