using System;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Labels
{
	public class LabelFactory : BaseFromDataReaderFactory<ILabel>
	{
		public override ILabel CreateTypeFromDataReader(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			int labelId = reader.GetInt("labelId");
			string name = reader.GetString("name");

			return new Label(labelId, name);
		}
	}
}