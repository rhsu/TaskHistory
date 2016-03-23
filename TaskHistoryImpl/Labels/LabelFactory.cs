using System;
using TaskHistoryApi.Labels;

namespace TaskHistoryImpl
{
	public class LabelFactory
	{
		public ILabel CreateLabel(int id, string name)
		{
			return new Label (id, name);
		}

		public LabelFactory ()
		{
		}
	}
}

