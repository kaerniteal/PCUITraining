namespace PCUITraining.Forms
{
    partial class FormSettingUser
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNameColor = new System.Windows.Forms.Label();
            this.lblUseIcon = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.tBoxName = new System.Windows.Forms.TextBox();
            this.cmbbColor = new System.Windows.Forms.ComboBox();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.lblBtnUseIcon = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNameColor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUseIcon, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblImage, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tBoxName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbbColor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectIcon, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBtnUseIcon, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(3, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(475, 114);
            this.btnSave.TabIndex = 103;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.lblName.ForeColor = System.Drawing.Color.Yellow;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(379, 120);
            this.lblName.TabIndex = 104;
            this.lblName.Text = "名前";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNameColor
            // 
            this.lblNameColor.AutoSize = true;
            this.lblNameColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameColor.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.lblNameColor.ForeColor = System.Drawing.Color.Yellow;
            this.lblNameColor.Location = new System.Drawing.Point(3, 120);
            this.lblNameColor.Name = "lblNameColor";
            this.lblNameColor.Size = new System.Drawing.Size(379, 120);
            this.lblNameColor.TabIndex = 104;
            this.lblNameColor.Text = "名前の色";
            this.lblNameColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUseIcon
            // 
            this.lblUseIcon.AutoSize = true;
            this.lblUseIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUseIcon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.lblUseIcon.ForeColor = System.Drawing.Color.Yellow;
            this.lblUseIcon.Location = new System.Drawing.Point(3, 240);
            this.lblUseIcon.Name = "lblUseIcon";
            this.lblUseIcon.Size = new System.Drawing.Size(379, 120);
            this.lblUseIcon.TabIndex = 104;
            this.lblUseIcon.Text = "画像の使用";
            this.lblUseIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImage.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.lblImage.ForeColor = System.Drawing.Color.Yellow;
            this.lblImage.Location = new System.Drawing.Point(3, 360);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(379, 120);
            this.lblImage.TabIndex = 104;
            this.lblImage.Text = "イメージ";
            this.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBoxName
            // 
            this.tBoxName.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.SetColumnSpan(this.tBoxName, 2);
            this.tBoxName.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.tBoxName.ForeColor = System.Drawing.Color.Aqua;
            this.tBoxName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tBoxName.Location = new System.Drawing.Point(388, 3);
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.Size = new System.Drawing.Size(573, 71);
            this.tBoxName.TabIndex = 105;
            // 
            // cmbbColor
            // 
            this.cmbbColor.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbbColor, 2);
            this.cmbbColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbColor.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.cmbbColor.FormattingEnabled = true;
            this.cmbbColor.IntegralHeight = false;
            this.cmbbColor.Location = new System.Drawing.Point(388, 123);
            this.cmbbColor.MaxDropDownItems = 10;
            this.cmbbColor.Name = "cmbbColor";
            this.cmbbColor.Size = new System.Drawing.Size(573, 72);
            this.cmbbColor.TabIndex = 106;
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSelectIcon, 2);
            this.btnSelectIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectIcon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.btnSelectIcon.ForeColor = System.Drawing.Color.Aqua;
            this.btnSelectIcon.Location = new System.Drawing.Point(388, 363);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(573, 114);
            this.btnSelectIcon.TabIndex = 108;
            this.btnSelectIcon.Text = "選択";
            this.btnSelectIcon.UseVisualStyleBackColor = false;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // lblBtnUseIcon
            // 
            this.lblBtnUseIcon.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblBtnUseIcon, 2);
            this.lblBtnUseIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnUseIcon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F);
            this.lblBtnUseIcon.ForeColor = System.Drawing.Color.Red;
            this.lblBtnUseIcon.Location = new System.Drawing.Point(388, 240);
            this.lblBtnUseIcon.Name = "lblBtnUseIcon";
            this.lblBtnUseIcon.Size = new System.Drawing.Size(573, 120);
            this.lblBtnUseIcon.TabIndex = 104;
            this.lblBtnUseIcon.Text = "しない";
            this.lblBtnUseIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBtnUseIcon.Click += new System.EventHandler(this.lblBtnUseIcon_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(484, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(477, 114);
            this.btnCancel.TabIndex = 103;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormSettingUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(964, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettingUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSettingUser";
            this.Load += new System.EventHandler(this.FormSettingUser_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameColor;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox tBoxName;
        private System.Windows.Forms.ComboBox cmbbColor;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.Label lblUseIcon;
        private System.Windows.Forms.Label lblBtnUseIcon;
    }
}