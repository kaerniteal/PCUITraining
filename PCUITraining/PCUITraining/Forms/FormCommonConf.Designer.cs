namespace PCUITraining.Forms
{
    partial class FormCommonConf
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tBoxID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProxy = new System.Windows.Forms.Label();
            this.lbliD = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.bLblProxyUse = new PCUITCommon.Views.BoolLabel();
            this.tBoxPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.tBoxID, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnSave, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.btnCancel, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.lblProxy, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lbliD, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblPassword, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.bLblProxyUse, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tBoxPassword, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(878, 369);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tBoxID
            // 
            this.tBoxID.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel.SetColumnSpan(this.tBoxID, 2);
            this.tBoxID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxID.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.tBoxID.ForeColor = System.Drawing.Color.Aqua;
            this.tBoxID.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tBoxID.Location = new System.Drawing.Point(354, 95);
            this.tBoxID.Name = "tBoxID";
            this.tBoxID.Size = new System.Drawing.Size(521, 71);
            this.tBoxID.TabIndex = 108;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(3, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(432, 87);
            this.btnSave.TabIndex = 104;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(441, 279);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(434, 87);
            this.btnCancel.TabIndex = 105;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblProxy
            // 
            this.lblProxy.AutoSize = true;
            this.lblProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProxy.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProxy.ForeColor = System.Drawing.Color.Yellow;
            this.lblProxy.Location = new System.Drawing.Point(3, 0);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(345, 92);
            this.lblProxy.TabIndex = 106;
            this.lblProxy.Text = "Proxyの使用";
            this.lblProxy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbliD
            // 
            this.lbliD.AutoSize = true;
            this.lbliD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbliD.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbliD.ForeColor = System.Drawing.Color.Yellow;
            this.lbliD.Location = new System.Drawing.Point(3, 92);
            this.lbliD.Name = "lbliD";
            this.lbliD.Size = new System.Drawing.Size(345, 92);
            this.lbliD.TabIndex = 106;
            this.lbliD.Text = "ProxyのID";
            this.lbliD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPassword.ForeColor = System.Drawing.Color.Yellow;
            this.lblPassword.Location = new System.Drawing.Point(3, 184);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(345, 92);
            this.lblPassword.TabIndex = 106;
            this.lblPassword.Text = "Proxyのパスワード";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bLblProxyUse
            // 
            this.bLblProxyUse.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.bLblProxyUse, 2);
            this.bLblProxyUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblProxyUse.FalseColor = System.Drawing.Color.Red;
            this.bLblProxyUse.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.bLblProxyUse.ForeColor = System.Drawing.Color.Red;
            this.bLblProxyUse.Location = new System.Drawing.Point(354, 0);
            this.bLblProxyUse.Name = "bLblProxyUse";
            this.bLblProxyUse.Size = new System.Drawing.Size(521, 92);
            this.bLblProxyUse.TabIndex = 107;
            this.bLblProxyUse.Text = "しない";
            this.bLblProxyUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bLblProxyUse.TrueColor = System.Drawing.Color.Aqua;
            // 
            // tBoxPassword
            // 
            this.tBoxPassword.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel.SetColumnSpan(this.tBoxPassword, 2);
            this.tBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxPassword.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.tBoxPassword.ForeColor = System.Drawing.Color.Aqua;
            this.tBoxPassword.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tBoxPassword.Location = new System.Drawing.Point(354, 187);
            this.tBoxPassword.Name = "tBoxPassword";
            this.tBoxPassword.PasswordChar = '*';
            this.tBoxPassword.Size = new System.Drawing.Size(521, 71);
            this.tBoxPassword.TabIndex = 108;
            // 
            // FormCommonConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(878, 369);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCommonConf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormCommonConf";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.Label lbliD;
        private System.Windows.Forms.Label lblPassword;
        private PCUITCommon.Views.BoolLabel bLblProxyUse;
        private System.Windows.Forms.TextBox tBoxID;
        private System.Windows.Forms.TextBox tBoxPassword;
    }
}