using System;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class SqlDataReader : ISqlDataReader
	{
		private MySqlDataReader _reader;

		private object GetObjectFromReader (string propertyName)
		{
			object obj = null;

			try
			{
				obj = _reader[propertyName];
			}
			// TODO: What exception is this?
			catch (Exception) 
			{
				// TODO: Create custom excpetion for this.
				throw new Exception(string.Format("the property name {0} was not found in the dataReader", 
					propertyName));
			}

			return obj;
		}

		public bool Read()
		{
			return _reader.Read ();
		}

		public bool NextResult()
		{
			return _reader.NextResult();
		}

		public int GetInt(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return Convert.ToInt32 (obj);
		}

		public string GetString(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return obj.ToString ();
		}

		public bool GetBool(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return Convert.ToBoolean (obj);
		}

		public SqlDataReader (MySqlDataReader reader)
		{
			_reader = reader;
		}
	}
}

