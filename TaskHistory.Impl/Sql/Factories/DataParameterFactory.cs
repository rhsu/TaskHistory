using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class DataParameterFactory
	{
		public ISqlDataParameter CreateDataParemeter(string name, object value)
		{
			//TODO How do contracts works?
			//Contract.Ensures(Contract.Result<ISqlDataParameter>() != null);

			return new DataParameter(name, value);
		}
	}
}