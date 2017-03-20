using System;
namespace commands.com.tgi.ctoe
{
	public interface ICommandEvent
	{
		string getEventType();
		void dispatch();
	}
}
