namespace OAuthSig
{
    partial class Form1 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtURI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConsKey = new System.Windows.Forms.TextBox();
            this.txtConsSecret = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtTokenSecret = new System.Windows.Forms.TextBox();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.txtNonce = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.genSig = new System.Windows.Forms.Label();
            this.drpSigMethod = new System.Windows.Forms.ComboBox();
            this.chkVersion = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRawSig = new System.Windows.Forms.TextBox();
            this.txtEncodedSig = new System.Windows.Forms.TextBox();
            this.txtGenURL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.drpHTTPMethod = new System.Windows.Forms.ComboBox();
            this.responseText = new System.Windows.Forms.TextBox();
            this.makeRequestButton = new System.Windows.Forms.Button();
            this.postVariablesTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Response = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtConsoleOut = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Response.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(108, 35);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(377, 20);
            this.txtURI.TabIndex = 0;
            this.txtURI.Text = "http://api.7digital.com/1.2/status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consumer Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Consumer Secret:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Token:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Token Secret:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "HTTP Method:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Timestamp:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Nonce:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Signature Method:";
            // 
            // txtConsKey
            // 
            this.txtConsKey.Location = new System.Drawing.Point(108, 64);
            this.txtConsKey.Name = "txtConsKey";
            this.txtConsKey.Size = new System.Drawing.Size(227, 20);
            this.txtConsKey.TabIndex = 10;
            // 
            // txtConsSecret
            // 
            this.txtConsSecret.Location = new System.Drawing.Point(108, 91);
            this.txtConsSecret.Name = "txtConsSecret";
            this.txtConsSecret.Size = new System.Drawing.Size(227, 20);
            this.txtConsSecret.TabIndex = 11;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(108, 126);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(227, 20);
            this.txtToken.TabIndex = 12;
            // 
            // txtTokenSecret
            // 
            this.txtTokenSecret.Location = new System.Drawing.Point(108, 156);
            this.txtTokenSecret.Name = "txtTokenSecret";
            this.txtTokenSecret.Size = new System.Drawing.Size(227, 20);
            this.txtTokenSecret.TabIndex = 13;
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.Location = new System.Drawing.Point(108, 219);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.Size = new System.Drawing.Size(130, 20);
            this.txtTimestamp.TabIndex = 15;
            // 
            // txtNonce
            // 
            this.txtNonce.Location = new System.Drawing.Point(108, 245);
            this.txtNonce.Name = "txtNonce";
            this.txtNonce.Size = new System.Drawing.Size(227, 20);
            this.txtNonce.TabIndex = 16;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(173, 284);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(128, 23);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Generate Signature";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Raw Generated Signature:";
            // 
            // genSig
            // 
            this.genSig.AutoSize = true;
            this.genSig.Location = new System.Drawing.Point(194, 330);
            this.genSig.Name = "genSig";
            this.genSig.Size = new System.Drawing.Size(0, 13);
            this.genSig.TabIndex = 20;
            // 
            // drpSigMethod
            // 
            this.drpSigMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSigMethod.FormattingEnabled = true;
            this.drpSigMethod.Items.AddRange(new object[] {
            "HMAC-SHA1",
            "PLAINTEXT",
            "RSA-SHA1"});
            this.drpSigMethod.Location = new System.Drawing.Point(351, 192);
            this.drpSigMethod.Name = "drpSigMethod";
            this.drpSigMethod.Size = new System.Drawing.Size(121, 21);
            this.drpSigMethod.TabIndex = 22;
            // 
            // chkVersion
            // 
            this.chkVersion.AutoSize = true;
            this.chkVersion.Checked = true;
            this.chkVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVersion.Location = new System.Drawing.Point(137, 12);
            this.chkVersion.Name = "chkVersion";
            this.chkVersion.Size = new System.Drawing.Size(155, 17);
            this.chkVersion.TabIndex = 24;
            this.chkVersion.Text = "Include Version parameter?";
            this.chkVersion.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Encoded Generated Signature:";
            // 
            // txtRawSig
            // 
            this.txtRawSig.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtRawSig.Location = new System.Drawing.Point(190, 323);
            this.txtRawSig.Name = "txtRawSig";
            this.txtRawSig.ReadOnly = true;
            this.txtRawSig.Size = new System.Drawing.Size(317, 20);
            this.txtRawSig.TabIndex = 26;
            // 
            // txtEncodedSig
            // 
            this.txtEncodedSig.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtEncodedSig.Location = new System.Drawing.Point(190, 348);
            this.txtEncodedSig.Name = "txtEncodedSig";
            this.txtEncodedSig.ReadOnly = true;
            this.txtEncodedSig.Size = new System.Drawing.Size(317, 20);
            this.txtEncodedSig.TabIndex = 27;
            // 
            // txtGenURL
            // 
            this.txtGenURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenURL.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtGenURL.Location = new System.Drawing.Point(93, 378);
            this.txtGenURL.Multiline = true;
            this.txtGenURL.Name = "txtGenURL";
            this.txtGenURL.ReadOnly = true;
            this.txtGenURL.Size = new System.Drawing.Size(643, 62);
            this.txtGenURL.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 378);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Generated URL:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "(Leave blank to auto-generate)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(341, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "(Leave blank to auto-generate)";
            // 
            // drpHTTPMethod
            // 
            this.drpHTTPMethod.FormattingEnabled = true;
            this.drpHTTPMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE",
            "HEAD"});
            this.drpHTTPMethod.Location = new System.Drawing.Point(108, 192);
            this.drpHTTPMethod.Name = "drpHTTPMethod";
            this.drpHTTPMethod.Size = new System.Drawing.Size(121, 21);
            this.drpHTTPMethod.TabIndex = 32;
            // 
            // responseText
            // 
            this.responseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseText.Location = new System.Drawing.Point(3, 3);
            this.responseText.Multiline = true;
            this.responseText.Name = "responseText";
            this.responseText.Size = new System.Drawing.Size(715, 185);
            this.responseText.TabIndex = 33;
            // 
            // makeRequestButton
            // 
            this.makeRequestButton.Location = new System.Drawing.Point(93, 456);
            this.makeRequestButton.Name = "makeRequestButton";
            this.makeRequestButton.Size = new System.Drawing.Size(178, 23);
            this.makeRequestButton.TabIndex = 34;
            this.makeRequestButton.Text = "Send Request";
            this.makeRequestButton.UseVisualStyleBackColor = true;
            this.makeRequestButton.Click += new System.EventHandler(this.makeRequestButton_Click);
            // 
            // postVariablesTextBox
            // 
            this.postVariablesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.postVariablesTextBox.Location = new System.Drawing.Point(93, 511);
            this.postVariablesTextBox.Name = "postVariablesTextBox";
            this.postVariablesTextBox.Size = new System.Drawing.Size(643, 20);
            this.postVariablesTextBox.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1, 495);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Form Variables (POST)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Response);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 537);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 217);
            this.tabControl1.TabIndex = 37;
            // 
            // Response
            // 
            this.Response.Controls.Add(this.responseText);
            this.Response.Location = new System.Drawing.Point(4, 22);
            this.Response.Name = "Response";
            this.Response.Padding = new System.Windows.Forms.Padding(3);
            this.Response.Size = new System.Drawing.Size(721, 191);
            this.Response.TabIndex = 0;
            this.Response.Text = "Response";
            this.Response.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtConsoleOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 191);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Console.Writeline";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtConsoleOut
            // 
            this.txtConsoleOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsoleOut.Location = new System.Drawing.Point(3, 3);
            this.txtConsoleOut.Multiline = true;
            this.txtConsoleOut.Name = "txtConsoleOut";
            this.txtConsoleOut.Size = new System.Drawing.Size(979, 185);
            this.txtConsoleOut.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(134, 495);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(345, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Enter as key value pairs seperated by &&. Eg : var1=value1&&var2=value2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 764);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.postVariablesTextBox);
            this.Controls.Add(this.makeRequestButton);
            this.Controls.Add(this.drpHTTPMethod);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtGenURL);
            this.Controls.Add(this.txtEncodedSig);
            this.Controls.Add(this.txtRawSig);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkVersion);
            this.Controls.Add(this.drpSigMethod);
            this.Controls.Add(this.genSig);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtNonce);
            this.Controls.Add(this.txtTimestamp);
            this.Controls.Add(this.txtTokenSecret);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtConsSecret);
            this.Controls.Add(this.txtConsKey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURI);
            this.Name = "Form1";
            this.Text = "OAuth Signature Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Response.ResumeLayout(false);
            this.Response.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtConsKey;
        private System.Windows.Forms.TextBox txtConsSecret;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtTokenSecret;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.TextBox txtNonce;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label genSig;
        private System.Windows.Forms.ComboBox drpSigMethod;
        private System.Windows.Forms.CheckBox chkVersion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRawSig;
        private System.Windows.Forms.TextBox txtEncodedSig;
        private System.Windows.Forms.TextBox txtGenURL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox drpHTTPMethod;
		private System.Windows.Forms.TextBox responseText;
		private System.Windows.Forms.Button makeRequestButton;
		private System.Windows.Forms.TextBox postVariablesTextBox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage Response;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtConsoleOut;
        private System.Windows.Forms.Label label16;
    }
}

