using System;
using TaskHistory.Api.Labels;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.MySql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Lables
{
	public class LabelFactory : AbstractFromDataReaderFactory<ILabel>
	{
		public LabelFactory (SqlDataReaderFactory dataReaderFactory)
			: base(dataReaderFactory)
		{
		}

		public override ILabel CreateTypeFromDataReader(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			
			int labelId = reader.GetInt ("labelId");
			string name = reader.GetString ("name");

			return new Label (labelId, name);
		}
	}
}

