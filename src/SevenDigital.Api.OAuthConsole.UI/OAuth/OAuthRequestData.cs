using System;

namespace SevenDigital.Api.OAuthConsole.UI.OAuth
{
	public class OAuthRequestData {
		public OAuthRequestData(bool oAuthSignRequest, Uri fullyQualifiedUrl, string postParams, string oAuthConsumerKey, string oAuthConsumerSecret, string oAuthTokenKey, string oAuthTokenSecret, string signature, string nonce, string timeStamp, string contentType) {
			OAuthSignRequest = oAuthSignRequest;
			FullyQualifiedUrl = fullyQualifiedUrl;
			PostParams = postParams;
			OAuthConsumerKey = oAuthConsumerKey;
			OAuthConsumerSecret = oAuthConsumerSecret;
			OAuthTokenKey = oAuthTokenKey;
			OAuthTokenSecret = oAuthTokenSecret;
			Signature = signature;
			Nonce = nonce;
			TimeStamp = timeStamp;
		    ContentType = contentType;
		}

		public bool OAuthSignRequest { get; private set; }

		public Uri FullyQualifiedUrl { get; private set; }

		public string PostParams { get; set; }

		public string OAuthConsumerKey { get; private set; }

		public string OAuthConsumerSecret { get; private set; }

		public string OAuthTokenKey { get; private set; }

		public string OAuthTokenSecret { get; private set; }

		public string Signature { get; private set; }

		public string Nonce { get; private set; }

		public string TimeStamp { get; private set; }

		public bool UseAuthHeader { get; set; }

		public string OAuthVersion { get; set; }

        public string ContentType { get; set; }
	}
}