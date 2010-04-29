using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using OAuth;

namespace OAuthSig
{
	public partial class Form1 : Form
	{
		public Form1() {
			InitializeComponent();
			ApiTestHelper.OnLogMessage += (ApiTestHelper_OnLogMessage);
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
			OAuthBase.SignatureTypes signatureType = OAuthBase.SignatureTypes.HMACSHA1;
			string normalizedUrl;
			string normalizedRequestParameters;
			OAuthBase myOAuth = new OAuthBase();

			try {
				Uri uri = new Uri(txtURI.Text + postVariablesTextBox.Text);

				string consumerKey = txtConsKey.Text;
				string consumerSecret = txtConsSecret.Text;
				string token = txtToken.Text;
				string tokenSecret = txtTokenSecret.Text;
				string httpMethod = drpHTTPMethod.SelectedItem.ToString();
				string timeStamp = txtTimestamp.Text;
				string nonce = txtNonce.Text;

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

				string signature = myOAuth.GenerateSignature(uri, consumerKey, consumerSecret,
				                                             token, tokenSecret, httpMethod,
				                                             timeStamp, nonce, signatureType,
				                                             out normalizedUrl,
				                                             out normalizedRequestParameters);

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
				                                                txtTokenSecret.Text);
			} else {
				WebClient webClient = new WebClient();
				string response = webClient.DownloadString(txtGenURL.Text);
				responseText.Text = response;
			}

			txtConsoleOut.Text = _sb.ToString();
			_sb = new StringBuilder();
		}
	}
}