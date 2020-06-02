namespace PCUITraining
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetImageFromGoogle = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetImageFromGoogle
            // 
            this.btnGetImageFromGoogle.Location = new System.Drawing.Point(13, 37);
            this.btnGetImageFromGoogle.Name = "btnGetImageFromGoogle";
            this.btnGetImageFromGoogle.Size = new System.Drawing.Size(159, 23);
            this.btnGetImageFromGoogle.TabIndex = 0;
            this.btnGetImageFromGoogle.Text = "Get Image From Google";
            this.btnGetImageFromGoogle.UseVisualStyleBackColor = true;
            this.btnGetImageFromGoogle.Click += new System.EventHandler(this.btnGetImageFromGoogle_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(573, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(178, 12);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(470, 245);
            this.pBox.TabIndex = 1;
            this.pBox.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(13, 66);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(159, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(159, 19);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "ピカチュウ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(660, 298);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnGetImageFromGoogle);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetImageFromGoogle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

