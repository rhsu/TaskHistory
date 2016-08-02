using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Proxy responsible for communicating with the database including Reading and Writing to the Database
	/// </summary>
	public class ApplicationDataProxy : IApplicationDataProxy
	{
		public IDataReaderProvider DataReaderProvider { get; }
		public ISqlParameterFactory ParamFactory { get; }
		public INonQueryDataProvider NonQueryDataProvider { get; }
		
		public ApplicationDataProxy (IDataReaderProvider dataReaderProvider, 
			ISqlParameterFactory paramFactory,
			NonQueryDataProvider nonQueryDataProvider)
		{
			DataReaderProvider = dataReaderProvider;
			ParamFactory = paramFactory;
			NonQueryDataProvider = nonQueryDataProvider;
		}
	}
}