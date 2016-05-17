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
		/*public ILabel MakeTypeFromDataReader(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");


		}*/

		public ILabel MakeTypeFromDataReader(IDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			//int labelId = Convert.ToInt32 (reader ["labelId"]);
			//string name = reader ["name"].ToString ();

			int labelId = reader.GetInt ("labelId");
			string name = reader.GetString ("name");

			return new Label (labelId, name);
		}
	}
}

