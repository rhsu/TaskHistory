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
		public void DetermineUserEnum_Test()
		{
			var userEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("USER");
			Assert.AreEqual(TerminalRegisteredObject.User, userEnum);
		}

		[Test]
		public void DetermineListEnum_Test()
		{
		}

		[Test]
		public void DetermineUpdateEnum_Test()
		{
		}

		[Test]
		public void DetermineDeleteEnum_Test()
		{
		}

		public void DetermineErrorEnum_Test()
		{
		}
	}
}