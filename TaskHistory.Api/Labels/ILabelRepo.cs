﻿using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.Labels
{
	public interface ILabelRepo
	{
		IEnumerable<ILabel> GetAllLabelsForUser(IUser user);
		ILabel InsertNewLabel (string content);

		void DeleteLabel(int labelId);
		void UpdateLabel (ILabel labelDto);
	}

	public interface ILabelRepoAdvanced : ILabelRepo
	{
		void AssociateLabelsToTasks (IEnumerable<ILabel> labels, IEnumerable<ITask> tasks);
		IEnumerable<ILabel> GetAllLabelsForTask(ITask task);
	}
}