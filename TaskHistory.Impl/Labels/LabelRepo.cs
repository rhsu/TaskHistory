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
		private readonly ApplicationDataProxy _applicationDataProxy;

		private const string CreateStoredProcedure = "Labels_Insert";
		private const string ReadStoredProcedure = "Labels_For_User_Select";
		private const string UpdateStoredProcedure = "Labels_Update";
		private const string DeleteStoredProcedure = "Labels_Logical_Delete";

		private const string NullFromApplicationDataProxy = "Null returned from ApplicationDataProxy";

		public ILabel CreateNewLabel (string content)
		{
			var contentParameter = _applicationDataProxy.ParamFactory.CreateParameter ("pContent", content);

			var returnVal = _applicationDataProxy.DataReaderProvider.ExecuteReaderForSingleType (_labelFactory, CreateStoredProcedure, contentParameter);
			if (returnVal == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			return returnVal;
		}

		public IEnumerable<ILabel> ReadAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var userIdParam = _applicationDataProxy.ParamFactory.CreateParameter ("pUserId", user.UserId);
			if (userIdParam == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			var returnVal = _applicationDataProxy.DataReaderProvider.ExecuteReaderForTypeCollection (_labelFactory, ReadStoredProcedure, userIdParam);
			if (returnVal == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			return returnVal;
		}

		public void UpdateLabel (ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException ("labelDto");

			var parameters = new List<ISqlDataParameter> ();

			var contentParam = _applicationDataProxy.ParamFactory.CreateParameter("pContent", labelDto.Name);
			if (contentParam == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			var labelParam = _applicationDataProxy.ParamFactory.CreateParameter("pLabelId", labelDto.LabelId);
			if (labelParam == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			parameters.Add (contentParam);
			parameters.Add (labelParam);

			_applicationDataProxy.NonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);
		}

		public void DeleteLabel(int labelId)
		{
			var parameter = _applicationDataProxy.ParamFactory.CreateParameter ("pLabelId", labelId);
			if (parameter == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			_applicationDataProxy.NonQueryDataProvider.ExecuteNonQuery (DeleteStoredProcedure, parameter);
		}

		public LabelRepo (LabelFactory labelFactory, 
			ApplicationDataProxy applicationDataProxy)
		{
			_applicationDataProxy = applicationDataProxy;
			_labelFactory = labelFactory;
		}
	}
}