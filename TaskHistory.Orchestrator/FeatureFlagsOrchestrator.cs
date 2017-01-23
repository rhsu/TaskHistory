using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.ViewModel.FeatureFlags;

namespace TaskHistory.Orchestrator
{
	public class FeatureFlagsOrchestrator
	{
		readonly IFeatureFlagRepo _repo;

		public FeatureFlagsOrchestrator(IFeatureFlagRepo repo)
		{
			_repo = repo;
		}

		public IEnumerable<IFeatureFlag> GetFlags()
		{
			var returnVal = _repo.Read();
			if (returnVal == null)
				throw new NullReferenceException("Null returned from repo");

			return returnVal;
		}

		public bool Delete(int featureFlagId)
		{
			var isSuccessful = _repo.Delete(featureFlagId);

			return isSuccessful == 1;
		}

		public IFeatureFlag Update(FeaturFlagEditViewModel vmFeatureFlag)
		{
			if (vmFeatureFlag == null)
				throw new ArgumentNullException(nameof(vmFeatureFlag));

			return null;
		}
	}
}
