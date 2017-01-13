namespace TaskHistory.Api.Sql
{
	/// <summary>
	/// Factory for Objects of Type T given a DataReaderFactory
	/// </summary>
	/// <typeparam name="T">The type that this factory should build<typeparam name="T"
	public interface IFromDataReaderFactory<T>
	{
		T CreateTypeFromDataReader(ISqlDataReader reader);
	}
}