using System;

namespace commands.com.tgi.ctoe
{
	public class CommandEvent : ICommandEvent
    {
        private string type;
        private object data;

        public CommandEvent(string type, object data = null){
            this.type = type;
            this.data = data;

        }

		public void dispatch(){
			CommandEventDispatcher.GetInstance().Dispatch(this);
        }

        public object getEventData()
        {
            return data;
        }

        public string getEventType()
		{
			return type;
		}
	}
}