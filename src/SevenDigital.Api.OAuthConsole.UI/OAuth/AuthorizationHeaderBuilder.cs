using System;
using System.Collections.Generic;
using System.Text;

namespace SevenDigital.Api.OAuthConsole.UI.OAuth
{
	public class AuthorizationHeaderBuilder
	{
		private void Add(string key, string parameter, IDictionary<string, string> dictionary) {
			if (false == String.IsNullOrEmpty(parameter)) {
				dictionary.Add(key, OAuthBase.UrlEncode(parameter));
			}
		}

		public string Build(OAuthRequest oAuthRequest) {
			IDictionary<string, string> oAuthParameters = new Dictionary<string, string>();
			Add(OAuthBase.OAuthVersionKey, oAuthRequest.OAuthVersion, oAuthParameters);
			Add(OAuthBase.OAuthNonceKey, oAuthRequest.Nonce, oAuthParameters);
			Add(OAuthBase.OAuthTimestampKey, oAuthRequest.TimeStamp, oAuthParameters);
			Add(OAuthBase.OAuthSignatureMethodKey, OAuthBase.HMACSHA1SignatureType, oAuthParameters);
			Add(OAuthBase.OAuthConsumerKeyKey, oAuthRequest.OAuthConsumerKey, oAuthParameters);
			Add(OAuthBase.OAuthSignatureKey, oAuthRequest.Signature, oAuthParameters);

			if (!String.IsNullOrEmpty(oAuthRequest.OAuthTokenKey)) {
				Add(OAuthBase.OAuthTokenKey, oAuthRequest.OAuthTokenKey, oAuthParameters);
			}
			return BuildOAuthHeaderString(oAuthParameters);
		}

		private string BuildOAuthHeaderString(IDictionary<string, string> oAUthParameters) {
			var sb = new StringBuilder();
			sb.Append("OAuth ");
			foreach (var kvp in oAUthParameters) {
				sb.AppendFormat("{0}=\"{1}\",", kvp.Key, kvp.Value);
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}
	}
}