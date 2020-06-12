namespace TypingExercise.WordSet.PokemonSet
{
    partial class FormPokemonSetResultSet
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
            this.btonOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableWordResult = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
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
            this.btonOK.TabIndex = 1;
            this.btonOK.Text = "もういっかい";
            this.btonOK.UseVisualStyleBackColor = false;
            this.btonOK.Click += new System.EventHandler(this.btonOK_Click);
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
            this.btnCancel.TabIndex = 99;
            this.btnCancel.Text = "おわる";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableWordResult
            // 
            this.tableWordResult.ColumnCount = 1;
            this.tableWordResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.58642F));
            this.tableWordResult.Location = new System.Drawing.Point(12, 12);
            this.tableWordResult.Name = "tableWordResult";
            this.tableWordResult.RowCount = 10;
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableWordResult.Size = new System.Drawing.Size(1138, 680);
            this.tableWordResult.TabIndex = 1;
            // 
            // PocketMonsterResultSet
            // 
            this.AcceptButton = this.btonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1162, 799);
            this.Controls.Add(this.tableWordResult);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PocketMonsterResultSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PocketMonsterResultSet";
            this.Load += new System.EventHandler(this.PocketMonsterResultSet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btonOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableWordResult;
    }
}