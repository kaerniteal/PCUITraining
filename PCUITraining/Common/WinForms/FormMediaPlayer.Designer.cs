namespace Common.WinForms
{
    partial class FormMediaPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMediaPlayer));
            this.ComMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.ComMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // ComMediaPlayer
            // 
            this.ComMediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComMediaPlayer.Enabled = true;
            this.ComMediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.ComMediaPlayer.Name = "ComMediaPlayer";
            this.ComMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ComMediaPlayer.OcxState")));
            this.ComMediaPlayer.Size = new System.Drawing.Size(430, 236);
            this.ComMediaPlayer.TabIndex = 0;
            this.ComMediaPlayer.Visible = false;
            this.ComMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.ComMediaPlayer_PlayStateChange);
            // 
            // FormMediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 236);
            this.Controls.Add(this.ComMediaPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMediaPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMediaPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.ComMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer ComMediaPlayer;
    }
}