using System;
using System.Collections.Generic;

namespace commands.com.tgi.ctoe
{
	public class CommandEventDispatcher : ICommandEventDispatcher
    {
        private static CommandEventDispatcher instance;


		private Dictionary<string, Delegate> eventHandlers1;

		public CommandEventDispatcher()
		{
			 eventHandlers1 = new Dictionary<string, Delegate>();
		}

        public static CommandEventDispatcher GetInstance(){
            if(instance == null){
                instance = new CommandEventDispatcher();
            }
            return instance;
        }

		public void AddListener<TCommandEvent>(string eventType, EventHandlerDelegate<TCommandEvent> handler) where TCommandEvent : ICommandEvent
		{
			if(eventHandlers1.ContainsKey(eventType)){
				throw new Exception("Cannot map two commands to same event");
			}else{
				eventHandlers1[eventType] = handler;
			}
		}

		public void Dispatch<TCommandEvent>(TCommandEvent anyEvent) where TCommandEvent : ICommandEvent
		{
			if (anyEvent == null) throw new ArgumentNullException("Event to Dispatch is null");
			if (disposedValue) throw new ObjectDisposedException("Event Dispatcher is disposed! ");

			Delegate myHandler;

			if (TryToGetHandler(anyEvent.getEventType(), out myHandler))
			{
				EventHandlerDelegate<TCommandEvent> myHandlerCallBack = myHandler as EventHandlerDelegate<TCommandEvent>;
				if (myHandlerCallBack != null)
				{
					myHandlerCallBack(anyEvent);
				}
			}
		}

		public void RemoveListener<TCommandEvent>(string eventType, EventHandlerDelegate<TCommandEvent> handler) where TCommandEvent : ICommandEvent
		{
			Delegate commandHandler;
			if (TryToGetHandler(eventType, out commandHandler))
            {
				Delegate currentDel = Delegate.Remove(commandHandler, handler);

                if (currentDel == null)
                {
                    eventHandlers1.Remove(eventType);
                }
                
            }
		}

		public void RemoveAllListeners()
        {
            var handlers = new string[eventHandlers1.Keys.Count];
            eventHandlers1.Keys.CopyTo(handlers, 0);

            foreach (string eventType in handlers)
            {
                Delegate[] delegates = eventHandlers1[eventType].GetInvocationList();
                foreach (Delegate @delegate in delegates)
                {
                    var handlerToRemove = Delegate.Remove(eventHandlers1[eventType], @delegate);
                    if (handlerToRemove == null)
                    {
                        eventHandlers1.Remove(eventType);
                    }
                    else
                    {
                        eventHandlers1[eventType] = handlerToRemove;
                    }
                }
            }
        }

		private Boolean TryToGetHandler(string eventType, out Delegate myHandler)
		{
			if (eventHandlers1.TryGetValue(eventType, out myHandler))
			{
				return true;
			}
			return false;

		}

		#region IDisposable Support
		private bool disposedValue = false; // Para detectar llamadas redundantes

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					RemoveAllListeners();
				}

				//free unmanaged resources (unmanaged objects) and override a finalizer below.
				//set large fields to null.
				eventHandlers1 = null;

				disposedValue = true;
			}
		}

		// override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		~CommandEventDispatcher() {
		   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		   Dispose(false);
	    }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			GC.SuppressFinalize(this);
		}

       


        #endregion
    }
}