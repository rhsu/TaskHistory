namespace TaskHistory.ViewModel.FeatureFlags
{
	public class FeatureFlagTableViewModel
	{
		public int Id { get; }
		public string Name { get; }
		public string Value { get; }

		/*
		 * The existence of a view model of this specificity is in case
		 * I wanted to do something like:
		 * 	CreateAt
		 * And Edit wouldn't care about that property
		 */

		public FeatureFlagTableViewModel(int id, string name, string value)
		{
			Id = id;
			Name = name;
			Value = value;
		}
	}
}
