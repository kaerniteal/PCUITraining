using Common.WinForms;

namespace PCUITraining.Forms
{
    partial class FormMainDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainDebug));
            this.btnPokeMonTyping = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.btnTest3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mPanel = new TextInputExercise.Views.MarqueePanel();
            this.lBox2 = new PictureBoxTransparentLayered();
            this.lBox1 = new PictureBoxTransparentLayered();
            this.lBox3 = new PictureBoxTransparentLayered();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPokeMonTyping
            // 
            this.btnPokeMonTyping.Location = new System.Drawing.Point(12, 12);
            this.btnPokeMonTyping.Name = "btnPokeMonTyping";
            this.btnPokeMonTyping.Size = new System.Drawing.Size(142, 23);
            this.btnPokeMonTyping.TabIndex = 0;
            this.btnPokeMonTyping.Text = "PokeMonTyping";
            this.btnPokeMonTyping.UseVisualStyleBackColor = true;
            this.btnPokeMonTyping.Click += new System.EventHandler(this.btnPokeMonTyping_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(592, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(12, 41);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(142, 23);
            this.btnTest1.TabIndex = 0;
            this.btnTest1.Text = "Test1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(13, 71);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(141, 23);
            this.btnTest2.TabIndex = 3;
            this.btnTest2.Text = "Test2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnTest3
            // 
            this.btnTest3.Location = new System.Drawing.Point(13, 100);
            this.btnTest3.Name = "btnTest3";
            this.btnTest3.Size = new System.Drawing.Size(141, 23);
            this.btnTest3.TabIndex = 3;
            this.btnTest3.Text = "Test3";
            this.btnTest3.UseVisualStyleBackColor = true;
            this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mPanel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 245);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 100);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // mPanel
            // 
            this.mPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPanel.BackColor = System.Drawing.Color.Silver;
            this.mPanel.Location = new System.Drawing.Point(3, 3);
            this.mPanel.Name = "mPanel";
            this.mPanel.Size = new System.Drawing.Size(648, 94);
            this.mPanel.TabIndex = 0;
            this.mPanel.TabStop = false;
            // 
            // lBox2
            // 
            this.lBox2.BackColor = System.Drawing.Color.Transparent;
            this.lBox2.Image = ((System.Drawing.Image)(resources.GetObject("lBox2.Image")));
            this.lBox2.Location = new System.Drawing.Point(261, 135);
            this.lBox2.Name = "lBox2";
            this.lBox2.Size = new System.Drawing.Size(100, 50);
            this.lBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lBox2.TabIndex = 5;
            this.lBox2.TabStop = false;
            // 
            // lBox1
            // 
            this.lBox1.BackColor = System.Drawing.Color.Transparent;
            this.lBox1.Image = ((System.Drawing.Image)(resources.GetObject("lBox1.Image")));
            this.lBox1.Location = new System.Drawing.Point(252, 127);
            this.lBox1.Name = "lBox1";
            this.lBox1.Size = new System.Drawing.Size(100, 50);
            this.lBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lBox1.TabIndex = 5;
            this.lBox1.TabStop = false;
            // 
            // lBox3
            // 
            this.lBox3.BackColor = System.Drawing.Color.Transparent;
            this.lBox3.Image = ((System.Drawing.Image)(resources.GetObject("lBox3.Image")));
            this.lBox3.Location = new System.Drawing.Point(235, 113);
            this.lBox3.Name = "lBox3";
            this.lBox3.Size = new System.Drawing.Size(100, 50);
            this.lBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lBox3.TabIndex = 5;
            this.lBox3.TabStop = false;
            // 
            // FormMainDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(679, 429);
            this.Controls.Add(this.lBox3);
            this.Controls.Add(this.lBox2);
            this.Controls.Add(this.lBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnTest3);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.btnPokeMonTyping);
            this.Name = "FormMainDebug";
            this.Text = "FormMainDebug";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPokeMonTyping;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.Button btnTest3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TextInputExercise.Views.MarqueePanel mPanel;
        private PictureBoxTransparentLayered lBox1;
        private PictureBoxTransparentLayered lBox2;
        private PictureBoxTransparentLayered lBox3;
    }
}