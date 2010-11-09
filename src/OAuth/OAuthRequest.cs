using System;

namespace SevenDigital.Api.OAuthConsole.UI.OAuth
{
	public class OAuthRequest {
		private bool _oAuthSignRequest;
		private Uri _fullyQualifiedUrl;
		private string _postParams;
		private string _oAuthConsumerKey;
		private string _oAuthConsumerSecret;
		private string _oAuthTokenKey;
		private string _oAuthTokenSecret;
		private string _signature;
		private string _nonce;
		private string _timeStamp;

		public OAuthRequest(bool oAuthSignRequest, Uri fullyQualifiedUrl, string postParams, string oAuthConsumerKey, string oAuthConsumerSecret, string oAuthTokenKey, string oAuthTokenSecret, string signature, string nonce, string timeStamp) {
			_oAuthSignRequest = oAuthSignRequest;
			_fullyQualifiedUrl = fullyQualifiedUrl;
			_postParams = postParams;
			_oAuthConsumerKey = oAuthConsumerKey;
			_oAuthConsumerSecret = oAuthConsumerSecret;
			_oAuthTokenKey = oAuthTokenKey;
			_oAuthTokenSecret = oAuthTokenSecret;
			_signature = signature;
			_nonce = nonce;
			_timeStamp = timeStamp;
		}

		public bool OAuthSignRequest {
			get { return _oAuthSignRequest; }
		}

		public Uri FullyQualifiedUrl {
			get { return _fullyQualifiedUrl; }
		}

		public string PostParams {
			get { return _postParams; }
		}

		public string OAuthConsumerKey {
			get { return _oAuthConsumerKey; }
		}

		public string OAuthConsumerSecret {
			get { return _oAuthConsumerSecret; }
		}

		public string OAuthTokenKey {
			get { return _oAuthTokenKey; }
		}

		public string OAuthTokenSecret {
			get { return _oAuthTokenSecret; }
		}

		public string Signature {
			get { return _signature; }
		}

		public string Nonce {
			get { return _nonce; }
		}

		public string TimeStamp {
			get { return _timeStamp; }
		}
	}
}