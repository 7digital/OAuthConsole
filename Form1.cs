using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using OAuth;

namespace OAuthSig
{
	public partial class Form1 : Form, IView
	{
		public Form1() {
			InitializeComponent();
			TestHelper.OnLogMessage += (ApiTestHelper_OnLogMessage);
		}

		private StringBuilder _sb = new StringBuilder();

		private void ApiTestHelper_OnLogMessage(object sender, EventArgs<string> args) {
			_sb.AppendLine(args.EventData);
		}

		private void Form1_Load(object sender, EventArgs e) {
			drpSigMethod.SelectedIndex = 0;
			drpHTTPMethod.SelectedIndex = 0;
		}

		private void btnGenerate_Click(object sender, EventArgs e) {
		

			DoStuff(this);
		}

	    private void DoStuff(IView view)
	    {


            OAuthBase.SignatureTypes signatureType = OAuthBase.SignatureTypes.HMACSHA1;
            string normalizedUrl = null;
            string normalizedRequestParameters = null;
            OAuthBase myOAuth = new OAuthBase();
	        try {
	            Uri uri = new Uri(view.Uri);

	            string consumerKey = view.ConsumerKey;
	            string consumerSecret = view.ConsumerSecret;
	            string token = view.Token;
	            string tokenSecret = view.TokenSecret;
	            string httpMethod = view.HttpMethod;
	            string timeStamp = view.TimeStamp;
	            string nonce = view.Nonce;

	            if (string.IsNullOrEmpty(timeStamp)) {
	                timeStamp = myOAuth.GenerateTimeStamp();
	                txtTimestamp.Text = timeStamp;
	            }

	            if (string.IsNullOrEmpty(nonce)) {
	                nonce = myOAuth.GenerateNonce();
	                txtNonce.Text = nonce;
	            }

	            switch (drpSigMethod.SelectedIndex) {
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

	            myOAuth.includeVersion = chkVersion.Checked;
                
	            string signature = "";
	            if (httpMethod == "POST")
	            {
	                Dictionary<string, string> dictionary = new ApiPostRequestBuilder().GetFormVariables(postVariablesTextBox.Text);
	                signature = myOAuth.GenerateSignature(uri, txtConsKey.Text, txtConsSecret.Text, txtToken.Text, txtTokenSecret.Text, "POST",
	                                                      timeStamp, nonce, OAuthBase.SignatureTypes.HMACSHA1, out normalizedUrl, out normalizedRequestParameters, dictionary);
                     
	            }else
	            {
	                signature = myOAuth.GenerateSignature(uri, consumerKey, consumerSecret,
	                                                      token, tokenSecret, httpMethod,
	                                                      timeStamp, nonce, signatureType,
	                                                      out normalizedUrl,
	                                                      out normalizedRequestParameters, null);
	            }

	            txtRawSig.Text = signature;
	            txtEncodedSig.Text = myOAuth.UrlEncode(signature);

	            txtGenURL.Text = normalizedUrl + "?" + normalizedRequestParameters +
	                             "&oauth_signature=" + txtEncodedSig.Text;
	        } catch (Exception exception) {
	            MessageBox.Show(exception.Message);
	        }
	    }

	    private void makeRequestButton_Click(object sender, EventArgs e) {
			txtConsoleOut.Text = String.Empty;
			string httpMethod = drpHTTPMethod.SelectedItem.ToString();
			if (string.IsNullOrEmpty(txtGenURL.Text)) {
				return;
			}

			if (httpMethod == "POST") {
				ApiPostRequestBuilder apiPostRequestBuilder = new ApiPostRequestBuilder();
				Uri uri = new Uri(txtURI.Text);
				responseText.Text = apiPostRequestBuilder.Build(true,
				                                                uri, postVariablesTextBox.Text,
				                                                txtConsKey.Text,
				                                                txtConsSecret.Text, txtToken.Text,
				                                                txtTokenSecret.Text, txtRawSig.Text, txtNonce.Text, txtTimestamp.Text);
			} else {
				WebClient webClient = new WebClient();
				string response = webClient.DownloadString(txtGenURL.Text);
				responseText.Text = response;
			}

			txtConsoleOut.Text = _sb.ToString();
			_sb = new StringBuilder();
		}

	    public string Uri
	    {
            get { return txtURI.Text; }
	        set { txtURI.Text = value; }
	    }

	    public string ConsumerKey
	    {
            get { return txtConsKey.Text; }
	    }

	    public string ConsumerSecret
	    {
            get { return txtConsSecret.Text; }
	    }

	    public string Token
	    {
            get { return txtToken.Text; }
	    }

	    public string TokenSecret
	    {
            get { return txtTokenSecret.Text; }
	    }

	    public string HttpMethod
	    {
            get { return drpHTTPMethod.SelectedItem.ToString(); }
	    }

	    public string TimeStamp
	    {
	        get { return txtTimestamp.Text; }
	        set { txtTimestamp.Text = value; }
	    }

	    public string Nonce
	    {
	        get { return txtNonce.Text; }
	        set { txtNonce.Text = value; }
	    }
	}
}