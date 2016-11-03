using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	//TODO: I don't think I need this
	public interface IApplicationDataProxy
	{
		IDataReaderProvider DataReaderProvider { get; }
		ISqlParameterFactory ParamFactory { get; }
		INonQueryDataProvider NonQueryDataProvider { get; }
	}
}