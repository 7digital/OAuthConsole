using SevenDigital.Security.OAuth.Signature;

namespace OAuthSig
{
	public static class OAuthQueryParameters
	{
		public const string CALLBACK_KEY = "oauth_callback";
		public const string CONSUMER_KEY_KEY = "oauth_consumer_key";
		public const string HMACSHA1_SIGNATURE_TYPE = "HMAC-SHA1";
		public const string NONCE_KEY = "oauth_nonce";
		public const string PARAMETER_PREFIX = "oauth_";
		public const string PLAIN_TEXT_SIGNATURE_TYPE = "PLAINTEXT";
		public const string RSASHA1_SIGNATURE_TYPE = "RSA-SHA1";
		public const string SIGNATURE_KEY = "oauth_signature";
		public const string SIGNATURE_METHOD_KEY = "oauth_signature_method";
		public const string TIMESTAMP_KEY = "oauth_timestamp";
		public const string TOKEN_KEY = "oauth_token";
		public const string TOKEN_SECRET_KEY = "oauth_token_secret";
		public const string VERSION = "1.0";
		public const string VERSION_KEY = "oauth_version";
	}
}
