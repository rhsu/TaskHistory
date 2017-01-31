using NUnit.Framework;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Impl.FeatureFlags;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class FeatureFlagRepoTest
	{
		IFeatureFlagRepo _repo;

		public FeatureFlagRepoTest()
		{
			var factory = new FeatureFlagFactory();
			var dataProxy = new ApplicationDataProxyFactory().Build();

			_repo = new FeatureFlagRepo(factory, dataProxy);
		}

		[Test]
		public void Create()
		{
			var name = "Feature Flag Name";
			var value = "this is a value";
			IFeatureFlag feature = _repo.Create(name,
												value);

			Assert.AreEqual(name, feature.Name);
			Assert.AreEqual(value, feature.Value);	                                    
		}

		[Test]
		public void Read()
		{
			// TODO can't test this until I have the ability
			//      to delete all feature flags
			/*for (var i = 0; i < 5; i++)
			{
				
			}*/
		}

		[Test]
		public void Delete()
		{
			var name = "Feature Flag Name";
			var value = "this is a value";

			IFeatureFlag feature = _repo.Create(name,
												value);

			int numDeleted = _repo.Delete(feature.Id);

			Assert.AreEqual(1, numDeleted);
		}
	}
}
