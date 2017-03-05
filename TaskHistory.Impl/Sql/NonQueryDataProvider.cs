using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Configuration;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Provider that communicates with a mysql database for nonqueries
	/// Consider using ApplicationDataProxy instead of using this class directly
	/// </summary>
	public class NonQueryDataProvider : BaseDataProvider, INonQueryDataProvider
	{
		readonly IConfigurationProvider _configurationProvider;

		public int Execute(string storedProcedureName)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException(nameof(storedProcedureName));

			return this.Execute(storedProcedureName, new List<ISqlDataParameter>());
		}

		public int Execute(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			return this.Execute(storedProcedureName, new List<ISqlDataParameter> { parameter });
		}

		public int Execute(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			using (var connection = new MySqlConnection(_configurationProvider.SqlConnectionString))
			using (var command = new MySqlCommand(storedProcedureName, connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				var mySqlParams = BaseDataProvider.CreateMySqlParametersFromSqlDataParams(parameters);
				if (mySqlParams == null)
					throw new NullReferenceException("Null returned from CreateMySqlParametersFromSqlDataParams in base class");

				foreach (var p in mySqlParams)
				{
					command.Parameters.Add(p);
				}

				command.Connection.Open();
				return command.ExecuteNonQuery();
			}
		}


		public NonQueryDataProvider(IConfigurationProvider configurationProvider)
		{
			_configurationProvider = configurationProvider;
		}
	}
}