using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;
using OAuth;

namespace OAuthSig
{
	public class OAuthPostRequest
	{

		public string Post(bool oAuthSignRequest, Uri fullyQualifiedUrl, string postParams,
							string oAuthConsumerKey, string oAuthConsumerSecret,
							string oAuthTokenKey,
							string oAuthTokenSecret, string signature, string nonce, string timeStamp) {

			WebClient client = new WebClient();

			if (oAuthSignRequest) {

                string header = GetHeader(OAuthBase.OAuthVersion, nonce, timeStamp, signature,
                                          oAuthConsumerKey, oAuthTokenKey);
				client.Headers.Add("Authorization", header);
			}
			else {
				IDictionary<string, string> values = new Dictionary<string, string>();
				values.Add(OAuthQueryParameters.CONSUMER_KEY_KEY, oAuthConsumerKey);
				client.Headers.Add("Authorization", BuildOAuthHeaderString(values));
			}
			client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

			TestHelper.DumpNameValueCollection(client.Headers, "Headers");
			TestHelper.FireLogMessage("[Invoke POST]: {0}", fullyQualifiedUrl);
			TestHelper.FireLogMessage("[Invoke POST-parameters]: {0}", postParams);
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
				(
				(sender, certificate, chain, sslpolicyerrors) => true);

			try {
				return client.UploadString(fullyQualifiedUrl, postParams);
			}
			catch (WebException ex) {
				var reponse = ex.Response;
				using (var reader = new StreamReader(reponse.GetResponseStream())) {
					TestHelper.FireLogMessage("[Invoke POST-Error]: {0}", reader.ReadToEnd());
				}
				return "[Failed: Please check the Console Out Tab]";
			}
		}

		private void AddTo(string key, string parameter,
						   IDictionary<string, string> dictionary) {
			if (false == String.IsNullOrEmpty(parameter)) {
				dictionary.Add(key, HttpUtility.UrlEncode(parameter));
			}
		}

		private string BuildOAuthHeaderString(IDictionary<string, string> oAUthParameters) {
			StringBuilder sb = new StringBuilder();
			sb.Append("OAuth ");
			foreach (var kvp in oAUthParameters) {
				sb.AppendFormat("{0}=\"{1}\",", kvp.Key, kvp.Value);
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}

	    public Dictionary<string, string> GetFormVariables(string postParams) {
			if (string.IsNullOrEmpty(postParams)) {
				return new Dictionary<string, string>();
			}
			IEnumerable<string> enumerable = postParams.Split('&').Select(s => s);
			return enumerable.ToDictionary(str => str.Split('=')[0], str => str.Split('=')[1]);
		}

	    public string GetHeader(string oAuthVersion, string nonce, string timeStamp,
								 string signature, string oAuthConsumerKey,
								 string oAuthTokenKey) {
			IDictionary<string, string> oAuthParameters = new Dictionary<string, string>();
			AddTo(OAuthQueryParameters.VERSION_KEY, oAuthVersion, oAuthParameters);
			AddTo(OAuthQueryParameters.NONCE_KEY, nonce, oAuthParameters);
			AddTo(OAuthQueryParameters.TIMESTAMP_KEY, timeStamp, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_METHOD_KEY,
				  OAuthQueryParameters.HMACSHA1_SIGNATURE_TYPE, oAuthParameters);
			AddTo(OAuthQueryParameters.CONSUMER_KEY_KEY, oAuthConsumerKey, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_KEY, signature, oAuthParameters);

			if (!String.IsNullOrEmpty(oAuthTokenKey)) {
				AddTo(OAuthQueryParameters.TOKEN_KEY, oAuthTokenKey, oAuthParameters);
			}
			return BuildOAuthHeaderString(oAuthParameters);
		}

	}
}