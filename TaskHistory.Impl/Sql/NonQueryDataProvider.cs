using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using TaskHistory.Api.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistory.Impl.Sql
{
	public class NonQueryDataProvider : BaseDataProvider, INonQueryDataProvider
	{
		private readonly IConfigurationProvider _configurationProvider;

		public void ExecuteNonQuery (string storedProcedureName)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException ("storedProcedureName");

			this.ExecuteNonQuery(storedProcedureName, new List<ISqlDataParameter>());
		}

		public void ExecuteNonQuery(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException ("storedProcedureName");

			if (parameter == null)
				throw new ArgumentNullException ("parameter");

			this.ExecuteNonQuery (storedProcedureName, new List<ISqlDataParameter> { parameter });
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

				var mySqlParams = BaseDataProvider.CreateMySqlParametersFromSqlDataParams (parameters);

				foreach (var p in mySqlParams) 
				{
					command.Parameters.Add (p);
				}

				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}
		}

		public NonQueryDataProvider (IConfigurationProvider configurationProvider) :
			base()
		{
			_configurationProvider = configurationProvider;
		}
	}
}