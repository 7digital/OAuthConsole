using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SevenDigital.Api.OAuthConsole.UI.Extensions
{
	public static class CollectionExtensions
	{
		public static IEnumerable<KeyValuePair<string, string>> ToPairs(
			this NameValueCollection collection) {
			if (collection == null) {
				throw new ArgumentNullException("collection");
			}

			return
				collection.Cast<string>().Select(
					key => new KeyValuePair<string, string>(key, collection[key]));
		}
	}
}