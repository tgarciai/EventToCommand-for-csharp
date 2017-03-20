using System;
namespace commands.com.tgi.ctoe
{
	public interface ICommandEvent
	{
		string getEventType();

		object getEventData();
		void dispatch();
	}
}
