using TaskHistory.Api.Configuration;
using System.Configuration;

namespace TaskHistory.Impl.Configuration
{
	public class ConfigurationProvider : IConfigurationProvider
	{
		readonly string _sqlConnectionString;

		public string SqlConnectionString
		{
			get { return _sqlConnectionString; }
		}

		public ConfigurationProvider()
		{
			_sqlConnectionString = ConfigurationManager.AppSettings["MySqlConnection"];
		}
	}
}