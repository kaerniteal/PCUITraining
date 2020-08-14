namespace PCUITraining.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPokeMonTyping = new System.Windows.Forms.Button();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnPokeMonTypingDataView = new System.Windows.Forms.Button();
            this.btnPokeMonTypingReciprocate = new System.Windows.Forms.Button();
            this.userSelector = new PCUITCommon.Views.UserSelector();
            this.pBoxConfig = new System.Windows.Forms.PictureBox();
            this.btnInsectCollecting = new System.Windows.Forms.Button();
            this.btnAniTtlWriting = new System.Windows.Forms.Button();
            this.btnAniTtlWritingDataView = new System.Windows.Forms.Button();
            this.btnInsectCollectingDataView = new System.Windows.Forms.Button();
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableMain.SetColumnSpan(this.btnClose, 3);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(97, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(746, 76);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "やめる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPokeMonTyping
            // 
            this.btnPokeMonTyping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPokeMonTyping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPokeMonTyping.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokeMonTyping.ForeColor = System.Drawing.Color.Yellow;
            this.btnPokeMonTyping.Location = new System.Drawing.Point(97, 105);
            this.btnPokeMonTyping.Name = "btnPokeMonTyping";
            this.btnPokeMonTyping.Size = new System.Drawing.Size(558, 90);
            this.btnPokeMonTyping.TabIndex = 1;
            this.btnPokeMonTyping.Text = "ポケモンタイピング！";
            this.btnPokeMonTyping.UseVisualStyleBackColor = false;
            this.btnPokeMonTyping.Click += new System.EventHandler(this.btnPokeMonTyping_Click);
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 5;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.Controls.Add(this.btnPokeMonTyping, 1, 1);
            this.tableMain.Controls.Add(this.btnClose, 1, 5);
            this.tableMain.Controls.Add(this.btnPokeMonTypingDataView, 2, 1);
            this.tableMain.Controls.Add(this.btnPokeMonTypingReciprocate, 3, 1);
            this.tableMain.Controls.Add(this.userSelector, 1, 0);
            this.tableMain.Controls.Add(this.pBoxConfig, 3, 0);
            this.tableMain.Controls.Add(this.btnInsectCollecting, 1, 2);
            this.tableMain.Controls.Add(this.btnAniTtlWriting, 1, 3);
            this.tableMain.Controls.Add(this.btnAniTtlWritingDataView, 3, 3);
            this.tableMain.Controls.Add(this.btnInsectCollectingDataView, 3, 2);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 6;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableMain.Size = new System.Drawing.Size(940, 568);
            this.tableMain.TabIndex = 1;
            // 
            // btnPokeMonTypingDataView
            // 
            this.btnPokeMonTypingDataView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPokeMonTypingDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPokeMonTypingDataView.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokeMonTypingDataView.ForeColor = System.Drawing.Color.Yellow;
            this.btnPokeMonTypingDataView.Image = ((System.Drawing.Image)(resources.GetObject("btnPokeMonTypingDataView.Image")));
            this.btnPokeMonTypingDataView.Location = new System.Drawing.Point(661, 105);
            this.btnPokeMonTypingDataView.Name = "btnPokeMonTypingDataView";
            this.btnPokeMonTypingDataView.Size = new System.Drawing.Size(88, 90);
            this.btnPokeMonTypingDataView.TabIndex = 2;
            this.btnPokeMonTypingDataView.UseVisualStyleBackColor = false;
            this.btnPokeMonTypingDataView.Click += new System.EventHandler(this.btnPokeMonTypingDataView_Click);
            // 
            // btnPokeMonTypingReciprocate
            // 
            this.btnPokeMonTypingReciprocate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPokeMonTypingReciprocate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPokeMonTypingReciprocate.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F);
            this.btnPokeMonTypingReciprocate.ForeColor = System.Drawing.Color.Yellow;
            this.btnPokeMonTypingReciprocate.Location = new System.Drawing.Point(755, 105);
            this.btnPokeMonTypingReciprocate.Name = "btnPokeMonTypingReciprocate";
            this.btnPokeMonTypingReciprocate.Size = new System.Drawing.Size(88, 90);
            this.btnPokeMonTypingReciprocate.TabIndex = 101;
            this.btnPokeMonTypingReciprocate.Text = "⇔";
            this.btnPokeMonTypingReciprocate.UseVisualStyleBackColor = false;
            this.btnPokeMonTypingReciprocate.Click += new System.EventHandler(this.btnPokeMonTypingReciprocate_Click);
            // 
            // userSelector
            // 
            this.userSelector.BackColor = System.Drawing.Color.Transparent;
            this.tableMain.SetColumnSpan(this.userSelector, 2);
            this.userSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector.Location = new System.Drawing.Point(97, 3);
            this.userSelector.Name = "userSelector";
            this.userSelector.Size = new System.Drawing.Size(652, 96);
            this.userSelector.TabIndex = 102;
            // 
            // pBoxConfig
            // 
            this.pBoxConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxConfig.Image = ((System.Drawing.Image)(resources.GetObject("pBoxConfig.Image")));
            this.pBoxConfig.Location = new System.Drawing.Point(755, 3);
            this.pBoxConfig.Name = "pBoxConfig";
            this.pBoxConfig.Size = new System.Drawing.Size(88, 96);
            this.pBoxConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxConfig.TabIndex = 103;
            this.pBoxConfig.TabStop = false;
            this.pBoxConfig.Click += new System.EventHandler(this.pBoxConfig_Click);
            // 
            // btnInsectCollecting
            // 
            this.btnInsectCollecting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableMain.SetColumnSpan(this.btnInsectCollecting, 2);
            this.btnInsectCollecting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsectCollecting.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsectCollecting.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnInsectCollecting.Location = new System.Drawing.Point(97, 201);
            this.btnInsectCollecting.Name = "btnInsectCollecting";
            this.btnInsectCollecting.Size = new System.Drawing.Size(652, 90);
            this.btnInsectCollecting.TabIndex = 1;
            this.btnInsectCollecting.Text = "マウスで昆虫採集";
            this.btnInsectCollecting.UseVisualStyleBackColor = false;
            this.btnInsectCollecting.Click += new System.EventHandler(this.btnInsectCollecting_Click);
            // 
            // btnAniTtlWriting
            // 
            this.btnAniTtlWriting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableMain.SetColumnSpan(this.btnAniTtlWriting, 2);
            this.btnAniTtlWriting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAniTtlWriting.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniTtlWriting.ForeColor = System.Drawing.Color.Aqua;
            this.btnAniTtlWriting.Location = new System.Drawing.Point(97, 297);
            this.btnAniTtlWriting.Name = "btnAniTtlWriting";
            this.btnAniTtlWriting.Size = new System.Drawing.Size(652, 90);
            this.btnAniTtlWriting.TabIndex = 1;
            this.btnAniTtlWriting.Text = "アニタイライティング！";
            this.btnAniTtlWriting.UseVisualStyleBackColor = false;
            this.btnAniTtlWriting.Click += new System.EventHandler(this.btnAniTtlWriting_Click);
            // 
            // btnAniTtlWritingDataView
            // 
            this.btnAniTtlWritingDataView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAniTtlWritingDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAniTtlWritingDataView.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniTtlWritingDataView.ForeColor = System.Drawing.Color.Yellow;
            this.btnAniTtlWritingDataView.Image = ((System.Drawing.Image)(resources.GetObject("btnAniTtlWritingDataView.Image")));
            this.btnAniTtlWritingDataView.Location = new System.Drawing.Point(755, 297);
            this.btnAniTtlWritingDataView.Name = "btnAniTtlWritingDataView";
            this.btnAniTtlWritingDataView.Size = new System.Drawing.Size(88, 90);
            this.btnAniTtlWritingDataView.TabIndex = 2;
            this.btnAniTtlWritingDataView.UseVisualStyleBackColor = false;
            this.btnAniTtlWritingDataView.Click += new System.EventHandler(this.btnAniTtlWritingDataView_Click);
            // 
            // btnInsectCollectingDataView
            // 
            this.btnInsectCollectingDataView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInsectCollectingDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsectCollectingDataView.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsectCollectingDataView.ForeColor = System.Drawing.Color.Yellow;
            this.btnInsectCollectingDataView.Image = ((System.Drawing.Image)(resources.GetObject("btnInsectCollectingDataView.Image")));
            this.btnInsectCollectingDataView.Location = new System.Drawing.Point(755, 201);
            this.btnInsectCollectingDataView.Name = "btnInsectCollectingDataView";
            this.btnInsectCollectingDataView.Size = new System.Drawing.Size(88, 90);
            this.btnInsectCollectingDataView.TabIndex = 2;
            this.btnInsectCollectingDataView.UseVisualStyleBackColor = false;
            this.btnInsectCollectingDataView.Click += new System.EventHandler(this.btnInsectCollectingDataView_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(940, 568);
            this.Controls.Add(this.tableMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCUIT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPokeMonTyping;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Button btnPokeMonTypingDataView;
        private System.Windows.Forms.Button btnPokeMonTypingReciprocate;
        private PCUITCommon.Views.UserSelector userSelector;
        private System.Windows.Forms.PictureBox pBoxConfig;
        private System.Windows.Forms.Button btnInsectCollecting;
        private System.Windows.Forms.Button btnAniTtlWriting;
        private System.Windows.Forms.Button btnAniTtlWritingDataView;
        private System.Windows.Forms.Button btnInsectCollectingDataView;
    }
}