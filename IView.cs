using System;

namespace OAuthSig
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
    }
}