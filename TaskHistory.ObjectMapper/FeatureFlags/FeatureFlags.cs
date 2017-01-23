using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.ViewModel;

namespace TaskHistory.ObjectMapper.FeatureFlags
{
	public class FeatureFlags
	{
		public IEnumerable<FeatureFlagTableViewModel> Map(IEnumerable<IFeatureFlag> featureFlags)
		{
			if (featureFlags == null)
				throw new ArgumentNullException(nameof(featureFlags));

			return null;
		}
	}
}
