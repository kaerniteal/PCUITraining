namespace TypingExercise.Forms
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
            this.TypingPanel = new System.Windows.Forms.Panel();
            this.tableLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSpelling4 = new System.Windows.Forms.Label();
            this.lblSpelling2 = new System.Windows.Forms.Label();
            this.lblSpelling3 = new System.Windows.Forms.Label();
            this.keyboardPanel1 = new TypingExercise.Forms.KeyboardPanel();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pPanel = new TypingExercise.Forms.PicturePanel();
            this.TypingPanel.SuspendLayout();
            this.tableLeft.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWord
            // 
            this.lblWord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWord.AutoSize = true;
            this.lblWord.BackColor = System.Drawing.Color.Black;
            this.lblWord.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblWord.ForeColor = System.Drawing.Color.White;
            this.lblWord.Location = new System.Drawing.Point(3, 0);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(552, 120);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "入力対象文字列";
            // 
            // lblInputed
            // 
            this.lblInputed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputed.AutoSize = true;
            this.lblInputed.BackColor = System.Drawing.Color.Black;
            this.lblInputed.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInputed.ForeColor = System.Drawing.Color.Gold;
            this.lblInputed.Location = new System.Drawing.Point(3, 120);
            this.lblInputed.Name = "lblInputed";
            this.lblInputed.Size = new System.Drawing.Size(552, 120);
            this.lblInputed.TabIndex = 0;
            this.lblInputed.Text = "入力済み文字列";
            // 
            // lblSpelling1
            // 
            this.lblSpelling1.AutoSize = true;
            this.lblSpelling1.BackColor = System.Drawing.Color.Black;
            this.lblSpelling1.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling1.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling1.Location = new System.Drawing.Point(3, 0);
            this.lblSpelling1.Name = "lblSpelling1";
            this.lblSpelling1.Size = new System.Drawing.Size(0, 48);
            this.lblSpelling1.TabIndex = 0;
            // 
            // TypingPanel
            // 
            this.TypingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypingPanel.Controls.Add(this.tableLeft);
            this.TypingPanel.Location = new System.Drawing.Point(3, 3);
            this.TypingPanel.Name = "TypingPanel";
            this.TypingPanel.Size = new System.Drawing.Size(558, 629);
            this.TypingPanel.TabIndex = 2;
            // 
            // tableLeft
            // 
            this.tableLeft.ColumnCount = 1;
            this.tableLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeft.Controls.Add(this.lblWord, 0, 0);
            this.tableLeft.Controls.Add(this.lblInputed, 0, 1);
            this.tableLeft.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLeft.Controls.Add(this.keyboardPanel1, 0, 3);
            this.tableLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLeft.Name = "tableLeft";
            this.tableLeft.RowCount = 5;
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLeft.Size = new System.Drawing.Size(558, 629);
            this.tableLeft.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.lblSpelling1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSpelling4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSpelling2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSpelling3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 243);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(552, 294);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblSpelling4
            // 
            this.lblSpelling4.AutoSize = true;
            this.lblSpelling4.BackColor = System.Drawing.Color.Black;
            this.lblSpelling4.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling4.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling4.Location = new System.Drawing.Point(417, 0);
            this.lblSpelling4.Name = "lblSpelling4";
            this.lblSpelling4.Size = new System.Drawing.Size(0, 48);
            this.lblSpelling4.TabIndex = 0;
            // 
            // lblSpelling2
            // 
            this.lblSpelling2.AutoSize = true;
            this.lblSpelling2.BackColor = System.Drawing.Color.Black;
            this.lblSpelling2.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling2.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling2.Location = new System.Drawing.Point(141, 0);
            this.lblSpelling2.Name = "lblSpelling2";
            this.lblSpelling2.Size = new System.Drawing.Size(0, 48);
            this.lblSpelling2.TabIndex = 0;
            // 
            // lblSpelling3
            // 
            this.lblSpelling3.AutoSize = true;
            this.lblSpelling3.BackColor = System.Drawing.Color.Black;
            this.lblSpelling3.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSpelling3.ForeColor = System.Drawing.Color.HotPink;
            this.lblSpelling3.Location = new System.Drawing.Point(279, 0);
            this.lblSpelling3.Name = "lblSpelling3";
            this.lblSpelling3.Size = new System.Drawing.Size(0, 48);
            this.lblSpelling3.TabIndex = 0;
            // 
            // keyboardPanel1
            // 
            this.keyboardPanel1.BackColor = System.Drawing.Color.Transparent;
            this.keyboardPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardPanel1.Location = new System.Drawing.Point(3, 543);
            this.keyboardPanel1.Name = "keyboardPanel1";
            this.keyboardPanel1.Size = new System.Drawing.Size(552, 234);
            this.keyboardPanel1.TabIndex = 2;
            this.keyboardPanel1.TabStop = false;
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Controls.Add(this.TypingPanel, 0, 0);
            this.LayoutPanel.Controls.Add(this.pPanel, 1, 0);
            this.LayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Size = new System.Drawing.Size(1128, 635);
            this.LayoutPanel.TabIndex = 3;
            // 
            // pPanel
            // 
            this.pPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPanel.Location = new System.Drawing.Point(567, 3);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(558, 629);
            this.pPanel.TabIndex = 999;
            this.pPanel.TabStop = false;
            // 
            // FormTypExc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1152, 659);
            this.Controls.Add(this.LayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTypExc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "実行中";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormExec_KeyPress);
            this.TypingPanel.ResumeLayout(false);
            this.tableLeft.ResumeLayout(false);
            this.tableLeft.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.LayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblInputed;
        private System.Windows.Forms.Label lblSpelling1;
        private System.Windows.Forms.Panel TypingPanel;
        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private PicturePanel pPanel;
        private System.Windows.Forms.Label lblSpelling4;
        private System.Windows.Forms.Label lblSpelling3;
        private System.Windows.Forms.Label lblSpelling2;
        private System.Windows.Forms.TableLayoutPanel tableLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private KeyboardPanel keyboardPanel1;
    }
}