using System.Collections.Generic;

namespace TaskHistory.Api.FeatureFlags
{
	public interface IFeatureFlagRepo
	{
		IFeatureFlag Create(string name, string value);

		IFeatureFlag Read(string key);

		IEnumerable<IFeatureFlag> ReadAll();

		IFeatureFlag Update(int id, string name, string value);

		int Delete(int id);
	}
}
