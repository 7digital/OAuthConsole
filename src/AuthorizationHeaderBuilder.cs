using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using SevenDigital.Api.OAuthConsole.UI.OAuth;

namespace SevenDigital.Api.OAuthConsole.UI
{
	public class AuthorizationHeaderBuilder
	{

		private void AddTo(string key, string parameter,
		                   IDictionary<string, string> dictionary)
		{
			if (false == String.IsNullOrEmpty(parameter))
			{
				dictionary.Add(key, HttpUtility.UrlEncode(parameter));
			}
		}

		public string Build(string oAuthVersion, OAuthRequest oAuthRequest)
		{
			IDictionary<string, string> oAuthParameters = new Dictionary<string, string>();
			AddTo(OAuthQueryParameters.VERSION_KEY, oAuthVersion, oAuthParameters);
			AddTo(OAuthQueryParameters.NONCE_KEY, oAuthRequest.Nonce, oAuthParameters);
			AddTo(OAuthQueryParameters.TIMESTAMP_KEY, oAuthRequest.TimeStamp, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_METHOD_KEY,
			      OAuthQueryParameters.HMACSHA1_SIGNATURE_TYPE, oAuthParameters);
			AddTo(OAuthQueryParameters.CONSUMER_KEY_KEY, oAuthRequest.OAuthConsumerKey, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_KEY, oAuthRequest.Signature, oAuthParameters);

			if (!String.IsNullOrEmpty(oAuthRequest.OAuthTokenKey))
			{
				AddTo(OAuthQueryParameters.TOKEN_KEY, oAuthRequest.OAuthTokenKey, oAuthParameters);
			}
			return BuildOAuthHeaderString(oAuthParameters);
		}

		private string BuildOAuthHeaderString(IDictionary<string, string> oAUthParameters)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("OAuth ");
			foreach (var kvp in oAUthParameters)
			{
				sb.AppendFormat("{0}=\"{1}\",", kvp.Key, kvp.Value);
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}

	}
}