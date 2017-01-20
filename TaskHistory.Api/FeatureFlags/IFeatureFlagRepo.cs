using System.Collections.Generic;

namespace TaskHistory.Api.FeatureFlags
{
	public interface IFeatureFlagRepo
	{
		IFeatureFlag Create();

		IEnumerable<IFeatureFlag> Read();

		IFeatureFlag Update();

		IFeatureFlag Delete();
	}
}
