using System;
using TaskHistory.Api.Labels;

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

