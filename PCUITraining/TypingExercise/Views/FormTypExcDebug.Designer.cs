namespace TypingExercise.Views
{
    partial class FormTypExcDebug
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
            this.lblWord = new System.Windows.Forms.Label();
            this.lblInputed = new System.Windows.Forms.Label();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.lblMissTypes = new System.Windows.Forms.Label();
            this.lblResultWord = new System.Windows.Forms.Label();
            this.lblResultETime = new System.Windows.Forms.Label();
            this.lblResultMissType = new System.Windows.Forms.Label();
            this.pPanel = new TypingExercise.Views.PicturePanel();
            this.lblResultNoMissCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Location = new System.Drawing.Point(12, 9);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(89, 12);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "入力対象文字列";
            // 
            // lblInputed
            // 
            this.lblInputed.AutoSize = true;
            this.lblInputed.Location = new System.Drawing.Point(12, 33);
            this.lblInputed.Name = "lblInputed";
            this.lblInputed.Size = new System.Drawing.Size(88, 12);
            this.lblInputed.TabIndex = 0;
            this.lblInputed.Text = "入力済み文字列";
            // 
            // lblCorrect
            // 
            this.lblCorrect.AutoSize = true;
            this.lblCorrect.Location = new System.Drawing.Point(12, 63);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(25, 12);
            this.lblCorrect.TabIndex = 0;
            this.lblCorrect.Text = "綴り";
            // 
            // lblMissTypes
            // 
            this.lblMissTypes.AutoSize = true;
            this.lblMissTypes.Location = new System.Drawing.Point(95, 63);
            this.lblMissTypes.Name = "lblMissTypes";
            this.lblMissTypes.Size = new System.Drawing.Size(21, 12);
            this.lblMissTypes.TabIndex = 0;
            this.lblMissTypes.Text = "ミス";
            // 
            // lblResultWord
            // 
            this.lblResultWord.AutoSize = true;
            this.lblResultWord.Location = new System.Drawing.Point(176, 9);
            this.lblResultWord.Name = "lblResultWord";
            this.lblResultWord.Size = new System.Drawing.Size(65, 12);
            this.lblResultWord.TabIndex = 2;
            this.lblResultWord.Text = "結果文字列";
            // 
            // lblResultETime
            // 
            this.lblResultETime.AutoSize = true;
            this.lblResultETime.Location = new System.Drawing.Point(176, 33);
            this.lblResultETime.Name = "lblResultETime";
            this.lblResultETime.Size = new System.Drawing.Size(66, 12);
            this.lblResultETime.TabIndex = 2;
            this.lblResultETime.Text = "かかった時間";
            // 
            // lblResultMissType
            // 
            this.lblResultMissType.AutoSize = true;
            this.lblResultMissType.Location = new System.Drawing.Point(175, 63);
            this.lblResultMissType.Name = "lblResultMissType";
            this.lblResultMissType.Size = new System.Drawing.Size(59, 12);
            this.lblResultMissType.TabIndex = 2;
            this.lblResultMissType.Text = "ミスタイプ数";
            // 
            // pPanel
            // 
            this.pPanel.Location = new System.Drawing.Point(257, 12);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(210, 274);
            this.pPanel.TabIndex = 1;
            this.pPanel.TabStop = false;
            // 
            // lblResultNoMissCount
            // 
            this.lblResultNoMissCount.AutoSize = true;
            this.lblResultNoMissCount.Location = new System.Drawing.Point(175, 93);
            this.lblResultNoMissCount.Name = "lblResultNoMissCount";
            this.lblResultNoMissCount.Size = new System.Drawing.Size(75, 12);
            this.lblResultNoMissCount.TabIndex = 2;
            this.lblResultNoMissCount.Text = "連続ノーミス数";
            // 
            // FormExecDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 298);
            this.Controls.Add(this.lblResultNoMissCount);
            this.Controls.Add(this.lblResultMissType);
            this.Controls.Add(this.lblResultETime);
            this.Controls.Add(this.lblResultWord);
            this.Controls.Add(this.pPanel);
            this.Controls.Add(this.lblMissTypes);
            this.Controls.Add(this.lblCorrect);
            this.Controls.Add(this.lblInputed);
            this.Controls.Add(this.lblWord);
            this.Name = "FormExecDebug";
            this.Text = "FormExecDebug";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormExecDebug_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblInputed;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.Label lblMissTypes;
        private PicturePanel pPanel;
        private System.Windows.Forms.Label lblResultWord;
        private System.Windows.Forms.Label lblResultETime;
        private System.Windows.Forms.Label lblResultMissType;
        private System.Windows.Forms.Label lblResultNoMissCount;
    }
}