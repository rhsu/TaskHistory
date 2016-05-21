using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using TaskHistory.Api.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistory.Impl.Sql
{
	public class DataNonQueryProvider : IDataNonQueryProvider
	{
		private readonly IConfigurationProvider _configurationProvider;

		public void ExecuteNonQuery (string storedProcedureName)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException ("storedProcedureName");
		}

		public void ExecuteNonQuery(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException ("storedProcedureName");

			if (parameter == null)
				throw new ArgumentNullException ("parameter");
		}

		public void ExecuteNonQuery(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException ("storedProcedureName");

			if (parameters == null)
				throw new ArgumentNullException ("parameter");

			using (var connection = new MySqlConnection (_configurationProvider.SqlConnectionString))
			using (var command = new MySqlCommand (storedProcedureName)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				// command.Parameters.Add (new MySqlParameter ("pTaskId", taskId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}
		}

		public DataNonQueryProvider (IConfigurationProvider configurationProvider)
		{
			_configurationProvider = configurationProvider;
		}
	}
}