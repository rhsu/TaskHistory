using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Configuration;
using TaskHistory.Impl.Sql;
using TaskHistory.Impl.Tasks;

namespace TestDB
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var config = new ConfigurationProvider();

			Console.WriteLine(config.SqlConnectionString);
		}
	}
}