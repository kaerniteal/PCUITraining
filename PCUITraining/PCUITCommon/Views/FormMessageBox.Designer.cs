namespace PCUITCommon.Views
{
    partial class FormMessageBox
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
            this.tableLayoutButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.tableLayoutButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblMessage, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(709, 313);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutButton
            // 
            this.tableLayoutButton.AutoSize = true;
            this.tableLayoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutButton.ColumnCount = 2;
            this.tableLayoutButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutButton.Controls.Add(this.btnOK, 0, 1);
            this.tableLayoutButton.Controls.Add(this.btnYes, 0, 0);
            this.tableLayoutButton.Controls.Add(this.btnNo, 1, 0);
            this.tableLayoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutButton.Location = new System.Drawing.Point(3, 67);
            this.tableLayoutButton.Name = "tableLayoutButton";
            this.tableLayoutButton.RowCount = 2;
            this.tableLayoutButton.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutButton.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutButton.Size = new System.Drawing.Size(703, 243);
            this.tableLayoutButton.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.BackColor = System.Drawing.Color.Black;
            this.tableLayoutButton.SetColumnSpan(this.btnOK, 2);
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnOK.Location = new System.Drawing.Point(3, 83);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(697, 157);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "おっけー";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnYes
            // 
            this.btnYes.AutoSize = true;
            this.btnYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYes.BackColor = System.Drawing.Color.Black;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYes.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnYes.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnYes.Location = new System.Drawing.Point(3, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(345, 74);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "はい";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.AutoSize = true;
            this.btnNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNo.BackColor = System.Drawing.Color.Black;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNo.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNo.ForeColor = System.Drawing.Color.Crimson;
            this.btnNo.Location = new System.Drawing.Point(354, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(346, 74);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "いいえ";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(3, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(703, 64);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "めっせーじ";
            // 
            // FormMessageBox
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(729, 333);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMessageBox";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMessageBox";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutButton.ResumeLayout(false);
            this.tableLayoutButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutButton;
        private System.Windows.Forms.Button btnOK;
    }
}