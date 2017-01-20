using TaskHistory.Api.FeatureFlags;

namespace TaskHistory.Impl.FeatureFlags
{
	public class FeatureFlag : IFeatureFlag
	{
		public int Id { get; }
		public string Name { get; }
		public string Value { get; }

		public FeatureFlag(int id, string name, string value)
		{
			Id = id;
			Name = name;
			Value = value;
		}
	}
}
