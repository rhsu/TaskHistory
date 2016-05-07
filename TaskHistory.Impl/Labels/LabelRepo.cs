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

		public IEnumerable<ILabel> GetAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var returnVal = new List<ILabel> ();

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand ("Labels_Get", connection)) 
			{
				command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

				while (reader.Read ()) 
				{
					ILabel label = CreateLabelFromReader (reader);
					returnVal.Add (label);
				}
			}
				
			return returnVal;
		}

		public ILabel InsertNewLabel (string content)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand ("Labels_Insert", connection)) 
			{
				command.Parameters.Add(new MySqlParameter("pContent", content));
				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);
				ILabel label = null;

				if (reader.Read ()) 
				{
					label = CreateLabelFromReader (reader);
				}
				return label;
			}
		}

		public void DeleteLabel(int labelId)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand ("Logical_Delete", connection)) 
			{
				command.Parameters.Add (new MySqlParameter ("pLabelId", labelId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
				command.Connection.Close ();
			}
		}

		public void UpdateLabel (ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException ("labelDto");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand ("Label_Update", connection)) 
			{
				command.Parameters.Add (new MySqlParameter ("pContent", labelDto.Name));
				command.Parameters.Add (new MySqlParameter ("pLabelId", labelDto.LabelId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
				command.Connection.Close ();
			}
		}

		private ILabel CreateLabelFromReader(MySqlDataReader reader)
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

