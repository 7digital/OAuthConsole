using System;

namespace SevenDigital.Api.OAuthConsole.UI
{
	public class EventArgs<T> : EventArgs
	{
		// Fields
		private readonly T _eventData;

		// Methods
		public EventArgs(T eventData) {
			this._eventData = eventData;
		}

		// Properties
		public T EventData {
			get {
				return this._eventData;
			}
		}
	}
}