namespace TextInputExercise.TextSet.PokeaniSet
{
    partial class FormPokeaniSetDataViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tBoxFilter = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.userSelector = new PCUITCommon.Views.UserSelector();
            this.lblTitleFilter = new System.Windows.Forms.Label();
            this.chkBoxAll = new System.Windows.Forms.CheckBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.tBoxFilter, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.dgv, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnClose, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.userSelector, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblTitleFilter, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.chkBoxAll, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.cmbSort, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblCount, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1152, 659);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tBoxFilter
            // 
            this.tBoxFilter.BackColor = System.Drawing.Color.DimGray;
            this.tBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxFilter.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tBoxFilter.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tBoxFilter.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.tBoxFilter.Location = new System.Drawing.Point(693, 134);
            this.tBoxFilter.Name = "tBoxFilter";
            this.tBoxFilter.Size = new System.Drawing.Size(224, 37);
            this.tBoxFilter.TabIndex = 113;
            this.tBoxFilter.TextChanged += new System.EventHandler(this.tBoxFilter_TextChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.Black;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ColumnHeadersVisible = false;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tableLayoutPanel.SetColumnSpan(this.dgv, 5);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.Black;
            this.dgv.Location = new System.Drawing.Point(3, 166);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 21;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1146, 422);
            this.dgv.TabIndex = 105;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 5;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 5;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel.SetColumnSpan(this.btnClose, 5);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.ForeColor = System.Drawing.Color.LightSalmon;
            this.btnClose.Location = new System.Drawing.Point(3, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1146, 62);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "とじる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // userSelector
            // 
            this.userSelector.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.SetColumnSpan(this.userSelector, 5);
            this.userSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector.Location = new System.Drawing.Point(3, 3);
            this.userSelector.Name = "userSelector";
            this.userSelector.Size = new System.Drawing.Size(1146, 125);
            this.userSelector.TabIndex = 106;
            // 
            // lblTitleFilter
            // 
            this.lblTitleFilter.AutoSize = true;
            this.lblTitleFilter.BackColor = System.Drawing.Color.Black;
            this.lblTitleFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleFilter.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleFilter.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitleFilter.Location = new System.Drawing.Point(463, 131);
            this.lblTitleFilter.Name = "lblTitleFilter";
            this.lblTitleFilter.Size = new System.Drawing.Size(224, 32);
            this.lblTitleFilter.TabIndex = 111;
            this.lblTitleFilter.Text = "しぼりこみ";
            this.lblTitleFilter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkBoxAll
            // 
            this.chkBoxAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBoxAll.AutoSize = true;
            this.chkBoxAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBoxAll.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 24F);
            this.chkBoxAll.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkBoxAll.Location = new System.Drawing.Point(923, 134);
            this.chkBoxAll.Name = "chkBoxAll";
            this.chkBoxAll.Size = new System.Drawing.Size(226, 26);
            this.chkBoxAll.TabIndex = 112;
            this.chkBoxAll.Text = "全て表示する";
            this.chkBoxAll.UseVisualStyleBackColor = true;
            this.chkBoxAll.CheckedChanged += new System.EventHandler(this.chkBoxAll_CheckedChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.BackColor = System.Drawing.Color.Black;
            this.cmbSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSort.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 24F);
            this.cmbSort.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "シリーズ順",
            "最速タイム順"});
            this.cmbSort.Location = new System.Drawing.Point(233, 134);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(224, 41);
            this.cmbSort.TabIndex = 110;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F);
            this.lblCount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCount.Location = new System.Drawing.Point(3, 131);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(224, 32);
            this.lblCount.TabIndex = 114;
            // 
            // FormPokeaniSetDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1152, 659);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPokeaniSetDataViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "d";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgv;
        private PCUITCommon.Views.UserSelector userSelector;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblTitleFilter;
        private System.Windows.Forms.CheckBox chkBoxAll;
        private System.Windows.Forms.TextBox tBoxFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lblCount;
    }
}