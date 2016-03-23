using System;

namespace TaskHistoryApi.Labels
{
	public interface ILabel
	{
		int LabelId { get; }
		string Name { get; }
	}
}

