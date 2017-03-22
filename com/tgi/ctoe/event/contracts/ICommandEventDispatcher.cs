using System;
namespace commands.com.tgi.ctoe
{
	public interface ICommandEventDispatcher : IDisposable {
		
		void AddListener<TCommandEvent>(string eventType,EventHandlerDelegate<TCommandEvent> handler) where TCommandEvent : ICommandEvent;

		void RemoveListener<TCommandEvent>(string eventType,EventHandlerDelegate<TCommandEvent> handler) where TCommandEvent : ICommandEvent;

		void RemoveAllListeners();

		void Dispatch<TCommandEvent>(TCommandEvent @event) where TCommandEvent : ICommandEvent;
	}
}
