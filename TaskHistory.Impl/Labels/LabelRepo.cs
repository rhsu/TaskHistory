using System;
using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Labels
{
	public class LabelRepo : ILabelRepo
	{
		readonly LabelFactory _labelFactory;
		readonly ApplicationDataProxy _dataProxy;

		const string CreateStoredProcedure = "Labels_Insert";
		const string ReadStoredProcedure = "Labels_For_User_Select";
		const string UpdateStoredProcedure = "Labels_Update";
		const string DeleteStoredProcedure = "Labels_Logical_Delete";

		const string NullFromApplicationDataProxy = "Null returned from ApplicationDataProxy";

		public LabelFactory LabelFactory
		{
			get
			{
				return _labelFactory;
			}
		}

		public ILabel CreateNewLabel(string content)
		{
			var contentParameter = _dataProxy.CreateParameter("pContent", content);

			var returnVal = _dataProxy.ExecuteReaderForSingleType(LabelFactory, CreateStoredProcedure, contentParameter);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public IEnumerable<ILabel> ReadAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var userIdParam = _dataProxy.CreateParameter("pUserId", user.UserId);
			if (userIdParam == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			var returnVal = _dataProxy.ExecuteReaderForTypeCollection(LabelFactory, ReadStoredProcedure, userIdParam);
			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public void UpdateLabel(ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException(nameof(labelDto));

			var parameters = new List<ISqlDataParameter>();

			var contentParam = _dataProxy.CreateParameter("pContent", labelDto.Name);
			if (contentParam == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			var labelParam = _dataProxy.CreateParameter("pLabelId", labelDto.LabelId);
			if (labelParam == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			parameters.Add(contentParam);
			parameters.Add(labelParam);

			_dataProxy.ExecuteNonQuery(UpdateStoredProcedure, parameters);
		}

		public void DeleteLabel(int labelId)
		{
			var parameter = _dataProxy.CreateParameter("pLabelId", labelId);
			if (parameter == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			_dataProxy.ExecuteNonQuery(DeleteStoredProcedure, parameter);
		}

		public LabelRepo(LabelFactory labelFactory,
		                 ApplicationDataProxy dataProxy)
		{
			_dataProxy = dataProxy;
			_labelFactory = labelFactory;
		}
	}
}