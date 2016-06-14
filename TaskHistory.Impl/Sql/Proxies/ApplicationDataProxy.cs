using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.Sql
{
	// RH [TODO] Wrap DataReaderProvider, NonQueryDataProvider, and ParamFactory together since they are always used together
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