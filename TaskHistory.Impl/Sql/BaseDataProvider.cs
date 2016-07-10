using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public abstract class BaseDataProvider
	{
		public BaseDataProvider ()
		{
		}

		protected static List<MySqlParameter> CreateMySqlParametersFromSqlDataParams(IEnumerable<ISqlDataParameter> parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			var returnVal = new List<MySqlParameter> ();

			foreach (var p in parameters) 
			{
				var sqlParam = CreateSqlParameterFromSqlDataParams (p);
				if (sqlParam == null)
					throw new NullReferenceException ("Null returned from CreateMySqlParametersFromSqlDataParams");
	
				returnVal.Add(sqlParam);
			}

			return returnVal;
		}

		protected static MySqlParameter CreateSqlParameterFromSqlDataParams(ISqlDataParameter parameters)
		{
			// This is not a factory because MySqlParameter is implemented in one of the MySql dlls
			return new MySqlParameter (parameters.ParamName, parameters.Value);
		}
	}
}

