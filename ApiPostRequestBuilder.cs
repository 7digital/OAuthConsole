using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;
using SevenDigital.Security.OAuth.Signature;

namespace OAuthSig
{
	public class ApiPostRequestBuilder
	{
		public string Build(bool oAuthSignRequest, Uri fullyQualifiedUrl, string postParams, string oAuthConsumerKey, string oAuthConsumerSecret, string signature, string timeStamp, string nonce, string oAuthVersion, string tokenKey, string tokenSecret)
		{
			try
			{
			WebClient client = new WebClient();
			if (oAuthSignRequest)
			{
				client.Headers.Add("Authorization", GetSignedAuthorizationHeader(fullyQualifiedUrl, postParams, oAuthConsumerKey,  signature,  timeStamp,  nonce, oAuthVersion, oAuthConsumerSecret, tokenKey, tokenSecret));
			}
			else
			{
				IDictionary<string, string> values = new Dictionary<string, string>();
				values.Add(OAuthQueryParameters.CONSUMER_KEY_KEY, oAuthConsumerKey);
				client.Headers.Add("Authorization", BuildOAuthHeaderString(values));
			}
		
				client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
				(
				(sender, certificate, chain, sslpolicyerrors) => true);

				return client.UploadString(fullyQualifiedUrl, postParams);
			}catch(WebException ex) {
				return ex.Message;
			}
		}

		private void AddTo(string key, string parameter, IDictionary<string, string> dictionary)
		{
			if (false == String.IsNullOrEmpty(parameter))
			{
				dictionary.Add(key, HttpUtility.UrlEncode(parameter));
			}
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

		private Dictionary<string, string> GetFormVariables(string postParams)
		{
			if (string.IsNullOrEmpty(postParams))
			{
				return new Dictionary<string, string>();
			}
			IEnumerable<string> enumerable = postParams.Split('&').Select(s => s);
			return enumerable.ToDictionary(str => str.Split('=')[0], str => str.Split('=')[1]);
		}

		private string GetHeader(string oAuthVersion, string nonce, string timeStamp, string signature, string oAuthConsumerKey)
		{
			IDictionary<string, string> oAuthParameters = new Dictionary<string, string>();
			AddTo(OAuthQueryParameters.VERSION_KEY, oAuthVersion, oAuthParameters);
			AddTo(OAuthQueryParameters.NONCE_KEY, nonce, oAuthParameters);
			AddTo(OAuthQueryParameters.TIMESTAMP_KEY, timeStamp, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_METHOD_KEY, OAuthQueryParameters.HMACSHA1_SIGNATURE_TYPE, oAuthParameters);
			AddTo(OAuthQueryParameters.CONSUMER_KEY_KEY, oAuthConsumerKey, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_KEY, signature, oAuthParameters);

			return BuildOAuthHeaderString(oAuthParameters);
		}

		public string Normalize(IDictionary<string, string> parameters)
		{
			SortedDictionary<string, string> sortedParams = this.Sort(parameters);
			StringBuilder result = new StringBuilder();
			int i = 0;
			foreach (string key in sortedParams.Keys)
			{
				i++;
				result.AppendFormat("{0}={1}", key, sortedParams[key]);
				if (i < sortedParams.Count)
				{
					result.Append("&");
				}
			}
			return result.ToString();
		}

		private SortedDictionary<string, string> Sort(IEnumerable<KeyValuePair<string, string>> queryParameters)
		{
			SortedDictionary<string, string> parameters = new SortedDictionary<string, string>();
			foreach (KeyValuePair<string, string> par in queryParameters)
			{
				parameters.Add(par.Key, par.Value);
			}
			return parameters;
		}

		public string GetSignedAuthorizationHeader(Uri url, string postParams, string oAuthConsumerKey, string signature, string timeStamp, string nonce, string oAuthVersion, string consumerSecret, string tokenKey, string tokenSecret)
		{
			Dictionary<string, string> dictionary = GetFormVariables(postParams);

			var sig = new SevenDigital.Security.OAuth.Signature.SignatureGenerator();
			string sigs = sig.Generate(url, dictionary, oAuthConsumerKey, consumerSecret, tokenKey, tokenSecret, "POST", timeStamp, nonce, SignatureGenerator.SignatureTypes.HmacSha1, "1.0");

			string header = GetHeader(oAuthVersion, nonce, timeStamp, sigs, oAuthConsumerKey);

			return header;
		}
	}
}