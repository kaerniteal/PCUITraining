namespace TypingExercise.WordSet.PokemonSet
{
    partial class FormPokemonSetDataViewer
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableUserSelect = new System.Windows.Forms.TableLayoutPanel();
            this.flowUserSelect = new System.Windows.Forms.FlowLayoutPanel();
            this.ListPokeMon = new System.Windows.Forms.ListBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.lblTitleCatch = new System.Windows.Forms.Label();
            this.lblCatch = new System.Windows.Forms.Label();
            this.lblTitleTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitleComp = new System.Windows.Forms.Label();
            this.lblComp = new System.Windows.Forms.Label();
            this.tableLayout.SuspendLayout();
            this.tableUserSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.tableUserSelect, 0, 0);
            this.tableLayout.Controls.Add(this.ListPokeMon, 0, 1);
            this.tableLayout.Controls.Add(this.webBrowser, 2, 0);
            this.tableLayout.Controls.Add(this.lblTitleCatch, 1, 1);
            this.tableLayout.Controls.Add(this.lblCatch, 1, 2);
            this.tableLayout.Controls.Add(this.lblTitleTime, 1, 3);
            this.tableLayout.Controls.Add(this.lblTime, 1, 4);
            this.tableLayout.Controls.Add(this.btnClose, 0, 8);
            this.tableLayout.Controls.Add(this.lblTitleComp, 1, 5);
            this.tableLayout.Controls.Add(this.lblComp, 1, 6);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 9;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(1152, 659);
            this.tableLayout.TabIndex = 0;
            // 
            // tableUserSelect
            // 
            this.tableUserSelect.ColumnCount = 1;
            this.tableLayout.SetColumnSpan(this.tableUserSelect, 2);
            this.tableUserSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUserSelect.Controls.Add(this.flowUserSelect, 0, 1);
            this.tableUserSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUserSelect.Location = new System.Drawing.Point(3, 3);
            this.tableUserSelect.Name = "tableUserSelect";
            this.tableUserSelect.RowCount = 3;
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableUserSelect.Size = new System.Drawing.Size(570, 125);
            this.tableUserSelect.TabIndex = 101;
            // 
            // flowUserSelect
            // 
            this.flowUserSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowUserSelect.Location = new System.Drawing.Point(3, 13);
            this.flowUserSelect.Name = "flowUserSelect";
            this.flowUserSelect.Size = new System.Drawing.Size(564, 99);
            this.flowUserSelect.TabIndex = 0;
            // 
            // ListPokeMon
            // 
            this.ListPokeMon.BackColor = System.Drawing.Color.Black;
            this.ListPokeMon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListPokeMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListPokeMon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ListPokeMon.ForeColor = System.Drawing.Color.White;
            this.ListPokeMon.FormattingEnabled = true;
            this.ListPokeMon.ItemHeight = 48;
            this.ListPokeMon.Location = new System.Drawing.Point(3, 134);
            this.ListPokeMon.Name = "ListPokeMon";
            this.tableLayout.SetRowSpan(this.ListPokeMon, 7);
            this.ListPokeMon.Size = new System.Drawing.Size(282, 449);
            this.ListPokeMon.TabIndex = 103;
            this.ListPokeMon.SelectedIndexChanged += new System.EventHandler(this.ListPokeMon_SelectedIndexChanged);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(579, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.tableLayout.SetRowSpan(this.webBrowser, 8);
            this.webBrowser.Size = new System.Drawing.Size(570, 580);
            this.webBrowser.TabIndex = 105;
            // 
            // lblTitleCatch
            // 
            this.lblTitleCatch.AutoSize = true;
            this.lblTitleCatch.BackColor = System.Drawing.Color.Black;
            this.lblTitleCatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleCatch.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleCatch.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitleCatch.Location = new System.Drawing.Point(291, 131);
            this.lblTitleCatch.Name = "lblTitleCatch";
            this.lblTitleCatch.Size = new System.Drawing.Size(282, 65);
            this.lblTitleCatch.TabIndex = 104;
            this.lblTitleCatch.Text = "ほかく数";
            this.lblTitleCatch.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCatch
            // 
            this.lblCatch.AutoSize = true;
            this.lblCatch.BackColor = System.Drawing.Color.Black;
            this.lblCatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCatch.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCatch.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCatch.Location = new System.Drawing.Point(291, 196);
            this.lblCatch.Name = "lblCatch";
            this.lblCatch.Size = new System.Drawing.Size(282, 65);
            this.lblCatch.TabIndex = 104;
            this.lblCatch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTitleTime
            // 
            this.lblTitleTime.AutoSize = true;
            this.lblTitleTime.BackColor = System.Drawing.Color.Black;
            this.lblTitleTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleTime.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitleTime.Location = new System.Drawing.Point(291, 261);
            this.lblTitleTime.Name = "lblTitleTime";
            this.lblTitleTime.Size = new System.Drawing.Size(282, 65);
            this.lblTitleTime.TabIndex = 104;
            this.lblTitleTime.Text = "最速タイム";
            this.lblTitleTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Black;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTime.Location = new System.Drawing.Point(291, 326);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(282, 65);
            this.lblTime.TabIndex = 104;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayout.SetColumnSpan(this.btnClose, 4);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.ForeColor = System.Drawing.Color.LightSalmon;
            this.btnClose.Location = new System.Drawing.Point(3, 589);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1146, 67);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "とじる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitleComp
            // 
            this.lblTitleComp.AutoSize = true;
            this.lblTitleComp.BackColor = System.Drawing.Color.Black;
            this.lblTitleComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleComp.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleComp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitleComp.Location = new System.Drawing.Point(291, 391);
            this.lblTitleComp.Name = "lblTitleComp";
            this.lblTitleComp.Size = new System.Drawing.Size(282, 65);
            this.lblTitleComp.TabIndex = 104;
            this.lblTitleComp.Text = "こんぷ率";
            this.lblTitleComp.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.BackColor = System.Drawing.Color.Black;
            this.lblComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComp.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblComp.Location = new System.Drawing.Point(291, 456);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(282, 65);
            this.lblComp.TabIndex = 104;
            this.lblComp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormPocketMonsterDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1152, 659);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPocketMonsterDataViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "データ表示";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.tableUserSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.TableLayoutPanel tableUserSelect;
        private System.Windows.Forms.FlowLayoutPanel flowUserSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox ListPokeMon;
        private System.Windows.Forms.Label lblTitleCatch;
        private System.Windows.Forms.Label lblCatch;
        private System.Windows.Forms.Label lblTitleTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label lblTitleComp;
        private System.Windows.Forms.Label lblComp;
    }
}