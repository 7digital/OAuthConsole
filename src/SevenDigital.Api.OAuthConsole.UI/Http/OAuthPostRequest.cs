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
		private const string AUTHORIZATION_HEADER = "Authorization";
		private const string APPLICATION_X_WWW_FORM_URLENCODED = "application/x-www-form-urlencoded";

		public string Post(OAuthRequest oAuthRequest) {

			WebClient client = new WebClient();

			string header = new AuthorizationHeaderBuilder().Build(OAuthBase.OAuthVersion, oAuthRequest);
			client.Headers.Add(AUTHORIZATION_HEADER, header);
			client.Headers.Add(HttpRequestHeader.ContentType, APPLICATION_X_WWW_FORM_URLENCODED);

			NotifyRequest(oAuthRequest, client.Headers);

			IgnoreSSLErrors();

			return GetPostResponse(oAuthRequest, client);
		}

		private string GetPostResponse(OAuthRequest oAuthRequest, WebClient client) {
			string response;
			try {
				response = client.UploadString(oAuthRequest.FullyQualifiedUrl, oAuthRequest.PostParams);
				
			} catch (WebException ex) {
				NotifyErrorResponse(ex);
				response =  "[Failed: Please check the Console Out Tab]";
			}
			return response;
		}

		private void NotifyErrorResponse(WebException ex) {
			var reponse = ex.Response;
			using (var reader = new StreamReader(reponse.GetResponseStream())) {
				TestHelper.FireLogMessage("[Invoke POST-Error]: {0}", reader.ReadToEnd());
			}
		}

		private void IgnoreSSLErrors() {
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
				(
				(sender, certificate, chain, sslpolicyerrors) => true);
		}

		private void NotifyRequest(OAuthRequest oAuthRequest, WebHeaderCollection headers) {
			TestHelper.DumpNameValueCollection(headers, "Headers");
			TestHelper.FireLogMessage("[Invoke POST]: {0}", oAuthRequest.FullyQualifiedUrl);
			TestHelper.FireLogMessage("[Invoke POST-parameters]: {0}", oAuthRequest.PostParams);
		}

		public string PostWithoAuthParamsInBody(bool oAuthSignRequest, Uri fullyQualifiedUrl, string postParams,
						string oAuthConsumerKey, string oAuthConsumerSecret,
						string oAuthTokenKey,
						string oAuthTokenSecret, string signature, string nonce, string timeStamp)
		{


			WebClient client = new WebClient();
			string oauthParamsToAdd = string.Empty;
			if (oAuthSignRequest)
			{
				oauthParamsToAdd = GetOAuthParamsForBody(OAuthBase.OAuthVersion, nonce, timeStamp, signature,
										  oAuthConsumerKey, oAuthTokenKey);

				if (postParams == string.Empty)
				{
					postParams = oauthParamsToAdd.Trim("&".ToCharArray());
				}
				else
				{
					if (oauthParamsToAdd.EndsWith("&") == false)
						oauthParamsToAdd = oauthParamsToAdd + "&";


					postParams = oauthParamsToAdd + postParams;


				}


			}


			client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

			TestHelper.DumpNameValueCollection(client.Headers, "Headers");
			TestHelper.FireLogMessage("[Invoke POST]: {0}", fullyQualifiedUrl);
			TestHelper.FireLogMessage("[Invoke POST-parameters]: {0}", postParams);
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
				(
				(sender, certificate, chain, sslpolicyerrors) => true);

			try
			{
				return client.UploadString(fullyQualifiedUrl, postParams);
			}
			catch (WebException ex)
			{
				var reponse = ex.Response;
				using (var reader = new StreamReader(reponse.GetResponseStream()))
				{
					TestHelper.FireLogMessage("[Invoke POST-Error]: {0}", reader.ReadToEnd());
				}
				return "[Failed: Please check the Console Out Tab]";
			}
		}


		public string GetOAuthParamsForBody(string oAuthVersion, string nonce, string timeStamp,
								 string signature, string oAuthConsumerKey,
								 string oAuthTokenKey)
		{
			IDictionary<string, string> oAuthParameters = new Dictionary<string, string>();
			AddTo(OAuthQueryParameters.VERSION_KEY, oAuthVersion, oAuthParameters);
			AddTo(OAuthQueryParameters.NONCE_KEY, nonce, oAuthParameters);
			AddTo(OAuthQueryParameters.TIMESTAMP_KEY, timeStamp, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_METHOD_KEY,
				  OAuthQueryParameters.HMACSHA1_SIGNATURE_TYPE, oAuthParameters);
			AddTo(OAuthQueryParameters.CONSUMER_KEY_KEY, oAuthConsumerKey, oAuthParameters);
			AddTo(OAuthQueryParameters.SIGNATURE_KEY, signature, oAuthParameters);

			if (!String.IsNullOrEmpty(oAuthTokenKey))
			{
				AddTo(OAuthQueryParameters.TOKEN_KEY, oAuthTokenKey, oAuthParameters);
			}
			return BuildOAuthBodyParamsString(oAuthParameters);
		}

		private void AddTo(string key, string parameter,
					   IDictionary<string, string> dictionary)
		{
			if (false == String.IsNullOrEmpty(parameter))
			{
				dictionary.Add(key, HttpUtility.UrlEncode(parameter));
			}
		}

		private string BuildOAuthBodyParamsString(IDictionary<string, string> oAUthParameters)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var kvp in oAUthParameters)
			{
				sb.AppendFormat("{0}={1}&", kvp.Key, kvp.Value);
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}



	

	
	

	

	}
}