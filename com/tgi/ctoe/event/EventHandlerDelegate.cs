namespace commands.com.tgi.ctoe
{	
	public delegate void EventHandlerDelegate<in TEvent>(TEvent @event) where TEvent : ICommandEvent;
}