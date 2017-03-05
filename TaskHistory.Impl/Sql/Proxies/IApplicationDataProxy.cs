using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	//TODO: I don't think I need this... oh wait I do becaues of unit testing damn.. need to revisit
	public interface IApplicationDataProxy
	{
		IDataReaderProvider DataReaderProvider { get; }
		ISqlParameterFactory ParamFactory { get; }
		INonQueryDataProvider NonQueryDataProvider { get; }
	}
}