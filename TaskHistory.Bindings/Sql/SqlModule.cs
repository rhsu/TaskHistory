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

			kernel.Bind<IDataLayer> ()
				  .To<DataLayer> ();

			kernel.Bind<INonQueryDataProvider> ()
				  .To<NonQueryDataProvider> ();

			/*kernel.Bind<ISqlDataParameter> ()
				  .To<SqlDataParameter> ();

			kernel.Bind<ISqlDataReader> ()
				  .To<SqlDataReader> ();*/
		}
	}
}