using System;
namespace commands.com.tgi.ctoe
{
	public interface ICommandEventDispatcher : IDisposable {
		
		void AddListener<TEvent>(string eventType,EventHandlerDelegate<TEvent> handler) where TEvent : ICommandEvent;

		void RemoveListener<TEvent>(string eventType,EventHandlerDelegate<TEvent> handler) where TEvent : ICommandEvent;

		void RemoveAllListeners();

		void Dispatch<TEvent>(TEvent @event) where TEvent : ICommandEvent;
	}
}
