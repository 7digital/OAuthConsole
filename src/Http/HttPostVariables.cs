using System.Collections.Generic;
using System.Linq;

namespace SevenDigital.Api.OAuthConsole.UI.Http
{
	internal class HttPostVariables
	{
		public Dictionary<string, string> Parse(string postParams)
		{
			if (string.IsNullOrEmpty(postParams))
			{
				return new Dictionary<string, string>();
			}
			IEnumerable<string> enumerable = postParams.Split('&').Select(s => s);
			return enumerable.ToDictionary(str => str.Split('=')[0], str => str.Split('=')[1]);
		}

	}
}