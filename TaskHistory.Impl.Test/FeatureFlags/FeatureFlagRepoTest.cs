using NUnit.Framework;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Impl.FeatureFlags;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class FeatureFlagRepoTest
	{
		IFeatureFlagRepo _repo;
		TestFixtures _testFixtures;

		public FeatureFlagRepoTest()
		{
			var factory = new FeatureFlagFactory();
			var dataProxy = new ApplicationDataProxyFactory();

			_repo = new FeatureFlagRepo(factory, dataProxy);
			_testFixtures = new TestFixtures();
		}

		[Test]
		public void Create()
		{
			
		}
	}
}
