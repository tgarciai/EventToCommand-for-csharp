using System;
using System.Collections.Generic;
namespace commands.com.tgi.ctoe
{
	public class EventToCommandMapper
	{
		private Dictionary<string, ICommand> commands;
		
		public EventToCommandMapper()
		{
			commands = new Dictionary<string, ICommand>();

		}

		public void MapCommand(ICommand command, string eventType)
		{
			if (!commands.ContainsKey(eventType))
			{
				commands.Add(eventType, command);
				CommandEventDispatcher.GetInstance().AddListener<CommandEvent>(eventType,command.execute);
			}
			else
			{
				throw new Exception("This command is already mapped to:" + eventType);
			}
		}

		public void RemoveCommand(ICommand command, string eventType)
		{
			if (commands.ContainsKey(eventType))
			{
				CommandEventDispatcher.GetInstance().RemoveListener<CommandEvent>(eventType,command.execute);
				commands.Remove(eventType);
			}
			else
			{
				throw new Exception("This command is not mapped to:" + eventType);
			}
		}
	}
}
