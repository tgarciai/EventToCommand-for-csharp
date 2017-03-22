using System;
using commands.com.tgi.ctoe;
namespace commands
{
	public class TestCommandA : ICommand
	{
		public TestCommandA()
		{
			Console.WriteLine("TestCommandA");
		}

		public void execute(ICommandEvent @event)
		{
			Console.WriteLine("TestCommandA execute");
			Console.WriteLine("@event type:" +@event.getEventType());
			Console.WriteLine("@event data:" +@event.getEventData());

		}

	}
}
