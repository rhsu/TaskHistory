using System;
using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Users;
using TaskHistory.Impl.MySql;
using MySql.Data.MySqlClient;
using System.Data;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Labels
{
	public class LabelRepo : ILabelRepo
	{
		private readonly LabelFactory _labelFactory;
		private readonly SqlParameterFactory _paramFactory;
		private readonly IDataLayer _dataLayer;
		private readonly INonQueryDataProvider _nonQueryDataProvider;

		private const string CreateStoredProcedure = "Labels_Insert";
		private const string ReadStoredProcedure = "Labels_For_User_Select";
		private const string UpdateStoredProcedure = "Labels_Update";
		private const string DeleteStoredProcedure = "Labels_Logical_Delete";

		public ILabel CreateNewLabel (string content)
		{
			var contentParameter = _paramFactory.CreateParameter ("pContent", content);

			var returnVal = _dataLayer.ExecuteReaderForSingleType (_labelFactory, CreateStoredProcedure, contentParameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from data layer");

			return returnVal;
		}

		public IEnumerable<ILabel> ReadAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var userIdParam = _paramFactory.CreateParameter ("pUserId", user.UserId);

			var returnVal = _dataLayer.ExecuteReaderForTypeCollection (_labelFactory, ReadStoredProcedure, userIdParam);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from data layer");

			return returnVal;
		}

		public void UpdateLabel (ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException ("labelDto");

			var parameters = new List<ISqlDataParameter> ();

			parameters.Add (_paramFactory.CreateParameter ("pContent", labelDto.Name));
			parameters.Add (_paramFactory.CreateParameter ("pLabelId", labelDto.LabelId));

			_nonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);
		}

		public void DeleteLabel(int labelId)
		{
			var parameter = _paramFactory.CreateParameter ("pLabelId", labelId);
			_nonQueryDataProvider.ExecuteNonQuery (DeleteStoredProcedure, parameter);
		}

		public LabelRepo (LabelFactory labelFactory, IDataLayer dataLayer, INonQueryDataProvider nonQueryDataProvider)
		{
			_labelFactory = labelFactory;
			_dataLayer = dataLayer;
			_nonQueryDataProvider = nonQueryDataProvider;
		}
	}
}