namespace PCUITraining.Forms
{
    partial class FormSetting
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.userSelector = new PCUITCommon.Views.UserSelector();
            this.btnConf1 = new System.Windows.Forms.Button();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.btnUserUpdate = new System.Windows.Forms.Button();
            this.btnUserDelete = new System.Windows.Forms.Button();
            this.btnConf2 = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnConf3 = new System.Windows.Forms.Button();
            this.btnCommonConf = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel.SetColumnSpan(this.btnCancel, 2);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(3, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(814, 49);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "とじる";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.userSelector, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnCancel, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.btnConf1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnUserAdd, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.btnUserUpdate, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.btnUserDelete, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.btnConf2, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.lblVersion, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnConf3, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.btnCommonConf, 1, 7);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(820, 532);
            this.tableLayoutPanel.TabIndex = 103;
            // 
            // userSelector
            // 
            this.userSelector.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.SetColumnSpan(this.userSelector, 2);
            this.userSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector.Location = new System.Drawing.Point(3, 56);
            this.userSelector.Name = "userSelector";
            this.userSelector.Size = new System.Drawing.Size(814, 100);
            this.userSelector.TabIndex = 103;
            // 
            // btnConf1
            // 
            this.btnConf1.BackColor = System.Drawing.Color.DimGray;
            this.btnConf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConf1.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConf1.ForeColor = System.Drawing.Color.Yellow;
            this.btnConf1.Location = new System.Drawing.Point(3, 162);
            this.btnConf1.Name = "btnConf1";
            this.btnConf1.Size = new System.Drawing.Size(404, 47);
            this.btnConf1.TabIndex = 101;
            this.btnConf1.Text = "ポケモンタイピング！";
            this.btnConf1.UseVisualStyleBackColor = false;
            this.btnConf1.Click += new System.EventHandler(this.btnConf1_Click);
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.BackColor = System.Drawing.Color.DimGray;
            this.btnUserAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserAdd.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUserAdd.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnUserAdd.Location = new System.Drawing.Point(413, 162);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(404, 47);
            this.btnUserAdd.TabIndex = 101;
            this.btnUserAdd.Text = "ユーザーを追加";
            this.btnUserAdd.UseVisualStyleBackColor = false;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // btnUserUpdate
            // 
            this.btnUserUpdate.BackColor = System.Drawing.Color.DimGray;
            this.btnUserUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserUpdate.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUserUpdate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnUserUpdate.Location = new System.Drawing.Point(413, 215);
            this.btnUserUpdate.Name = "btnUserUpdate";
            this.btnUserUpdate.Size = new System.Drawing.Size(404, 47);
            this.btnUserUpdate.TabIndex = 101;
            this.btnUserUpdate.Text = "ユーザーを編集";
            this.btnUserUpdate.UseVisualStyleBackColor = false;
            this.btnUserUpdate.Click += new System.EventHandler(this.btnUserUpdate_Click);
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.BackColor = System.Drawing.Color.DimGray;
            this.btnUserDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserDelete.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUserDelete.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnUserDelete.Location = new System.Drawing.Point(413, 268);
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Size = new System.Drawing.Size(404, 47);
            this.btnUserDelete.TabIndex = 101;
            this.btnUserDelete.Text = "ユーザーを削除";
            this.btnUserDelete.UseVisualStyleBackColor = false;
            this.btnUserDelete.Click += new System.EventHandler(this.btnUserDelete_Click);
            // 
            // btnConf2
            // 
            this.btnConf2.BackColor = System.Drawing.Color.DimGray;
            this.btnConf2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConf2.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConf2.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnConf2.Location = new System.Drawing.Point(3, 215);
            this.btnConf2.Name = "btnConf2";
            this.btnConf2.Size = new System.Drawing.Size(404, 47);
            this.btnConf2.TabIndex = 101;
            this.btnConf2.Text = "マウスで昆虫採集";
            this.btnConf2.UseVisualStyleBackColor = false;
            this.btnConf2.Click += new System.EventHandler(this.btnConf2_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblVersion, 2);
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(3, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(814, 53);
            this.lblVersion.TabIndex = 104;
            this.lblVersion.Text = "Ver";
            // 
            // btnConf3
            // 
            this.btnConf3.BackColor = System.Drawing.Color.DimGray;
            this.btnConf3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConf3.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConf3.ForeColor = System.Drawing.Color.Aqua;
            this.btnConf3.Location = new System.Drawing.Point(3, 268);
            this.btnConf3.Name = "btnConf3";
            this.btnConf3.Size = new System.Drawing.Size(404, 47);
            this.btnConf3.TabIndex = 101;
            this.btnConf3.Text = "ポケアニライティング！";
            this.btnConf3.UseVisualStyleBackColor = false;
            this.btnConf3.Click += new System.EventHandler(this.btnConf3_Click);
            // 
            // btnCommonConf
            // 
            this.btnCommonConf.BackColor = System.Drawing.Color.DimGray;
            this.btnCommonConf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCommonConf.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCommonConf.ForeColor = System.Drawing.Color.White;
            this.btnCommonConf.Location = new System.Drawing.Point(413, 427);
            this.btnCommonConf.Name = "btnCommonConf";
            this.btnCommonConf.Size = new System.Drawing.Size(404, 47);
            this.btnCommonConf.TabIndex = 101;
            this.btnCommonConf.Text = "共通設定";
            this.btnCommonConf.UseVisualStyleBackColor = false;
            this.btnCommonConf.Click += new System.EventHandler(this.btnCommonConf_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(820, 532);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private PCUITCommon.Views.UserSelector userSelector;
        private System.Windows.Forms.Button btnConf1;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.Button btnUserUpdate;
        private System.Windows.Forms.Button btnUserDelete;
        private System.Windows.Forms.Button btnConf2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnConf3;
        private System.Windows.Forms.Button btnCommonConf;
    }
}