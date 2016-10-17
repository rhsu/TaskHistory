using System;
using NUnit.Framework;
using TaskHistory.Api.Terminal;
using TaskHistory.Impl.Terminal;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TerminalInterpreterHelperTest
	{
		[Test]
		public void DetermineTerminalRegisteredObject_Test()
		{
			var taskEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("TASK");
			var errorEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("ERROR");
			var labelEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("LABELs");
			var userEnum = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("USER");

			Assert.AreEqual(TerminalRegisteredObject.Task, taskEnum);
			Assert.AreEqual(TerminalRegisteredObject.Error, errorEnum);
			Assert.AreEqual(TerminalRegisteredObject.Label, labelEnum);
			Assert.AreEqual(TerminalRegisteredObject.User, userEnum);
		}
	}
}
