using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
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