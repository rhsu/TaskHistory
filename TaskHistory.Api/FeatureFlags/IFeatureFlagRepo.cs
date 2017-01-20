using System.Collections.Generic;

namespace TaskHistory.Api.FeatureFlags
{
	public interface IFeatureFlagRepo
	{
		IFeatureFlag Create(int userId, string name, string value);

		IEnumerable<IFeatureFlag> Read(int userId);

		IFeatureFlag Update(int userId, string name, string value);

		IFeatureFlag Delete(int userId, int id);
	}
}
