using System.IO;
using System.Net;
using System.Net.Security;
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
			client.Headers.Add(HttpResponseHeader.ContentType, APPLICATION_X_WWW_FORM_URLENCODED);

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

	

	
	

	

	}
}