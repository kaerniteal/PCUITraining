namespace TextInputExercise.TextSet.PokeaniSet
{
    partial class FormPokeaniSetResultText
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
            this.lblEpisode = new System.Windows.Forms.Label();
            this.lblTitleEtime = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblEtime = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblSeries = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.lblTitleEtime, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.lblEtime, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.lblEpisode, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblText, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lblVolume, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblSeries, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(991, 330);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblEpisode
            // 
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEpisode.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEpisode.ForeColor = System.Drawing.Color.White;
            this.lblEpisode.Location = new System.Drawing.Point(498, 66);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(490, 66);
            this.lblEpisode.TabIndex = 0;
            this.lblEpisode.Text = "Episode";
            this.lblEpisode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleEtime
            // 
            this.lblTitleEtime.AutoSize = true;
            this.lblTitleEtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleEtime.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleEtime.ForeColor = System.Drawing.Color.White;
            this.lblTitleEtime.Location = new System.Drawing.Point(3, 231);
            this.lblTitleEtime.Name = "lblTitleEtime";
            this.lblTitleEtime.Size = new System.Drawing.Size(489, 99);
            this.lblTitleEtime.TabIndex = 0;
            this.lblTitleEtime.Text = "かかった時間";
            this.lblTitleEtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblText, 2);
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblText.ForeColor = System.Drawing.Color.Aqua;
            this.lblText.Location = new System.Drawing.Point(0, 132);
            this.lblText.Margin = new System.Windows.Forms.Padding(0);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblText.Size = new System.Drawing.Size(991, 99);
            this.lblText.TabIndex = 0;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEtime
            // 
            this.lblEtime.AutoSize = true;
            this.lblEtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEtime.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEtime.ForeColor = System.Drawing.Color.Yellow;
            this.lblEtime.Location = new System.Drawing.Point(498, 231);
            this.lblEtime.Name = "lblEtime";
            this.lblEtime.Size = new System.Drawing.Size(490, 99);
            this.lblEtime.TabIndex = 0;
            this.lblEtime.Text = "0000ms";
            this.lblEtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVolume.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVolume.ForeColor = System.Drawing.Color.White;
            this.lblVolume.Location = new System.Drawing.Point(3, 66);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(489, 66);
            this.lblVolume.TabIndex = 0;
            this.lblVolume.Text = "Volume";
            this.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblSeries, 2);
            this.lblSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeries.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeries.ForeColor = System.Drawing.Color.White;
            this.lblSeries.Location = new System.Drawing.Point(3, 0);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(985, 66);
            this.lblSeries.TabIndex = 0;
            this.lblSeries.Text = "Series";
            this.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPokeaniSetResultText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(991, 330);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPokeaniSetResultText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "d";
            this.Load += new System.EventHandler(this.FormPokeaniSetResultText_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPokeaniSetResultText_KeyPress);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.Label lblTitleEtime;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblEtime;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label lblSeries;
    }
}