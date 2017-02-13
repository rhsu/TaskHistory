using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.ViewModel.FeatureFlags;

namespace TaskHistory.ObjectMapper.FeatureFlags
{
	public class FeatureFlagObjectMapper
	{
		public IEnumerable<FeatureFlagTableViewModel> Map(IEnumerable<IFeatureFlag> featureFlags)
		{
			if (featureFlags == null)
				throw new ArgumentNullException(nameof(featureFlags));

			var viewModels = new List<FeatureFlagTableViewModel>();

			foreach (var flag in featureFlags)
			{
				var viewModel = this.Map(flag);
				if (viewModel == null)
					throw new NullReferenceException("Null returned from ObjectMapper");

				viewModels.Add(viewModel);
			}

			return viewModels;
		}

		public FeatureFlagTableViewModel Map(IFeatureFlag featureFlag)
		{
			if (featureFlag == null)
				throw new ArgumentNullException(nameof(featureFlag));

			var viewModel = new FeatureFlagTableViewModel(featureFlag.Id,
													   featureFlag.Name,
													   featureFlag.Value);

			return viewModel;
		}
	}
}
