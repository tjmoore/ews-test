namespace ews_test
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonAutoDiscover = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxAllowHttp = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowSCP = new System.Windows.Forms.CheckBox();
            this.comboBoxExchangeVersion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(112, 6);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(273, 20);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.TextBoxEmail_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email Address:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.Color.White;
            this.textBoxLog.Location = new System.Drawing.Point(13, 115);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(829, 308);
            this.textBoxLog.TabIndex = 7;
            this.textBoxLog.WordWrap = false;
            // 
            // buttonAutoDiscover
            // 
            this.buttonAutoDiscover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoDiscover.Location = new System.Drawing.Point(735, 86);
            this.buttonAutoDiscover.Name = "buttonAutoDiscover";
            this.buttonAutoDiscover.Size = new System.Drawing.Size(107, 23);
            this.buttonAutoDiscover.TabIndex = 6;
            this.buttonAutoDiscover.Text = "&Auto Discover";
            this.buttonAutoDiscover.UseVisualStyleBackColor = true;
            this.buttonAutoDiscover.Click += new System.EventHandler(this.ButtonAutoDiscover_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(112, 58);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(273, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // checkBoxAllowHttp
            // 
            this.checkBoxAllowHttp.AutoSize = true;
            this.checkBoxAllowHttp.Location = new System.Drawing.Point(394, 35);
            this.checkBoxAllowHttp.Name = "checkBoxAllowHttp";
            this.checkBoxAllowHttp.Size = new System.Drawing.Size(113, 17);
            this.checkBoxAllowHttp.TabIndex = 4;
            this.checkBoxAllowHttp.Text = "Allow HTTP URLs";
            this.checkBoxAllowHttp.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowSCP
            // 
            this.checkBoxAllowSCP.AutoSize = true;
            this.checkBoxAllowSCP.Location = new System.Drawing.Point(394, 58);
            this.checkBoxAllowSCP.Name = "checkBoxAllowSCP";
            this.checkBoxAllowSCP.Size = new System.Drawing.Size(179, 17);
            this.checkBoxAllowSCP.TabIndex = 5;
            this.checkBoxAllowSCP.Text = "Allow SCP Lookup (on-premises)";
            this.checkBoxAllowSCP.UseVisualStyleBackColor = true;
            // 
            // comboBoxExchangeVersion
            // 
            this.comboBoxExchangeVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExchangeVersion.FormattingEnabled = true;
            this.comboBoxExchangeVersion.ItemHeight = 13;
            this.comboBoxExchangeVersion.Location = new System.Drawing.Point(495, 5);
            this.comboBoxExchangeVersion.Name = "comboBoxExchangeVersion";
            this.comboBoxExchangeVersion.Size = new System.Drawing.Size(175, 21);
            this.comboBoxExchangeVersion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Exchange Version:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(112, 32);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(273, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username (optional):";
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonAutoDiscover;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 435);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxExchangeVersion);
            this.Controls.Add(this.checkBoxAllowSCP);
            this.Controls.Add(this.checkBoxAllowHttp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonAutoDiscover);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.MinimumSize = new System.Drawing.Size(697, 400);
            this.Name = "Form1";
            this.Text = "EWS Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonAutoDiscover;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAllowHttp;
        private System.Windows.Forms.CheckBox checkBoxAllowSCP;
        private System.Windows.Forms.ComboBox comboBoxExchangeVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label4;
    }
}

