using System;
using System.Net;

namespace OAuthSig
{
	internal class OAuthRequest
	{
		private readonly IView _view;

		public OAuthRequest(IView view)
		{
			_view = view;
		}

		public void Request()
		{
			string httpMethod = _view.HttpMethod;
			if (String.IsNullOrEmpty(_view.GeneratedUrl))
			{
				return;
			}

			if (httpMethod == "POST")
			{
				DoHttpPost();
			}
			else
			{
				DoHttpGet();
			}

			_view.Log();
		}

		private void DoHttpGet()
		{
			var webClient = new WebClient();
			string response = webClient.DownloadString(_view.GeneratedUrl);
			_view.DisplayResponse(response);
		}

		private void DoHttpPost()
		{
			try
			{
				var apiPostRequestBuilder = new ApiPostRequestBuilder();
				var uri = new Uri(_view.Uri);
				string response = apiPostRequestBuilder.Build(true,
				                                              uri, _view.PostData,
				                                              _view.ConsumerKey,
				                                              _view.ConsumerSecret, _view.Token,
				                                              _view.TokenSecret, _view.RawSignature, _view.Nonce,
				                                              _view.TimeStamp);
				_view.DisplayResponse(response);
			}
			catch (WebException wex)
			{
				TestHelper.FireLogMessage(wex.Message);
			}
		}
	}
}