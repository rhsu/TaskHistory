using System;
using TaskHistory.Api.Sql;
using MySql.Data.MySqlClient;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Factory for the ISqlDataReader object
	/// Consider using ApplicationDataProxy instead of this class directly
	/// </summary>
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