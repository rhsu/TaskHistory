using System;
using TaskHistory.Api.Labels;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.MySql;

namespace TaskHistory.Impl
{
	public class LabelFactory : IFromDataReaderFactory<ILabel>
	{
		private DataReaderFactory _dataReaderFactory;

		public LabelFactory (DataReaderFactory dataReaderFactory)
		{
			_dataReaderFactory = dataReaderFactory;
		}

		// TODO: Temporary AD HOC method until DataReader implementation is built
		public ILabel CreateTypeFromDataReader(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			var sqlDataReader = _dataReaderFactory.MakeDataReader (reader);

			ILabel label = CreateTypeFromDataReader (sqlDataReader);
			if (label == null)
				throw new NullReferenceException ("Null returned from CreateTypeFromReader");

			return label;
		}

		public ILabel CreateTypeFromDataReader(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			
			int labelId = reader.GetInt ("labelId");
			string name = reader.GetString ("name");

			return new Label (labelId, name);
		}
	}
}

