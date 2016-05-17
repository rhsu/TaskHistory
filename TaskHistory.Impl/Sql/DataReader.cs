using System;
using TaskHistory.Api.Sql;
using MySql.Data.MySqlClient;

namespace TaskHistory.Impl.MySql
{
	// TODO: until I figure out a better place to put this
	public class DataReaderFactory
	{
		IDataReader MakeDataReader (MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			return new DataReader (reader);
		}
	}

	public class DataReader : IDataReader
	{
		private MySqlDataReader _reader;

		private object GetObjectFromReader (string propertyName)
		{
			try
			{
				var obj = _reader[propertyName];
			}
			// TODO: What exception is this?
			catch (Exception ex) 
			{
				// TODO: Create custom excpetion for this.
				throw new Exception(string.Format("the property name {0} was not found in the dataReader", 
					propertyName));
			}

			return null;
		}

		public bool Read()
		{
			return _reader.Read ();
		}

		int GetInt(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return Convert.ToInt32 (obj);
		}

		string GetString(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return obj.ToString ();
		}

		int GetBool(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return Convert.ToBoolean (obj);
		}

		public DataReader (MySqlDataReader reader)
		{
			_reader = reader;
		}
	}
}

