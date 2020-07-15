namespace Common.Network.Ssh.Sample
{
    partial class FormSshTest
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
            this.tBoxPassword = new System.Windows.Forms.TextBox();
            this.tBoxCommand = new System.Windows.Forms.TextBox();
            this.tBox = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnSshExt = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tBoxHostName = new System.Windows.Forms.TextBox();
            this.tBoxHostPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.tBoxHostUserID = new System.Windows.Forms.TextBox();
            this.grpHost = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grpHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBoxPassword
            // 
            this.tBoxPassword.Location = new System.Drawing.Point(12, 139);
            this.tBoxPassword.Name = "tBoxPassword";
            this.tBoxPassword.PasswordChar = '*';
            this.tBoxPassword.Size = new System.Drawing.Size(433, 19);
            this.tBoxPassword.TabIndex = 105;
            // 
            // tBoxCommand
            // 
            this.tBoxCommand.Location = new System.Drawing.Point(12, 109);
            this.tBoxCommand.Name = "tBoxCommand";
            this.tBoxCommand.Size = new System.Drawing.Size(433, 19);
            this.tBoxCommand.TabIndex = 103;
            // 
            // tBox
            // 
            this.tBox.Location = new System.Drawing.Point(12, 166);
            this.tBox.Name = "tBox";
            this.tBox.ReadOnly = true;
            this.tBox.Size = new System.Drawing.Size(703, 135);
            this.tBox.TabIndex = 107;
            this.tBox.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(642, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPass
            // 
            this.btnPass.Location = new System.Drawing.Point(451, 137);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(121, 23);
            this.btnPass.TabIndex = 106;
            this.btnPass.Text = "Send Password";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnSshExt
            // 
            this.btnSshExt.Location = new System.Drawing.Point(451, 107);
            this.btnSshExt.Name = "btnSshExt";
            this.btnSshExt.Size = new System.Drawing.Size(121, 23);
            this.btnSshExt.TabIndex = 104;
            this.btnSshExt.Text = "Send Command";
            this.btnSshExt.UseVisualStyleBackColor = true;
            this.btnSshExt.Click += new System.EventHandler(this.btnSshExt_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(451, 44);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 101;
            this.btnConnect.Text = "接続";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(6, 20);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(98, 12);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "ホスト名(IPアドレス)";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(54, 12);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // tBoxHostName
            // 
            this.tBoxHostName.Location = new System.Drawing.Point(110, 17);
            this.tBoxHostName.Name = "tBoxHostName";
            this.tBoxHostName.Size = new System.Drawing.Size(317, 19);
            this.tBoxHostName.TabIndex = 11;
            // 
            // tBoxHostPassword
            // 
            this.tBoxHostPassword.Location = new System.Drawing.Point(110, 65);
            this.tBoxHostPassword.Name = "tBoxHostPassword";
            this.tBoxHostPassword.PasswordChar = '*';
            this.tBoxHostPassword.Size = new System.Drawing.Size(317, 19);
            this.tBoxHostPassword.TabIndex = 13;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 43);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(44, 12);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "User ID";
            // 
            // tBoxHostUserID
            // 
            this.tBoxHostUserID.Location = new System.Drawing.Point(110, 40);
            this.tBoxHostUserID.Name = "tBoxHostUserID";
            this.tBoxHostUserID.Size = new System.Drawing.Size(317, 19);
            this.tBoxHostUserID.TabIndex = 12;
            // 
            // grpHost
            // 
            this.grpHost.Controls.Add(this.lblHost);
            this.grpHost.Controls.Add(this.lblPassword);
            this.grpHost.Controls.Add(this.tBoxHostName);
            this.grpHost.Controls.Add(this.tBoxHostPassword);
            this.grpHost.Controls.Add(this.lblUser);
            this.grpHost.Controls.Add(this.tBoxHostUserID);
            this.grpHost.Location = new System.Drawing.Point(12, 12);
            this.grpHost.Name = "grpHost";
            this.grpHost.Size = new System.Drawing.Size(433, 91);
            this.grpHost.TabIndex = 100;
            this.grpHost.TabStop = false;
            this.grpHost.Text = "接続先情報";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(451, 75);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 102;
            this.btnDisconnect.Text = "切断";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // FormSshTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 317);
            this.Controls.Add(this.tBoxPassword);
            this.Controls.Add(this.tBoxCommand);
            this.Controls.Add(this.tBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnSshExt);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.grpHost);
            this.Controls.Add(this.btnDisconnect);
            this.Name = "FormSshTest";
            this.Text = "FormSshTest";
            this.Load += new System.EventHandler(this.FormSshTest_Load);
            this.grpHost.ResumeLayout(false);
            this.grpHost.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxPassword;
        private System.Windows.Forms.TextBox tBoxCommand;
        private System.Windows.Forms.RichTextBox tBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnSshExt;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tBoxHostName;
        private System.Windows.Forms.TextBox tBoxHostPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tBoxHostUserID;
        private System.Windows.Forms.GroupBox grpHost;
        private System.Windows.Forms.Button btnDisconnect;
    }
}