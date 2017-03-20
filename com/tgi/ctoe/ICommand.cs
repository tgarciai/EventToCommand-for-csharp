using System;
namespace commands.com.tgi.ctoe
{
	public interface ICommand
	{
		void execute(ICommandEvent @event);
	}
}
