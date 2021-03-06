﻿using System;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class SqlDataReader : ISqlDataReader
	{
		MySqlDataReader _reader;

		public SqlDataReader(MySqlDataReader reader)
		{
			_reader = reader;
		}

		public bool Read()
		{
			return _reader.Read ();
		}

		public int GetInt(string propertyName)
		{
			var obj = GetObjectFromReader (propertyName);
			return Convert.ToInt32 (obj);
		}

		public int? GetNullableInt(string propertyName)
		{
			var obj = GetObjectFromReader(propertyName);
			if (DBNull.Value == obj)
				return null;
			
			return Convert.ToInt32(obj);
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

		public bool? GetNullableBool(string propertyName)
		{
			var obj = GetObjectFromReader(propertyName);
			if (DBNull.Value == obj)
				return null;

			return Convert.ToBoolean(obj);
		}

		public T GetEnum<T>(string propertyName)
		{
			var str = GetString(propertyName);
			return (T) Enum.Parse(typeof(T), str);
		}

		public DateTime GetDateTime(string propertyName)
		{
			var obj = GetObjectFromReader(propertyName);
			return Convert.ToDateTime(obj);
		}

		object GetObjectFromReader(string propertyName)
		{
			object obj = null;

			try
			{
				obj = _reader[propertyName];
			}
			catch (Exception)
			{
				throw new Exception(string.Format("the property name {0} was not found in the dataReader",
					propertyName));
			}

			return obj;
		}
	}
}

