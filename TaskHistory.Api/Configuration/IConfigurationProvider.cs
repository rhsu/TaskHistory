namespace TaskHistory.Api.Configuration
{
	public interface IConfigurationProvider
	{
		string SqlConnectionString { get; }
	}
}