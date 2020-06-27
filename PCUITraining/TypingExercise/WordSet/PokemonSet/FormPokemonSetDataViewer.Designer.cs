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
            this.ctrlPokemonSetDataViewerList = new TypingExercise.WordSet.PokemonSet.CtrlPokemonSetDataViewerList();
            this.lblComp = new System.Windows.Forms.Label();
            this.lblTitleComp = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.userSelector = new PCUITCommon.Views.UserSelector();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPokemonSetDataViewerList
            // 
            this.ctrlPokemonSetDataViewerList.BackColor = System.Drawing.Color.Black;
            this.tableLayout.SetColumnSpan(this.ctrlPokemonSetDataViewerList, 2);
            this.ctrlPokemonSetDataViewerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPokemonSetDataViewerList.Location = new System.Drawing.Point(3, 166);
            this.ctrlPokemonSetDataViewerList.Name = "ctrlPokemonSetDataViewerList";
            this.ctrlPokemonSetDataViewerList.Size = new System.Drawing.Size(569, 422);
            this.ctrlPokemonSetDataViewerList.TabIndex = 106;
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.BackColor = System.Drawing.Color.Black;
            this.lblComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComp.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblComp.Location = new System.Drawing.Point(175, 131);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(397, 32);
            this.lblComp.TabIndex = 104;
            this.lblComp.Text = "0/980";
            // 
            // lblTitleComp
            // 
            this.lblTitleComp.AutoSize = true;
            this.lblTitleComp.BackColor = System.Drawing.Color.Black;
            this.lblTitleComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleComp.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleComp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitleComp.Location = new System.Drawing.Point(3, 131);
            this.lblTitleComp.Name = "lblTitleComp";
            this.lblTitleComp.Size = new System.Drawing.Size(166, 32);
            this.lblTitleComp.TabIndex = 104;
            this.lblTitleComp.Text = "こんぷ率";
            this.lblTitleComp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayout.SetColumnSpan(this.btnClose, 4);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.ForeColor = System.Drawing.Color.LightSalmon;
            this.btnClose.Location = new System.Drawing.Point(3, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1146, 62);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "とじる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(578, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.tableLayout.SetRowSpan(this.webBrowser, 3);
            this.webBrowser.Size = new System.Drawing.Size(571, 585);
            this.webBrowser.TabIndex = 105;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.webBrowser, 2, 0);
            this.tableLayout.Controls.Add(this.btnClose, 0, 3);
            this.tableLayout.Controls.Add(this.lblTitleComp, 0, 1);
            this.tableLayout.Controls.Add(this.lblComp, 1, 1);
            this.tableLayout.Controls.Add(this.ctrlPokemonSetDataViewerList, 0, 2);
            this.tableLayout.Controls.Add(this.userSelector, 0, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 4;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(1152, 659);
            this.tableLayout.TabIndex = 0;
            // 
            // userSelector
            // 
            this.userSelector.BackColor = System.Drawing.Color.Transparent;
            this.tableLayout.SetColumnSpan(this.userSelector, 2);
            this.userSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector.Location = new System.Drawing.Point(3, 3);
            this.userSelector.Name = "userSelector";
            this.userSelector.Size = new System.Drawing.Size(569, 125);
            this.userSelector.TabIndex = 107;
            // 
            // FormPokemonSetDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1152, 659);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPokemonSetDataViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "データ表示";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlPokemonSetDataViewerList ctrlPokemonSetDataViewerList;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitleComp;
        private System.Windows.Forms.Label lblComp;
        private PCUITCommon.Views.UserSelector userSelector;
    }
}