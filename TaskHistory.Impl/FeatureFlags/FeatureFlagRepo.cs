using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.FeatureFlags
{
	public class FeatureFlagRepo : IFeatureFlagRepo
	{
		ApplicationDataProxy _dataProxy;
		FeatureFlagFactory _factory;

		const string CreateStoredProcedure = "";
		const string ReadStoredProcedure = "";
		const string UpdatedStoredProcedure = "";		
		const string DeleteStoredProcedure = "";

		public IFeatureFlag Create()
		{
			throw new NotImplementedException();
		}

		public IFeatureFlag Delete()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IFeatureFlag> Read()
		{
			throw new NotImplementedException();
		}

		public IFeatureFlag Update()
		{
			throw new NotImplementedException();
		}

		public FeatureFlagRepo(FeatureFlagFactory factory,
		                       ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}
	}
}