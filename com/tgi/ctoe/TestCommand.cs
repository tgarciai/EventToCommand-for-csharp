using System;
using commands.com.tgi.ctoe;
namespace commands
{
	public class TestCommand : ICommand
	{
		public TestCommand()
		{
			Console.WriteLine("TestCommand");
		}

		public void execute(ICommandEvent @event)
		{
			Console.WriteLine("TestCommand execute");
			Console.WriteLine("@event type:" +@event.getEventType());
		}

	}
}
