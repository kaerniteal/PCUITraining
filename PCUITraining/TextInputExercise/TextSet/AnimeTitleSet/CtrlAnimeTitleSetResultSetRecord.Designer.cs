namespace TextInputExercise.TextSet.AnimeTitleSet
{
    partial class CtrlPokeaniSetResultSetRecord
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlPokeaniSetResultSetRecord));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblText = new System.Windows.Forms.Label();
            this.lblETime = new System.Windows.Forms.Label();
            this.pBoxUp = new System.Windows.Forms.PictureBox();
            this.lblAnime = new System.Windows.Forms.Label();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUp)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.Controls.Add(this.pBoxUp, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.lblText, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblETime, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.lblAnime, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblEpisode, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(945, 120);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblText, 2);
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F);
            this.lblText.ForeColor = System.Drawing.Color.Aqua;
            this.lblText.Location = new System.Drawing.Point(3, 60);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(702, 60);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "入力文字列";
            // 
            // lblETime
            // 
            this.lblETime.AutoSize = true;
            this.lblETime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblETime.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F);
            this.lblETime.ForeColor = System.Drawing.Color.White;
            this.lblETime.Location = new System.Drawing.Point(711, 0);
            this.lblETime.Name = "lblETime";
            this.tableLayoutPanel.SetRowSpan(this.lblETime, 2);
            this.lblETime.Size = new System.Drawing.Size(183, 120);
            this.lblETime.TabIndex = 0;
            this.lblETime.Text = "0000000";
            this.lblETime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBoxUp
            // 
            this.pBoxUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxUp.Image = ((System.Drawing.Image)(resources.GetObject("pBoxUp.Image")));
            this.pBoxUp.Location = new System.Drawing.Point(900, 3);
            this.pBoxUp.Name = "pBoxUp";
            this.tableLayoutPanel.SetRowSpan(this.pBoxUp, 2);
            this.pBoxUp.Size = new System.Drawing.Size(42, 114);
            this.pBoxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBoxUp.TabIndex = 1;
            this.pBoxUp.TabStop = false;
            this.pBoxUp.Visible = false;
            // 
            // lblAnime
            // 
            this.lblAnime.AutoSize = true;
            this.lblAnime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnime.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAnime.ForeColor = System.Drawing.Color.White;
            this.lblAnime.Location = new System.Drawing.Point(3, 0);
            this.lblAnime.Name = "lblAnime";
            this.lblAnime.Size = new System.Drawing.Size(230, 60);
            this.lblAnime.TabIndex = 0;
            this.lblAnime.Text = "アニメ";
            this.lblAnime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEpisode
            // 
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEpisode.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEpisode.ForeColor = System.Drawing.Color.White;
            this.lblEpisode.Location = new System.Drawing.Point(239, 0);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(466, 60);
            this.lblEpisode.TabIndex = 0;
            this.lblEpisode.Text = "エピソード";
            this.lblEpisode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlPokeaniSetResultSetRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "CtrlPokeaniSetResultSetRecord";
            this.Size = new System.Drawing.Size(945, 120);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblETime;
        private System.Windows.Forms.PictureBox pBoxUp;
        private System.Windows.Forms.Label lblAnime;
        private System.Windows.Forms.Label lblEpisode;
    }
}
