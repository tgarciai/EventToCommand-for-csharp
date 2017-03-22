namespace commands.com.tgi.ctoe
{	
	public delegate void EventHandlerDelegate<in TCommandEvent>(TCommandEvent @event) where TCommandEvent : ICommandEvent;
}