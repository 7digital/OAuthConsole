using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SevenDigital.Api.OAuthConsole.UI
{
	internal class OAuthSignatureBuilder
	{
		private readonly IView _view;

		public OAuthSignatureBuilder(IView view)
		{
			_view = view;
		}

		public void GenerateSignature()
		{
			OAuthBase.SignatureTypes signatureType = OAuthBase.SignatureTypes.HMACSHA1;
			string normalizedUrl = null;
			string normalizedRequestParameters = null;
			var myOAuth = new OAuthBase();
			try
			{
				var uri = new Uri(_view.Uri);

				string consumerKey = _view.ConsumerKey;
				string consumerSecret = _view.ConsumerSecret;
				string token = _view.Token;
				string tokenSecret = _view.TokenSecret;
				string httpMethod = _view.HttpMethod;
				string timeStamp = _view.TimeStamp;
				string nonce = _view.Nonce;

				if (String.IsNullOrEmpty(timeStamp))
				{
					timeStamp = myOAuth.GenerateTimeStamp();
					_view.TimeStamp = timeStamp;
				}

				if (String.IsNullOrEmpty(nonce))
				{
					nonce = myOAuth.GenerateNonce();
					_view.Nonce = nonce;
				}

				switch (_view.SignatureMethod)
				{
					case 0:
						signatureType = OAuthBase.SignatureTypes.HMACSHA1;
						break;
					case 1:
						signatureType = OAuthBase.SignatureTypes.PLAINTEXT;
						break;
					case 2:
						signatureType = OAuthBase.SignatureTypes.RSASHA1;
						break;
				}

				myOAuth.includeVersion = _view.IncludeVersion;

				string signature = "";
				if (httpMethod == "POST")
				{
					Dictionary<string, string> dictionary = new OAuthPostRequest().GetFormVariables(_view.PostData);
					signature = myOAuth.GenerateSignature(uri, consumerKey, consumerSecret, token, tokenSecret, httpMethod,
					                                      timeStamp, nonce, signatureType, out normalizedUrl,
					                                      out normalizedRequestParameters, dictionary);
				}
				else
				{
					signature = myOAuth.GenerateSignature(uri, consumerKey, consumerSecret,
					                                      token, tokenSecret, httpMethod,
					                                      timeStamp, nonce, signatureType,
					                                      out normalizedUrl,
					                                      out normalizedRequestParameters, null);
				}

				_view.RawSignature = signature;
				_view.EncodedSignature = myOAuth.UrlEncode(signature);

				_view.GeneratedUrl = normalizedUrl + "?" + normalizedRequestParameters +
				                     "&oauth_signature=" + _view.EncodedSignature;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}