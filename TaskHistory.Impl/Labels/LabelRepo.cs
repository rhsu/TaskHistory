using System;
using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Users;
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

		private const string NullFromParamFactory = "Null returned from SqlParameterFactory";
		private const string NullFromDataProvider = "Null returned from DataProvider";

		public ILabel CreateNewLabel (string content)
		{
			var contentParameter = _paramFactory.CreateParameter ("pContent", content);

			var returnVal = _dataLayer.ExecuteReaderForSingleType (_labelFactory, CreateStoredProcedure, contentParameter);
			if (returnVal == null)
				throw new NullReferenceException (NullFromDataProvider);

			return returnVal;
		}

		public IEnumerable<ILabel> ReadAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var userIdParam = _paramFactory.CreateParameter ("pUserId", user.UserId);
			if (userIdParam == null)
				throw new NullReferenceException (NullFromParamFactory);

			var returnVal = _dataLayer.ExecuteReaderForTypeCollection (_labelFactory, ReadStoredProcedure, userIdParam);
			if (returnVal == null)
				throw new NullReferenceException (NullFromDataProvider);

			return returnVal;
		}

		public void UpdateLabel (ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException ("labelDto");

			var parameters = new List<ISqlDataParameter> ();

			var contentParam = _paramFactory.CreateParameter("pContent", labelDto.Name);
			if (contentParam == null)
				throw new NullReferenceException (NullFromParamFactory);

			var labelParam = _paramFactory.CreateParameter("pLabelId", labelDto.LabelId);
			if (labelParam == null)
				throw new NullReferenceException (NullFromParamFactory);

			parameters.Add (contentParam);
			parameters.Add (labelParam);

			_nonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);
		}

		public void DeleteLabel(int labelId)
		{
			var parameter = _paramFactory.CreateParameter ("pLabelId", labelId);
			if (parameter == null)
				throw new NullReferenceException (NullFromParamFactory);

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