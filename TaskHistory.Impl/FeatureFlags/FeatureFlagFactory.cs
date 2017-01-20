using System;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.FeatureFlags
{
	public class FeatureFlagFactory : IFromDataReaderFactory<IFeatureFlag>
	{
		public IFeatureFlag Build(ISqlDataReader reader)
		{
			throw new NotImplementedException();
		}
	}
}
