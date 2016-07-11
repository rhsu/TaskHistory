using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Proxy responsible for communicating with the database including Reading and Writing to the Database
	/// </summary>
	public class ApplicationDataProxy
	{
		public IDataReaderProvider DataReaderProvider { get; }
		public SqlParameterFactory ParamFactory { get; }
		public INonQueryDataProvider NonQueryDataProvider { get; }
		
		public ApplicationDataProxy (IDataReaderProvider dataReaderProvider, 
			SqlParameterFactory paramFactory,
			NonQueryDataProvider nonQueryDataProvider)
		{
			DataReaderProvider = dataReaderProvider;
			ParamFactory = paramFactory;
			NonQueryDataProvider = nonQueryDataProvider;
		}
	}
}