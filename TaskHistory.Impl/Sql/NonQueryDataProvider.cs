using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using TaskHistory.Api.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Provider that communicates with a mysql database for nonqueries
	/// Consider using ApplicationDataProxy instead of using this class directly
	/// </summary>
	public class NonQueryDataProvider : BaseDataProvider, INonQueryDataProvider
	{
		private readonly IConfigurationProvider _configurationProvider;

		public void Execute(string storedProcedureName)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException(nameof(storedProcedureName));

			this.Execute(storedProcedureName, new List<ISqlDataParameter>());
		}

		public void Execute(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			this.Execute(storedProcedureName, new List<ISqlDataParameter> { parameter });
		}

		public void Execute(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters)
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
				command.ExecuteNonQuery();
			}
		}

		public NonQueryDataProvider(IConfigurationProvider configurationProvider)
		{
			_configurationProvider = configurationProvider;
		}
	}
}