namespace TaskHistory.ViewModel.FeatureFlags
{
	public class FeatureFlagTableViewModel
	{
		public int Id { get; }
		public string Name { get; }
		public string Value { get; }

		public FeatureFlagTableViewModel(int id, string name, string value)
		{
			Id = id;
			Name = name;
			Value = value;
		}
	}
}
