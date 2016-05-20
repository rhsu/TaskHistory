using System;
using TaskHistory.Api.Sql;
using MySql.Data.MySqlClient;
using TaskHistory.Impl.MySql;

namespace TaskHistory.Impl.Sql
{
	// TODO: until I figure out a better place to put this
	public class SqlDataReaderFactory
	{
		public ISqlDataReader MakeDataReader (MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			return new SqlDataReader (reader);
		}
	}
}