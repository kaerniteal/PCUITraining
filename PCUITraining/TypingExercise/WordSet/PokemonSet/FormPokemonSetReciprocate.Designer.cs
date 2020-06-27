namespace TypingExercise.WordSet.PokemonSet
{
    partial class FormPokemonSetReciprocate
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReciprocate = new System.Windows.Forms.Button();
            this.userSelectorLeft = new PCUITCommon.Views.UserSelector();
            this.userSelectorRight = new PCUITCommon.Views.UserSelector();
            this.ctrlPokemonListLeft = new TypingExercise.WordSet.PokemonSet.CtrlPokemonSetDataViewerList();
            this.ctrlPokemonListRight = new TypingExercise.WordSet.PokemonSet.CtrlPokemonSetDataViewerList();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayout.Controls.Add(this.btnClose, 0, 4);
            this.tableLayout.Controls.Add(this.btnReciprocate, 1, 2);
            this.tableLayout.Controls.Add(this.userSelectorLeft, 0, 0);
            this.tableLayout.Controls.Add(this.userSelectorRight, 2, 0);
            this.tableLayout.Controls.Add(this.ctrlPokemonListLeft, 0, 1);
            this.tableLayout.Controls.Add(this.ctrlPokemonListRight, 2, 1);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 5;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayout.Size = new System.Drawing.Size(1152, 659);
            this.tableLayout.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayout.SetColumnSpan(this.btnClose, 3);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.ForeColor = System.Drawing.Color.LightSalmon;
            this.btnClose.Location = new System.Drawing.Point(3, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1146, 63);
            this.btnClose.TabIndex = 104;
            this.btnClose.Text = "とじる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReciprocate
            // 
            this.btnReciprocate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReciprocate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReciprocate.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnReciprocate.ForeColor = System.Drawing.Color.Yellow;
            this.btnReciprocate.Location = new System.Drawing.Point(521, 265);
            this.btnReciprocate.Name = "btnReciprocate";
            this.btnReciprocate.Size = new System.Drawing.Size(109, 125);
            this.btnReciprocate.TabIndex = 104;
            this.btnReciprocate.Text = "⇔";
            this.btnReciprocate.UseVisualStyleBackColor = false;
            this.btnReciprocate.Click += new System.EventHandler(this.btnReciprocate_Click);
            // 
            // userSelectorLeft
            // 
            this.userSelectorLeft.BackColor = System.Drawing.Color.Transparent;
            this.userSelectorLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelectorLeft.Location = new System.Drawing.Point(3, 3);
            this.userSelectorLeft.Name = "userSelectorLeft";
            this.userSelectorLeft.Size = new System.Drawing.Size(512, 125);
            this.userSelectorLeft.TabIndex = 106;
            // 
            // userSelectorRight
            // 
            this.userSelectorRight.BackColor = System.Drawing.Color.Transparent;
            this.userSelectorRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelectorRight.Location = new System.Drawing.Point(636, 3);
            this.userSelectorRight.Name = "userSelectorRight";
            this.userSelectorRight.Size = new System.Drawing.Size(513, 125);
            this.userSelectorRight.TabIndex = 107;
            // 
            // ctrlPokemonListLeft
            // 
            this.ctrlPokemonListLeft.BackColor = System.Drawing.Color.Black;
            this.ctrlPokemonListLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPokemonListLeft.Location = new System.Drawing.Point(3, 134);
            this.ctrlPokemonListLeft.Name = "ctrlPokemonListLeft";
            this.ctrlPokemonListLeft.OthreSideList = null;
            this.tableLayout.SetRowSpan(this.ctrlPokemonListLeft, 3);
            this.ctrlPokemonListLeft.Size = new System.Drawing.Size(512, 453);
            this.ctrlPokemonListLeft.TabIndex = 108;
            // 
            // ctrlPokemonListRight
            // 
            this.ctrlPokemonListRight.BackColor = System.Drawing.Color.Black;
            this.ctrlPokemonListRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPokemonListRight.Location = new System.Drawing.Point(636, 134);
            this.ctrlPokemonListRight.Name = "ctrlPokemonListRight";
            this.ctrlPokemonListRight.OthreSideList = null;
            this.tableLayout.SetRowSpan(this.ctrlPokemonListRight, 3);
            this.ctrlPokemonListRight.Size = new System.Drawing.Size(513, 453);
            this.ctrlPokemonListRight.TabIndex = 109;
            // 
            // FormPokemonSetReciprocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1152, 659);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPokemonSetReciprocate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "データ交換";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReciprocate;
        private PCUITCommon.Views.UserSelector userSelectorLeft;
        private PCUITCommon.Views.UserSelector userSelectorRight;
        private CtrlPokemonSetDataViewerList ctrlPokemonListLeft;
        private CtrlPokemonSetDataViewerList ctrlPokemonListRight;
    }
}