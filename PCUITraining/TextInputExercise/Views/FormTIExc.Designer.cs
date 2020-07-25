namespace TextInputExercise.Views
{
    partial class FormTIExc
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
            this.lblText = new System.Windows.Forms.Label();
            this.rtBoxText = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.lblText, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.rtBoxText, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel.SetColumnSpan(this.lblText, 5);
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(3, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(794, 135);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "入力対象文字列";
            // 
            // rtBoxText
            // 
            this.rtBoxText.BackColor = System.Drawing.Color.DimGray;
            this.rtBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtBoxText.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rtBoxText.ForeColor = System.Drawing.Color.Aqua;
            this.rtBoxText.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.rtBoxText.Location = new System.Drawing.Point(3, 138);
            this.rtBoxText.Name = "rtBoxText";
            this.rtBoxText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtBoxText.Size = new System.Drawing.Size(794, 129);
            this.rtBoxText.TabIndex = 1;
            this.rtBoxText.Text = "ここに入力";
            this.rtBoxText.TextChanged += new System.EventHandler(this.rtBoxText_TextChanged);
            this.rtBoxText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtBoxText_KeyPress);
            // 
            // FormTIExc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTIExc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormTIExc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTIExc_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.RichTextBox rtBoxText;
    }
}