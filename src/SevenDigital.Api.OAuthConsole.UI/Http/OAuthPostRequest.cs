using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;
using SevenDigital.Api.OAuthConsole.UI.OAuth;

namespace SevenDigital.Api.OAuthConsole.UI.Http
{
	public class OAuthPostRequest
	{
		private const string APPLICATION_X_WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";

		private const string AUTHORIZATION_HEADER = "Authorization";

		public string Post(OAuthRequest oAuthRequest) {
			var client = new WebClient();

			if (oAuthRequest.UseAuthHeader) {
				string authHeader = GetAuthHeader(oAuthRequest);
				client.Headers.Add(AUTHORIZATION_HEADER, authHeader);
			}else {
				string oAuthPostParams = GetOAuthParamsForBody(oAuthRequest);
				string prefix = "";
				if (!string.IsNullOrEmpty(oAuthRequest.PostParams)) prefix = "&";
				oAuthRequest.PostParams = oAuthRequest.PostParams + prefix + oAuthPostParams;
			}
			client.Headers.Add(HttpRequestHeader.ContentType, APPLICATION_X_WWW_FORM_URLENCODED);

			NotifyRequest(oAuthRequest, client.Headers);

			IgnoreSSLErrors();

			return GetPostResponse(oAuthRequest, client);
		}

		private string GetAuthHeader(OAuthRequest oAuthRequest) {
			return new AuthorizationHeaderBuilder().Build(oAuthRequest);
		}

		private string GetPostResponse(OAuthRequest oAuthRequest, WebClient client) {
			string response;
			try {
				response = client.UploadString(oAuthRequest.FullyQualifiedUrl, oAuthRequest.PostParams);
			} catch (WebException ex) {
				NotifyErrorResponse(ex);
				response = "[Failed: Please check the Console Out Tab]";
			}
			return response;
		}

		private void NotifyErrorResponse(WebException ex) {
			WebResponse reponse = ex.Response;
			using (var reader = new StreamReader(reponse.GetResponseStream())) {
				TestHelper.FireLogMessage("[Invoke POST-Error]: {0}", reader.ReadToEnd());
			}
		}

		private void IgnoreSSLErrors() {
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((sender, certificate, chain, sslpolicyerrors) => true);
		}

		private void NotifyRequest(OAuthRequest oAuthRequest, WebHeaderCollection headers) {
			TestHelper.DumpNameValueCollection(headers, "Headers");
			TestHelper.FireLogMessage("[Invoke POST]: {0}", oAuthRequest.FullyQualifiedUrl);
			TestHelper.FireLogMessage("[Invoke POST-parameters]: {0}", oAuthRequest.PostParams);
		}

	

		public string GetOAuthParamsForBody(OAuthRequest authPostRequest)
		{
			IDictionary<string, string> oAuthParameters = new Dictionary<string, string>();
			AddTo(OAuthBase.OAuthVersionKey, authPostRequest.OAuthVersion, oAuthParameters);
			AddTo(OAuthBase.OAuthNonceKey, authPostRequest.Nonce, oAuthParameters);
			AddTo(OAuthBase.OAuthTimestampKey, authPostRequest.TimeStamp, oAuthParameters);
			AddTo(OAuthBase.OAuthSignatureMethodKey, OAuthBase.HMACSHA1SignatureType, oAuthParameters);
			AddTo(OAuthBase.OAuthConsumerKeyKey, authPostRequest.OAuthConsumerKey, oAuthParameters);
			AddTo(OAuthBase.OAuthSignatureKey,  authPostRequest.Signature , oAuthParameters);

			if (!String.IsNullOrEmpty( authPostRequest.OAuthTokenKey)) {
				AddTo(OAuthBase.OAuthTokenKey, authPostRequest.OAuthTokenKey, oAuthParameters);
			}
			return GetKeyPairString(oAuthParameters);
		}

		private void AddTo(string key, string parameter, IDictionary<string, string> dictionary) {
			if (false == String.IsNullOrEmpty(parameter)) {
				dictionary.Add(key, OAuthBase.UrlEncode(parameter));
			}
		}

		private string GetKeyPairString(IDictionary<string, string> oAUthParameters) {
			var sb = new StringBuilder();

			foreach (var kvp in oAUthParameters) {
				sb.AppendFormat("{0}={1}&", kvp.Key, kvp.Value);
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}
	}
}