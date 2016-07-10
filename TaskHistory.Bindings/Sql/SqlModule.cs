using System;
using Ninject;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Bindings
{
	public class SqlModule : IModule
	{
		public SqlModule ()
		{
		}

		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			kernel.Bind<IDataReaderProvider> ()
				  .To<DataReaderProvider> ();

			kernel.Bind<INonQueryDataProvider> ()
				  .To<NonQueryDataProvider> ();
		}
	}
}