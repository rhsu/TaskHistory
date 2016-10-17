using NUnit.Framework;
using TaskHistory.Api.Terminal;
using TaskHistory.Impl.Terminal;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TerminalInterpreterHelperTest
	{
		[Test]
		public void ErrorEnum_If_NonsenseRegisteredObject()
		{
			var error = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("NONSENSE");
			Assert.AreEqual(TerminalRegisteredObject.Error, error);
		}

		[Test]
		public void DetermineTask_RegisteredObject_Test()
		{
			var taskEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("TASK");
			Assert.AreEqual(TerminalRegisteredObject.Task, taskEnum);
		}

		[Test]
		public void DetermineError_RegisteredObject_Test()
		{
			var errorEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("ERROR");
			Assert.AreEqual(TerminalRegisteredObject.Error, errorEnum);
		}

		[Test]
		public void DetermineLabel_RegisteredObject_Test()
		{
			var labelEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("LABEL");
			Assert.AreEqual(TerminalRegisteredObject.Label, labelEnum);
		}

		[Test]
		public void DetermineUser_RegisteredObject_Test()
		{
			var userEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("USER");
			Assert.AreEqual(TerminalRegisteredObject.User, userEnum);
		}

		[Test]
		public void DetermineList_CommandAction_Test()
		{
			var listEnum = TerminalInterpreterHelper.DetermineTerminalCommandAction("LIST");
			Assert.AreEqual(TerminalCommandAction.List, listEnum);
		}

		[Test]
		public void DetermineUpdate_CommandAction_Test()
		{
			var updateEnum = TerminalInterpreterHelper.DetermineTerminalCommandAction("UPDATE");
			Assert.AreEqual(TerminalCommandAction.Update, updateEnum);
		}

		[Test]
		public void DetermineDelete_CommandAction_Test()
		{
			var deleteEnum = TerminalInterpreterHelper.DetermineTerminalCommandAction("DELETE");
			Assert.AreEqual(TerminalCommandAction.Delete, deleteEnum);
		}

		[Test]
		public void DetermineError_CommandAction_Test()
		{
			var errorEnum = TerminalInterpreterHelper.DetermineTerminalCommandAction("ERROR");
			Assert.AreEqual(TerminalCommandAction.Error, errorEnum);
		}

		[Test]
		public void ErrorEnum_IfNonsenseCommandAction()
		{
			var errorEnum = TerminalInterpreterHelper.DetermineTerminalCommandAction("NONSENSE");
			Assert.AreEqual(TerminalCommandAction.Error, errorEnum);
		}
	}
}