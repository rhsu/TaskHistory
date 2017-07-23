using TaskHistory.Impl.Configuration;
using TaskHistory.Impl.Sql;

namespace TaskHistory.TestFramework
{
	// TODO: Do I want to Keep this or replace this with
	//       a  DI container?
	public class ApplicationDataProxyFactory
	{
		public ApplicationDataProxy Build()
		{
			var sqlDataReaderFactory = new SqlDataReaderFactory();
			var configurationProvider = new ConfigurationProvider();

			var dataReaderProvider = new DataReaderProvider(sqlDataReaderFactory, configurationProvider);
			var paramFactory = new SqlParameterFactory();
			var nonQueryDataProvider = new NonQueryDataProvider(configurationProvider); 

			return new ApplicationDataProxy(dataReaderProvider, paramFactory, nonQueryDataProvider);
		}
	}
}
