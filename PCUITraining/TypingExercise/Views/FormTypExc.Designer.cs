namespace TypingExercise.Views
{
    partial class FormTypExc
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
            this.lblWord = new System.Windows.Forms.Label();
            this.lblInputed = new System.Windows.Forms.Label();
            this.lblSpelling1 = new System.Windows.Forms.Label();
            this.lblSpelling4 = new System.Windows.Forms.Label();
            this.lblSpelling2 = new System.Windows.Forms.Label();
            this.lblSpelling3 = new System.Windows.Forms.Label();
            this.keyboardPanel1 = new TypingExercise.Views.KeyboardPanel();
            this.pPanel = new TypingExercise.Views.PicturePanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fingerPanel = new TypingExercise.Views.FingerPanel();
            this.lblMissTypes = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel.SetColumnSpan(this.lblWord, 5);
            this.lblWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWord.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblWord.ForeColor = System.Drawing.Color.White;
            this.lblWord.Location = new System.Drawing.Point(3, 0);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(569, 90);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "入力対象文字列";
            // 
            // lblInputed
            // 
            this.lblInputed.AutoSize = true;
            this.lblInputed.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel.SetColumnSpan(this.lblInputed, 5);
            this.lblInputed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputed.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInputed.ForeColor = System.Drawing.Color.Gold;
            this.lblInputed.Location = new System.Drawing.Point(3, 90);
            this.lblInputed.Name = "lblInputed";
            this.lblInputed.Size = new System.Drawing.Size(569, 90);
            this.lblInputed.TabIndex = 0;
            this.lblInputed.Text = "入力済み文字列";
            // 
            // lblSpelling1
            // 
            this.lblSpelling1.AutoSize = true;
            this.lblSpelling1.BackColor = System.Drawing.Color.Black;
            this.lblSpelling1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpelling1.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling1.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling1.Location = new System.Drawing.Point(3, 180);
            this.lblSpelling1.Name = "lblSpelling1";
            this.lblSpelling1.Size = new System.Drawing.Size(109, 157);
            this.lblSpelling1.TabIndex = 0;
            // 
            // lblSpelling4
            // 
            this.lblSpelling4.AutoSize = true;
            this.lblSpelling4.BackColor = System.Drawing.Color.Black;
            this.lblSpelling4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpelling4.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling4.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling4.Location = new System.Drawing.Point(348, 180);
            this.lblSpelling4.Name = "lblSpelling4";
            this.lblSpelling4.Size = new System.Drawing.Size(109, 157);
            this.lblSpelling4.TabIndex = 0;
            // 
            // lblSpelling2
            // 
            this.lblSpelling2.AutoSize = true;
            this.lblSpelling2.BackColor = System.Drawing.Color.Black;
            this.lblSpelling2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpelling2.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling2.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling2.Location = new System.Drawing.Point(118, 180);
            this.lblSpelling2.Name = "lblSpelling2";
            this.lblSpelling2.Size = new System.Drawing.Size(109, 157);
            this.lblSpelling2.TabIndex = 0;
            // 
            // lblSpelling3
            // 
            this.lblSpelling3.AutoSize = true;
            this.lblSpelling3.BackColor = System.Drawing.Color.Black;
            this.lblSpelling3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpelling3.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling3.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling3.Location = new System.Drawing.Point(233, 180);
            this.lblSpelling3.Name = "lblSpelling3";
            this.lblSpelling3.Size = new System.Drawing.Size(109, 157);
            this.lblSpelling3.TabIndex = 0;
            // 
            // keyboardPanel1
            // 
            this.keyboardPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.SetColumnSpan(this.keyboardPanel1, 5);
            this.keyboardPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardPanel1.Location = new System.Drawing.Point(3, 340);
            this.keyboardPanel1.Name = "keyboardPanel1";
            this.keyboardPanel1.Size = new System.Drawing.Size(569, 126);
            this.keyboardPanel1.TabIndex = 0;
            this.keyboardPanel1.TabStop = false;
            // 
            // pPanel
            // 
            this.pPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPanel.Location = new System.Drawing.Point(578, 3);
            this.pPanel.Name = "pPanel";
            this.tableLayoutPanel.SetRowSpan(this.pPanel, 5);
            this.pPanel.Size = new System.Drawing.Size(571, 653);
            this.pPanel.TabIndex = 999;
            this.pPanel.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.pPanel, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.lblSpelling1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lblInputed, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.keyboardPanel1, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.lblWord, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblSpelling2, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblSpelling3, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.lblSpelling4, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.fingerPanel, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.lblMissTypes, 4, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.6612F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.6612F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.9071F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.08197F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.68852F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1152, 659);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // fingerPanel
            // 
            this.fingerPanel.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel.SetColumnSpan(this.fingerPanel, 5);
            this.fingerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fingerPanel.Location = new System.Drawing.Point(3, 472);
            this.fingerPanel.Name = "fingerPanel";
            this.fingerPanel.Size = new System.Drawing.Size(569, 184);
            this.fingerPanel.TabIndex = 0;
            this.fingerPanel.TabStop = false;
            // 
            // lblMissTypes
            // 
            this.lblMissTypes.AutoSize = true;
            this.lblMissTypes.BackColor = System.Drawing.Color.DimGray;
            this.lblMissTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMissTypes.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMissTypes.ForeColor = System.Drawing.Color.Red;
            this.lblMissTypes.Location = new System.Drawing.Point(463, 180);
            this.lblMissTypes.Name = "lblMissTypes";
            this.lblMissTypes.Size = new System.Drawing.Size(109, 157);
            this.lblMissTypes.TabIndex = 1000;
            this.lblMissTypes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTypExc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1152, 659);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTypExc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "実行中";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormExec_KeyPress);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblInputed;
        private System.Windows.Forms.Label lblSpelling1;
        private PicturePanel pPanel;
        private System.Windows.Forms.Label lblSpelling4;
        private System.Windows.Forms.Label lblSpelling3;
        private System.Windows.Forms.Label lblSpelling2;
        private KeyboardPanel keyboardPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private FingerPanel fingerPanel;
        private System.Windows.Forms.Label lblMissTypes;
    }
}