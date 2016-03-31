using System;
using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Users;
using TaskHistory.Impl.MySql;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistory.Impl.Labels
{
	public class LabelRepo : AbstractMySqlRepo, ILabelRepo
	{
		private readonly LabelFactory _labelFactory;

		public IEnumerable<ILabel> GetAllLabelsForUser(IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var returnVal = new List<ILabel> ();

			var command = _mySqlCommandFactory.CreateMySqlCommand ("Labels_ForUser_Select");
			command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
			command.Connection.Open ();

			MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

			while (reader.Read ()) 
			{
				ILabel label = CreateLabelFromReader (reader);
				returnVal.Add (label);
			}

			command.Connection.Close ();
			
			return returnVal;
		}

		public ILabel InsertNewLabel (string content)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Labels_Insert");
			command.Parameters.Add(new MySqlParameter("pContent", content));
			command.Connection.Open ();

			MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);
			ILabel label = null;

			if (reader.Read ()) 
			{
				label = CreateLabelFromReader (reader);
			}

			command.Connection.Close ();

			return label;
		}

		public void DeleteLabel(int labelId)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Logical_Delete");
			command.Parameters.Add (new MySqlParameter ("pLabelId", labelId));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
		}

		public void UpdateLabel (ILabel labelDto)
		{
			if (labelDto == null)
				throw new ArgumentNullException ("labelDto");

			var command = _mySqlCommandFactory.CreateMySqlCommand ("Labels_Update");
			command.Parameters.Add (new MySqlParameter ("pContent", labelDto.Name));
			command.Parameters.Add (new MySqlParameter ("pLabelId", labelDto.LabelId));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
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

		public LabelRepo (LabelFactory labelFactory, MySqlCommandFactory commandFactory)
			: base (commandFactory)
		{
			_labelFactory = labelFactory;
		}
	}
}

