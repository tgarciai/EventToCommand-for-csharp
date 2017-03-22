using System;
using commands.com.tgi.ctoe;
namespace commands
{
	public class TestCommandB : ICommand
	{
		public TestCommandB()
		{
			Console.WriteLine("TestCommandB");
		}

		public void execute(ICommandEvent @event)
		{
			Console.WriteLine("TestCommandB execute");
			Console.WriteLine("@event type:" +@event.getEventType());
			Console.WriteLine("@event data:" +@event.getEventData());

		}

	}
}
