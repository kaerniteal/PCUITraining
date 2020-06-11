namespace TypingExercise.Forms
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPokeMonTyping = new System.Windows.Forms.Button();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableUserSelect = new System.Windows.Forms.TableLayoutPanel();
            this.flowUserSelect = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPokeMonTypingDataView = new System.Windows.Forms.Button();
            this.tableMain.SuspendLayout();
            this.tableUserSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableMain.SetColumnSpan(this.btnClose, 2);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(64, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(485, 83);
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
            this.btnPokeMonTyping.Location = new System.Drawing.Point(64, 92);
            this.btnPokeMonTyping.Name = "btnPokeMonTyping";
            this.btnPokeMonTyping.Size = new System.Drawing.Size(424, 83);
            this.btnPokeMonTyping.TabIndex = 1;
            this.btnPokeMonTyping.Text = "ポケモンタイピング！";
            this.btnPokeMonTyping.UseVisualStyleBackColor = false;
            this.btnPokeMonTyping.Click += new System.EventHandler(this.btnPokeMonTyping_Click);
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 4;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableMain.Controls.Add(this.btnPokeMonTyping, 1, 1);
            this.tableMain.Controls.Add(this.btnClose, 1, 4);
            this.tableMain.Controls.Add(this.tableUserSelect, 1, 0);
            this.tableMain.Controls.Add(this.btnPokeMonTypingDataView, 2, 1);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 5;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMain.Size = new System.Drawing.Size(615, 445);
            this.tableMain.TabIndex = 1;
            // 
            // tableUserSelect
            // 
            this.tableUserSelect.ColumnCount = 1;
            this.tableMain.SetColumnSpan(this.tableUserSelect, 2);
            this.tableUserSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUserSelect.Controls.Add(this.flowUserSelect, 0, 1);
            this.tableUserSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUserSelect.Location = new System.Drawing.Point(64, 3);
            this.tableUserSelect.Name = "tableUserSelect";
            this.tableUserSelect.RowCount = 3;
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableUserSelect.Size = new System.Drawing.Size(485, 83);
            this.tableUserSelect.TabIndex = 100;
            // 
            // flowUserSelect
            // 
            this.flowUserSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowUserSelect.Location = new System.Drawing.Point(3, 13);
            this.flowUserSelect.Name = "flowUserSelect";
            this.flowUserSelect.Size = new System.Drawing.Size(479, 57);
            this.flowUserSelect.TabIndex = 0;
            // 
            // btnPokeMonTypingDataView
            // 
            this.btnPokeMonTypingDataView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPokeMonTypingDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPokeMonTypingDataView.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokeMonTypingDataView.ForeColor = System.Drawing.Color.Yellow;
            this.btnPokeMonTypingDataView.Image = global::TypingExercise.Properties.Resources.monsterboll;
            this.btnPokeMonTypingDataView.Location = new System.Drawing.Point(494, 92);
            this.btnPokeMonTypingDataView.Name = "btnPokeMonTypingDataView";
            this.btnPokeMonTypingDataView.Size = new System.Drawing.Size(55, 83);
            this.btnPokeMonTypingDataView.TabIndex = 2;
            this.btnPokeMonTypingDataView.UseVisualStyleBackColor = false;
            this.btnPokeMonTypingDataView.Click += new System.EventHandler(this.btnPokeMonTypingDataView_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(615, 445);
            this.Controls.Add(this.tableMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typing Exercise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableMain.ResumeLayout(false);
            this.tableUserSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPokeMonTyping;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.TableLayoutPanel tableUserSelect;
        private System.Windows.Forms.FlowLayoutPanel flowUserSelect;
        private System.Windows.Forms.Button btnPokeMonTypingDataView;
    }
}