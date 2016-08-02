using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public interface IApplicationDataProxy
	{
		IDataReaderProvider DataReaderProvider { get; }
		ISqlParameterFactory ParamFactory { get; }
		INonQueryDataProvider NonQueryDataProvider { get; }
	}
}