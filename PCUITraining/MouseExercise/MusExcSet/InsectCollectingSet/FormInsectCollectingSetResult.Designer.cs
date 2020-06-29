namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    partial class FormInsectCollectingSetResult
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btonOK = new System.Windows.Forms.Button();
            this.dgvCapture = new System.Windows.Forms.DataGridView();
            this.dgvHighScore = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitleScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTitleHighScore = new System.Windows.Forms.Label();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(588, 698);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(562, 89);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "おわる";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btonOK
            // 
            this.btonOK.BackColor = System.Drawing.Color.DimGray;
            this.btonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btonOK.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btonOK.ForeColor = System.Drawing.Color.Yellow;
            this.btonOK.Location = new System.Drawing.Point(12, 698);
            this.btonOK.Name = "btonOK";
            this.btonOK.Size = new System.Drawing.Size(562, 89);
            this.btonOK.TabIndex = 100;
            this.btonOK.Text = "もういっかい";
            this.btonOK.UseVisualStyleBackColor = false;
            this.btonOK.Click += new System.EventHandler(this.btonOK_Click);
            // 
            // dgvCapture
            // 
            this.dgvCapture.AllowUserToAddRows = false;
            this.dgvCapture.AllowUserToDeleteRows = false;
            this.dgvCapture.AllowUserToResizeColumns = false;
            this.dgvCapture.AllowUserToResizeRows = false;
            this.dgvCapture.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvCapture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCapture.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCapture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapture.ColumnHeadersVisible = false;
            this.dgvCapture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCapture.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCapture.Location = new System.Drawing.Point(12, 12);
            this.dgvCapture.MultiSelect = false;
            this.dgvCapture.Name = "dgvCapture";
            this.dgvCapture.ReadOnly = true;
            this.dgvCapture.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCapture.RowHeadersVisible = false;
            this.dgvCapture.RowTemplate.Height = 21;
            this.dgvCapture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCapture.Size = new System.Drawing.Size(789, 680);
            this.dgvCapture.TabIndex = 0;
            this.dgvCapture.TabStop = false;
            // 
            // dgvHighScore
            // 
            this.dgvHighScore.AllowUserToAddRows = false;
            this.dgvHighScore.AllowUserToDeleteRows = false;
            this.dgvHighScore.AllowUserToResizeColumns = false;
            this.dgvHighScore.AllowUserToResizeRows = false;
            this.dgvHighScore.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvHighScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHighScore.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHighScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighScore.ColumnHeadersVisible = false;
            this.dgvHighScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 24F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHighScore.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHighScore.Location = new System.Drawing.Point(807, 172);
            this.dgvHighScore.MultiSelect = false;
            this.dgvHighScore.Name = "dgvHighScore";
            this.dgvHighScore.ReadOnly = true;
            this.dgvHighScore.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHighScore.RowHeadersVisible = false;
            this.dgvHighScore.RowTemplate.Height = 21;
            this.dgvHighScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHighScore.Size = new System.Drawing.Size(343, 520);
            this.dgvHighScore.TabIndex = 0;
            this.dgvHighScore.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 48;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 440;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 180;
            // 
            // lblTitleScore
            // 
            this.lblTitleScore.AutoSize = true;
            this.lblTitleScore.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleScore.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleScore.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTitleScore.Location = new System.Drawing.Point(807, 12);
            this.lblTitleScore.Name = "lblTitleScore";
            this.lblTitleScore.Size = new System.Drawing.Size(239, 37);
            this.lblTitleScore.TabIndex = 103;
            this.lblTitleScore.Text = "今回のスコア";
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblScore.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblScore.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore.Location = new System.Drawing.Point(814, 60);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(336, 39);
            this.lblScore.TabIndex = 103;
            this.lblScore.Text = "0点";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleHighScore
            // 
            this.lblTitleHighScore.AutoSize = true;
            this.lblTitleHighScore.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleHighScore.Font = new System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleHighScore.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTitleHighScore.Location = new System.Drawing.Point(807, 132);
            this.lblTitleHighScore.Name = "lblTitleHighScore";
            this.lblTitleHighScore.Size = new System.Drawing.Size(202, 37);
            this.lblTitleHighScore.TabIndex = 103;
            this.lblTitleHighScore.Text = "ハイスコア";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 5;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 5;
            // 
            // FormInsectCollectingSetResult
            // 
            this.AcceptButton = this.btonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1162, 799);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblTitleHighScore);
            this.Controls.Add(this.lblTitleScore);
            this.Controls.Add(this.dgvHighScore);
            this.Controls.Add(this.dgvCapture);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInsectCollectingSetResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btonOK;
        private System.Windows.Forms.DataGridView dgvCapture;
        private System.Windows.Forms.DataGridView dgvHighScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lblTitleScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTitleHighScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}