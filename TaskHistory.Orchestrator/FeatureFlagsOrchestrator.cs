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

		public IFeatureFlag Create(FeatureFlagCreateViewModel vmFeatureFlag)
		{
			if (vmFeatureFlag == null)
				throw new ArgumentNullException(nameof(vmFeatureFlag));

			var retVal = _repo.Create(vmFeatureFlag.Name, vmFeatureFlag.Value);
			if (retVal == null)
				throw new NullReferenceException("null returned from Repo");

			return retVal;
		}

		public IEnumerable<FeatureFlagTableViewModel> Read()
		{
			var flags = _repo.Read();
			if (flags == null)
				throw new NullReferenceException("null returned from Repo");

			var retVal = _mapper.Map(flags);
			if (retVal == null)
				throw new NullReferenceException("null returned from ObjectMapper");

			return retVal;
		}

		public IFeatureFlag Update(FeatureFlagEditViewModel vmFeatureFlag)
		{
			if (vmFeatureFlag == null)
				throw new ArgumentNullException(nameof(vmFeatureFlag));

			var retVal = _repo.Update(vmFeatureFlag.Id,
									  vmFeatureFlag.Name,
									  vmFeatureFlag.Value);
			if (retVal == null)
				throw new NullReferenceException("null returned from Repo");

			return retVal;
		}

		public bool Delete(int featureFlagId)
		{
			var isSuccessful = _repo.Delete(featureFlagId);

			return isSuccessful == 1;
		}
	}
}
