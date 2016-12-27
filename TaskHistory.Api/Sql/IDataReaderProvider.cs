using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	/// <summary>
	/// Provider for Reading Data From a SQL database
	/// </summary>
	public interface IDataReaderProvider
	{
		/// <summary>
		/// Executes a data reader, reading only 1 type
		/// </summary>
		/// <returns>The reader for single type.</returns>
		/// <param name="factory">Factory.</param>
		/// <param name="storedProcedureName">Stored procedure name.</param>
		/// <param name="parameter">Parameter.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter);

		T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName, 
			IEnumerable<ISqlDataParameter> parameters);

		IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter);

		IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters);
	}
}