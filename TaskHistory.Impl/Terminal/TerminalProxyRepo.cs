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
		private readonly IRegisteredObjectRepoProxy _registeredObjProxy;
		private readonly ITerminalObjectMapper _terminalObjectMapper;

		public int PerformCreateOperation(TerminalCommandOption commandOption, 
			TerminalRegisteredObject registeredObject, 
			IUser user)
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

		public IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandOption commandOption, 
			TerminalRegisteredObject registeredObject, 
			IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (registeredObject == TerminalRegisteredObject.Error)
				throw new ArgumentOutOfRangeException ("registeredObject", "The registered object is of type Error");

			var returnVal = new List<ITerminalObject> ();

			//TODO refactor this switch statement into a function which transofmrs an enum + IUser into a collection of ITerminalObjects
			switch (registeredObject) 
			{
			case TerminalRegisteredObject.Label:
				var labels = _registeredObjProxy.LabelRepo.ReadAllLabelsForUser (user);

				//TODO consider adding in an attribute onto Label to denote that field x is the Id and field y is the Value
				//TODO should that attribute be on ILabel or Label?

				break;
			case TerminalRegisteredObject.Task:
				var tasks = _registeredObjProxy.TaskRepo.ReadTasksForUser (user);

				break;
			}

			return returnVal;
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

		public TerminalProxyRepo (IRegisteredObjectRepoProxy registeredObjectRepoProxy,
			ITerminalObjectMapper terminalObjectMapper)
		{
			_registeredObjProxy = registeredObjectRepoProxy;
			_terminalObjectMapper = terminalObjectMapper;
		}
	}
}