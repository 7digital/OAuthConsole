using System;
using System.IO;
using System.Net;
using SevenDigital.Api.OAuthConsole.UI.Http;

namespace SevenDigital.Api.OAuthConsole.UI.OAuth
{
	internal class HttpOAuthClient
	{
		private readonly IView _view;

		public HttpOAuthClient(IView view) {
			_view = view;
		}

		public void Request() {
			string httpMethod = _view.HttpMethod;
			if (String.IsNullOrEmpty(_view.GeneratedUrl)) {
				return;
			}

			if (httpMethod == "POST" ) {
				DoHttpPost();
			}
			else if (httpMethod == "GET") {
				DoHttpGet();
			}

			_view.Log();
		}

		private void DoHttpGet() {
			try {
				var webClient = new WebClient();
				string response = webClient.DownloadString(_view.GeneratedUrl);
				_view.DisplayResponse(response);
			} catch (WebException wex) {
				DisplayError(wex);
			}
		}

		private void DisplayError(WebException wex) {
			_view.DisplayResponse("[Failed: Please check the Console Out Tab]");
			string response = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
			TestHelper.FireLogMessage(wex.Message);
			TestHelper.FireLogMessage(response);
			_view.Log();
		}

		private void DoHttpPost() {
			try {
				var apiPostRequestBuilder = new OAuthPostRequest();
				var uri = new Uri(_view.Uri);
				var oAuthRequest = new OAuthRequest(true, uri, _view.PostData, _view.ConsumerKey, _view.ConsumerSecret, _view.Token, _view.TokenSecret, _view.RawSignature, _view.Nonce, _view.TimeStamp);
				if (_view.IncludeVersion) oAuthRequest.OAuthVersion = OAuthBase.OAuthVersion;
				oAuthRequest.UseAuthHeader = _view.UseAuthHeader;
				string response = apiPostRequestBuilder.Post(oAuthRequest);
				_view.DisplayResponse(response);
			} catch (WebException wex) {
				DisplayError(wex);
			}
		}

		
	}
}