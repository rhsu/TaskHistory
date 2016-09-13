using System;

namespace TaskHistoryOrchestrator
{
	public class TerminalOrchestrator
	{
		public TerminalOrchestrator ()
		{
		}

		public string ProcessCommand(string command)
		{
			if (command == null || command == string.Empty) 
			{
				return "Invalid Command";
			}

			string[] parsedCommand = command.ToLower ().Trim().Split (' ');
			switch (parsedCommand[0]) 
			{
			case "insert":
				break;
			case "update":
				break;
			case "delete":
				break;
			}

			return "Response string";
		}
	}
}