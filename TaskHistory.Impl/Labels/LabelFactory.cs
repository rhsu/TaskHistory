using System;
using TaskHistory.Api.Labels;
using MySql.Data.MySqlClient;

namespace TaskHistory.Impl
{
	public class LabelFactory
	{
		public ILabel CreateLabel(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			
			int labelId = Convert.ToInt32 (reader ["labelId"]);
			string name = reader ["name"].ToString ();

			return new Label (labelId, name);
		}

		public LabelFactory ()
		{
		}
	}
}

