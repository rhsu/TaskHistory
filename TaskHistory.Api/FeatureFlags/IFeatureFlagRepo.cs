using System.Collections.Generic;

namespace TaskHistory.Api.FeatureFlags
{
	public interface IFeatureFlagRepo
	{
		IFeatureFlag Create(string name, string value);

		IEnumerable<IFeatureFlag> Read();

		IFeatureFlag Update(string name, string value);

		int Delete(int id);
	}
}
