using System;
using commands.com.tgi.ctoe;

namespace commands
{
    class Program
    {
        static void Main(string[] args)
        {
		EventToCommandMapper commandToEventMapper = new EventToCommandMapper();

		TestCommandA commandA = new TestCommandA();
            	TestCommandB commandB = new TestCommandB();
		commandToEventMapper.MapCommand(commandA,TestEventA.TYPE);
            	commandToEventMapper.MapCommand(commandB,TestEventB.TYPE);

		var evtA = new TestEventA(TestEventA.TYPE,"hello");
            	var evtB = new TestEventA(TestEventB.TYPE,"world");

		evtA.dispatch();
            	evtB.dispatch();

            	commandToEventMapper.RemoveCommand(commandA,TestEventA.TYPE);
            	commandToEventMapper.RemoveCommand(commandB,TestEventB.TYPE);
        }
    }
}
