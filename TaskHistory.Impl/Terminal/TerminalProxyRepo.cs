using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Api.Terminal;
using System.Collections.Generic;
using TaskHistory.Api.Labels;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalProxyRepo : ITerminalProxyRepo
	{
		private readonly ITaskRepo _taskRepo;
		private readonly IUserRepo _userRepo;
		private readonly ILabelRepo _labelRepo;

		public void PerformActionForResponse(TerminalCommandResponse commandResponse)
		{
			if (commandResponse == null)
				throw new ArgumentNullException ("commandResponse");

			//switch (commandResponse.TerminalRequest) 
			//{

			/*case TerminalCommandAction.Delete:
			case TerminalCommandAction.Delete:
			case TerminalCommandAction.Delete:			
			case TerminalCommandAction.Delete:*/
			//}
		}

		public IEnumerable<ITerminalObject> ReadTerminalObjects(string magicString)
		{
			switch (magicString) 
			{
			case "user":
				// var things = _userRepo.ReadSomeUsers ();
				// convert things = list of ITerminalObject
			case "tasks":
				// var otherThings = _taskRepo.ReadSomeTasks ();
				// convert theseThings to list of ItermianlObjects
			default:
				break;
			}

			return new List<ITerminalObject>();
		}

		public TerminalProxyRepo (ITaskRepo taskRepo, IUserRepo userRepo, ILabelRepo labelRepo)
		{
			_taskRepo = taskRepo;
			_userRepo = userRepo;
			_labelRepo = labelRepo;
		}
	}
}