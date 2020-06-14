namespace PCUITraining.Forms
{
    partial class FormMainDebug
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
            this.btnPokeMonTyping = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.tableUserButton = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlPokemonSetDataViewerList1 = new TypingExercise.WordSet.PokemonSet.CtrlPokemonSetDataViewerList();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPokeMonTyping
            // 
            this.btnPokeMonTyping.Location = new System.Drawing.Point(12, 12);
            this.btnPokeMonTyping.Name = "btnPokeMonTyping";
            this.btnPokeMonTyping.Size = new System.Drawing.Size(142, 23);
            this.btnPokeMonTyping.TabIndex = 0;
            this.btnPokeMonTyping.Text = "PokeMonTyping";
            this.btnPokeMonTyping.UseVisualStyleBackColor = true;
            this.btnPokeMonTyping.Click += new System.EventHandler(this.btnPokeMonTyping_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(592, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(160, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 65);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(12, 41);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(142, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tableUserButton
            // 
            this.tableUserButton.ColumnCount = 1;
            this.tableUserButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUserButton.Location = new System.Drawing.Point(286, 12);
            this.tableUserButton.Name = "tableUserButton";
            this.tableUserButton.RowCount = 1;
            this.tableUserButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUserButton.Size = new System.Drawing.Size(381, 65);
            this.tableUserButton.TabIndex = 2;
            // 
            // ctrlPokemonSetDataViewerList1
            // 
            this.ctrlPokemonSetDataViewerList1.Location = new System.Drawing.Point(42, 106);
            this.ctrlPokemonSetDataViewerList1.Name = "ctrlPokemonSetDataViewerList1";
            this.ctrlPokemonSetDataViewerList1.Size = new System.Drawing.Size(321, 251);
            this.ctrlPokemonSetDataViewerList1.TabIndex = 3;
            // 
            // FormMainDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(679, 429);
            this.Controls.Add(this.ctrlPokemonSetDataViewerList1);
            this.Controls.Add(this.tableUserButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPokeMonTyping);
            this.Name = "FormMainDebug";
            this.Text = "FormMainDebug";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPokeMonTyping;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TableLayoutPanel tableUserButton;
        private TypingExercise.WordSet.PokemonSet.CtrlPokemonSetDataViewerList ctrlPokemonSetDataViewerList1;
    }
}