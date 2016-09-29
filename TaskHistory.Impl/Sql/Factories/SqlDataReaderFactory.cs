using System;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;

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
				throw new ArgumentNullException (nameof(reader));

			return new SqlDataReader (reader);
		}
	}
}