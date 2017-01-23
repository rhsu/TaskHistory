using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.ObjectMapper.FeatureFlags;
using TaskHistory.ViewModel.FeatureFlags;

namespace TaskHistory.Orchestrator
{
	public class FeatureFlagsOrchestrator
	{
		readonly IFeatureFlagRepo _repo;
		readonly FeatureFlagObjectMapper _mapper;

		public FeatureFlagsOrchestrator(IFeatureFlagRepo repo,
		                                FeatureFlagObjectMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public IEnumerable<FeatureFlagTableViewModel> GetFlags()
		{
			var flags = _repo.Read();
			if (flags == null)
				throw new NullReferenceException("Null returned from repo");

			var retVal = _mapper.Map(flags);
			if (retVal == null)
				throw new NullReferenceException("Null returned from mapper");

			return retVal;
		}

		public bool Delete(int featureFlagId)
		{
			var isSuccessful = _repo.Delete(featureFlagId);

			return isSuccessful == 1;
		}

		public IFeatureFlag Update(FeatureFlagEditViewModel vmFeatureFlag)
		{
			if (vmFeatureFlag == null)
				throw new ArgumentNullException(nameof(vmFeatureFlag));

			return null;
		}
	}
}
