namespace TaskHistory.Api.FeatureFlags
{
	public interface IFeatureFlag
	{
		int Id { get; }
		string Name { get; }
		string Value { get; }
	}
}