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

		IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (registeredObject == TerminalRegisteredObject.Error)
				throw new ArgumentOutOfRangeException ("registeredObject", "The registered object is of type Error");

			//TODO refactor this switch statement into a function which transofmrs an enum + IUser into a collection of ITerminalObjects
			switch (registeredObject) 
			{
			case TerminalRegisteredObject.Label:
				var labels = _labelRepo.ReadAllLabelsForUser (user);
				//TODO some service that converts label to ITerminalObject
				//TODO consider adding in an attribute onto Label to denote that field x is the Id and field y is the Value
				//TODO should that attribute be on ILabel or Label?

				break;
			case TerminalRegisteredObject.Task:
				var tasks = _taskRepo.ReadTasksForUser (user);

				break;
			}

			var returnVal = new List<ITerminalObject> ();
			return returnVal;
		}

		public int PerformInsertOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (registeredObject == TerminalRegisteredObject.Error)
				throw new ArgumentOutOfRangeException ("registeredObject", "The registered object is of type Error");
			
			switch (registeredObject) 
			{
			case TerminalRegisteredObject.Label:
				//_labelRepo.UpdateLabel(someId)
				//TODO permissions. For now we can just ensure that the stored procedure deletes based off of a where clause looking up UserId
				//TODO need to pass in Id
				break;
			case TerminalRegisteredObject.Task:
				

				break;
			}

			return -1;
		}

		int PerformUpdateOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject)
		{
			if (registeredObject == TerminalRegisteredObject.Error)
				throw new ArgumentOutOfRangeException ("registeredObject", "The registered object is of type Error");

			return -1;
		}

		int PerformDeleteOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject)
		{
			if (registeredObject == TerminalRegisteredObject.Error)
				throw new ArgumentOutOfRangeException ("registeredObject", "The registered object is of type Error");

			return -1;
		}

		public TerminalProxyRepo (ITaskRepo taskRepo, IUserRepo userRepo, ILabelRepo labelRepo)
		{
			_taskRepo = taskRepo;
			_userRepo = userRepo;
			_labelRepo = labelRepo;
		}
	}
}