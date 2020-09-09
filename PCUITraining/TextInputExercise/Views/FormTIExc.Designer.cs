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
            this.rtBoxText = new System.Windows.Forms.RichTextBox();
            this.tBpxText = new System.Windows.Forms.TextBox();
            this.lblYomi = new System.Windows.Forms.Label();
            this.mPanel = new TextInputExercise.Views.MarqueePanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.rtBoxText, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.tBpxText, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblYomi, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.mPanel, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel.TabIndex = 0;
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
            this.rtBoxText.Size = new System.Drawing.Size(794, 84);
            this.rtBoxText.TabIndex = 1;
            this.rtBoxText.Text = "";
            this.rtBoxText.TextChanged += new System.EventHandler(this.rtBoxText_TextChanged);
            this.rtBoxText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtBoxText_KeyPress);
            // 
            // tBpxText
            // 
            this.tBpxText.BackColor = System.Drawing.Color.Black;
            this.tBpxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBpxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBpxText.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 60F);
            this.tBpxText.ForeColor = System.Drawing.Color.White;
            this.tBpxText.HideSelection = false;
            this.tBpxText.Location = new System.Drawing.Point(3, 3);
            this.tBpxText.Multiline = true;
            this.tBpxText.Name = "tBpxText";
            this.tBpxText.ReadOnly = true;
            this.tBpxText.Size = new System.Drawing.Size(794, 84);
            this.tBpxText.TabIndex = 0;
            this.tBpxText.TabStop = false;
            this.tBpxText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tBpxText_MouseUp);
            // 
            // lblYomi
            // 
            this.lblYomi.AutoSize = true;
            this.lblYomi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYomi.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYomi.ForeColor = System.Drawing.Color.HotPink;
            this.lblYomi.Location = new System.Drawing.Point(3, 90);
            this.lblYomi.Name = "lblYomi";
            this.lblYomi.Size = new System.Drawing.Size(794, 45);
            this.lblYomi.TabIndex = 2;
            // 
            // mPanel
            // 
            this.mPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanel.Location = new System.Drawing.Point(3, 228);
            this.mPanel.Name = "mPanel";
            this.tableLayoutPanel.SetRowSpan(this.mPanel, 2);
            this.mPanel.Size = new System.Drawing.Size(794, 219);
            this.mPanel.TabIndex = 3;
            this.mPanel.TabStop = false;
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTIExc_FormClosed);
            this.Load += new System.EventHandler(this.FormTIExc_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.RichTextBox rtBoxText;
        private System.Windows.Forms.TextBox tBpxText;
        private System.Windows.Forms.Label lblYomi;
        private MarqueePanel mPanel;
    }
}