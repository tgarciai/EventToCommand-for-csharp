using System;
using commands.com.tgi.ctoe;

namespace commands
{
    class Program
    {
        static void Main(string[] args)
        {
         
			EventToCommandMapper commandToEventMapper = new EventToCommandMapper();

			TestCommand command = new TestCommand();
			commandToEventMapper.MapCommand(command,"aaa");


			var evento = new CommandEvent("aaa");
			evento.dispatch();


            var evento1 = new CommandEvent("aaa");
			evento1.dispatch();


            commandToEventMapper.RemoveCommand(command,"aaa");

            evento.dispatch();

			Console.WriteLine("Hello World!");




        }
    }
}
