using System;
using TaskHistory.Api.Sql;
using MySql.Data.MySqlClient;

namespace TaskHistory.Impl.Sql
{
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