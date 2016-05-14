using System;
using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Users;
using TaskHistory.Impl.MySql;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace TaskHistory.Impl.Labels
{
	public class LabelRepo : ILabelRepo
	{
		private readonly LabelFactory _labelFactory;

		private const string CreateStoredProcedure = "Labels_Insert";
		private const string ReadStoredProcedure = "Labels_For_User_Select";
		private const string UpdateStoredProcedure = "Labels_Update";
		private const string DeleteStoredProcedure = "Labels_Logical_Delete";

		public ILabel CreateNewLabel (string content)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (CreateStoredProcedure, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new MySqlParameter("pContent", content));
				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);
				ILabel label = null;

				if (reader.Read ()) 
				{
					label = MakeLabelFromReader (reader);
				}
				return label;
			}
		}

		public IEnumerable<ILabel> ReadAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var returnVal = new List<ILabel> ();

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (ReadStoredProcedure, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

				while (reader.Read ()) 
				{
					ILabel label = MakeLabelFromReader (reader);
					returnVal.Add (label);
				}
			}
				
			return returnVal;
		}

		public void UpdateLabel (ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException ("labelDto");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (UpdateStoredProcedure, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pContent", labelDto.Name));
				command.Parameters.Add (new MySqlParameter ("pLabelId", labelDto.LabelId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
				command.Connection.Close ();
			}
		}

		public void DeleteLabel(int labelId)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (DeleteStoredProcedure, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pLabelId", labelId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
				command.Connection.Close ();
			}
		}

		private ILabel MakeLabelFromReader(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			int labelId = Convert.ToInt32 (reader ["labelId"]);
			string name = reader ["name"].ToString ();
			ILabel label = _labelFactory.CreateLabel (labelId, name);

			return label;
		}

		public LabelRepo (LabelFactory labelFactory)
		{
			_labelFactory = labelFactory;
		}
	}
}