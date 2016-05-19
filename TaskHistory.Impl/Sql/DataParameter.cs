using System;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.MySql
{
	public class DataParameter : ISqlDataParameter
	{
		public string ParameterName { get; }

		public object Value { get; }

		public DataParameter(string name, object value)
		{
			this.ParameterName = name;
			this.Value = value;
		}
	}
}