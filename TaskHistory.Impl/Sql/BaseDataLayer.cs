using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public abstract class BaseDataLayer
	{
		public BaseDataLayer ()
		{
		}

		protected static List<MySqlParameter> CreateMySqlParametersFromSqlDataParams(IEnumerable<ISqlDataParameter> parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			var returnVal = new List<MySqlParameter> ();

			foreach (var p in parameters) 
			{
				returnVal.Add(CreateSqlParameterFromSqlDataParams(p));
			}

			return returnVal;
		}

		protected static MySqlParameter CreateSqlParameterFromSqlDataParams(ISqlDataParameter parameters)
		{
			// This is not a factory because MySqlParameter is implemented in one of the MySql dlls
			return new MySqlParameter (parameters.ParamName, parameters.Value);
		}

		protected static void CheckParameters<T>(IFromDataReaderFactory<T> factory,
			IEnumerable<ISqlDataParameter> parameters,
			string storedProcedureName)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			if (storedProcedureName == string.Empty || storedProcedureName == null)
				throw new ArgumentNullException ("storedProcedureName");
		}

		protected static void CheckParameters<T>(IFromDataReaderFactory<T> factory, 
			ISqlDataParameter parameter, 
			string storedProcedureName)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if (parameter == null)
				throw new ArgumentNullException ("parameters");

			if (storedProcedureName == string.Empty || storedProcedureName == null)
				throw new ArgumentNullException ("storedProcedureName");
		}
	}
}

