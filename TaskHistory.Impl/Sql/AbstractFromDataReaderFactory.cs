﻿using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public abstract class AbstractFromDataReaderFactory<T> : IFromDataReaderFactory<T>
	{
		private readonly SqlDataReaderFactory _dataReaderFactory;

		public abstract T CreateTypeFromDataReader(ISqlDataReader reader);

		public AbstractFromDataReaderFactory (SqlDataReaderFactory dataReaderFactory)
		{
			_dataReaderFactory = dataReaderFactory;
		}
	}
}

