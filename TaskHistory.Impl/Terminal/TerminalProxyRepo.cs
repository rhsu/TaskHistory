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

		// TODO Register the repos with an attribute
		// DetermineRepoToUse() function

		// TODO IUser should come from a context object
		public int PerformCreateOperation(TerminalCommandResponse2 commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (commandResponse.CommandAction != TerminalCommandAction.Insert)
				throw new InvalidOperationException ($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			switch (commandResponse.RegisteredObject) 
			{
			case TerminalRegisteredObject.Label:
				_registeredObjProxy.LabelRepo.CreateNewLabel ("some content from command response's option");
				break;
			case TerminalRegisteredObject.Task:
				_registeredObjProxy.TaskRepo.CreateNewTaskForUser(user, "some content from command response's object");
				break;
			}

			return 1;
		}

		public IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandResponse2 commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (commandResponse.CommandAction != TerminalCommandAction.List)
				throw new InvalidOperationException ($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			var returnVal = new List<ITerminalObject> ();

			//TODO refactor this switch statement into a function which transforms an enum + IUser into a collection of ITerminalObjects
			switch (commandResponse.RegisteredObject) 
			{
			case TerminalRegisteredObject.Label:
				var labels = _registeredObjProxy.LabelRepo.ReadAllLabelsForUser (user);
				var labelTerminalObjects = _terminalObjectMapper.ConvertLabels (labels);
				returnVal.AddRange (labelTerminalObjects);
				//TODO consider adding in an attribute onto Label to denote that field x is the Id and field y is the Value
				//TODO should that attribute be on ILabel or Label?

				break;
			case TerminalRegisteredObject.Task:
				var tasks = _registeredObjProxy.TaskRepo.ReadTasksForUser (user);
				var taskTerminalObjects = _terminalObjectMapper.ConvertTasks (tasks);
				returnVal.AddRange (taskTerminalObjects);

				break;
			}

			return returnVal;
		}

		public int PerformUpdateOperation(TerminalCommandResponse2 commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (commandResponse.CommandAction != TerminalCommandAction.Update)
				throw new InvalidOperationException ($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			switch (commandResponse.RegisteredObject) 
			{
			case TerminalRegisteredObject.Label:
				// Need to create a label from commandReponse's 
				_registeredObjProxy.LabelRepo.UpdateLabel (null);
				break;
			case TerminalRegisteredObject.Task:
				// need to create task updating parameters
				_registeredObjProxy.TaskRepo.UpdateTask (null);
				break;
			}

			return -1;
		}

		public int PerformDeleteOperation(TerminalCommandResponse2 commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (commandResponse.CommandAction != TerminalCommandAction.Delete)
				throw new InvalidOperationException ($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			return -1;
		}

		public TerminalProxyRepo(IRegisteredObjectRepoProxy objProxy, ITerminalObjectMapper objMapper)
		{
			_registeredObjProxy = objProxy;
			_terminalObjectMapper = objMapper;
		}
	}
}

	/*public class TerminalProxyRepo : ITerminalProxyRepo
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
				var labelRepo = _registeredObjProxy.LabelRepo;
				labelRepo.CreateNewLabel(

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
}*/