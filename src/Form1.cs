using System;
using System.Text;
using System.Windows.Forms;

namespace SevenDigital.Api.OAuthConsole.UI
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
		

			new OAuthSignatureBuilder(this).GenerateSignature();
		}

	    private void makeRequestButton_Click(object sender, EventArgs e)
	    {
	        
			txtConsoleOut.Text = String.Empty;
			_sb = new StringBuilder();
	        new OAuthRequest(this).Request();
	    }

	    public void Log()
	    {
	        txtConsoleOut.Text = _sb.ToString();
	    }

	    public void DisplayResponse(string response)
	    {
	        responseText.Text = response;
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

	    public string RawSignature
	    {
            get { return txtRawSig.Text; }
	        set { txtRawSig.Text = value; }
	    }

	    public bool IncludeVersion
	    {
            get { return chkVersion.Checked; }
	    }

	    public string EncodedSignature
	    {
            get { return txtEncodedSig.Text; }
	        set { txtEncodedSig.Text = value; }
	    }

	    public string GeneratedUrl
	    {
            get { return txtGenURL.Text; }
	        set { txtGenURL.Text = value;}
	    }

	    public string PostData
	    {
            get { return postVariablesTextBox.Text; }
	    }

	    public int SignatureMethod
	    {
            get { return drpSigMethod.SelectedIndex; }
	    }
	}
}