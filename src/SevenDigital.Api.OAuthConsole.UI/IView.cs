namespace SevenDigital.Api.OAuthConsole.UI
{
    public interface IView
    {
        string Uri { get; set; }
        string ConsumerKey { get;  }
        string ConsumerSecret { get; }
        string Token { get; }
        string TokenSecret { get; }
        string HttpMethod { get; }
        string TimeStamp { get; set; }
        string Nonce { get; set; }
        bool UseAuthHeader { get; }
        string RawSignature { get; set; }
        bool IncludeVersion { get; }
        string EncodedSignature { get; set; }
        string GeneratedUrl { get; set; }
        string PostData { get; }
        int SignatureMethod { get; }
        void DisplayResponse(string response);
        void Log();
    }
}