using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using OAuthSig.Extensions;

namespace OAuthSig
{
	internal static class TestHelper
	{
		public static event EventHandler<EventArgs<string>> OnLogMessage;

		internal static void FireLogMessage(string message) {
			if (OnLogMessage != null) {
				OnLogMessage(null, new EventArgs<string>(message));
			}
		}

		internal static void FireLogMessage(string message, params object[] args) {
			FireLogMessage(String.Format(message, args));
		}

		internal static void DumpNameValueCollection(NameValueCollection pNameValue,
		                                             string pCollectionName) {
			var sb = new StringBuilder();
			pNameValue.ToPairs()
				.OrderBy(x => x.Key)
				.ToList()
				.ForEach(x => sb.Append("{0}={1},".FormatWith(x.Key, x.Value)));

			FireLogMessage("[{1}] : {0}", sb.ToString(), pCollectionName);
		}
	}
}