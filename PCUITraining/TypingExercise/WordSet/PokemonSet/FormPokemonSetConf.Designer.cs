namespace TypingExercise.WordSet.PokemonSet
{
    partial class FormPokemonSetConf
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gBoxCommon = new System.Windows.Forms.GroupBox();
            this.gBoxUser = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCommon = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelUser = new System.Windows.Forms.TableLayoutPanel();
            this.numKeybordFont = new System.Windows.Forms.NumericUpDown();
            this.lblKeybordFontSize = new System.Windows.Forms.Label();
            this.lblShowCorrectSpelling = new System.Windows.Forms.Label();
            this.lblShowKeybord = new System.Windows.Forms.Label();
            this.lblShowFinger = new System.Windows.Forms.Label();
            this.lblShowWordResult = new System.Windows.Forms.Label();
            this.lblShowSpellUpper = new System.Windows.Forms.Label();
            this.lblShowAllSpell = new System.Windows.Forms.Label();
            this.bLblShowCorrectSpelling = new PCUITCommon.Views.BoolLabel();
            this.bLblShowKeybord = new PCUITCommon.Views.BoolLabel();
            this.bLblShowFinger = new PCUITCommon.Views.BoolLabel();
            this.bLblShowWordResult = new PCUITCommon.Views.BoolLabel();
            this.bLblShowSpellUpper = new PCUITCommon.Views.BoolLabel();
            this.bLblShowAllSpell = new PCUITCommon.Views.BoolLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.gBoxCommon.SuspendLayout();
            this.gBoxUser.SuspendLayout();
            this.tableLayoutPanelCommon.SuspendLayout();
            this.tableLayoutPanelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeybordFont)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.btnCancel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.btnSave, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.gBoxCommon, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gBoxUser, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(986, 833);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(3, 752);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(487, 78);
            this.btnSave.TabIndex = 106;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(496, 752);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(487, 78);
            this.btnCancel.TabIndex = 107;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // gBoxCommon
            // 
            this.tableLayoutPanel.SetColumnSpan(this.gBoxCommon, 2);
            this.gBoxCommon.Controls.Add(this.tableLayoutPanelCommon);
            this.gBoxCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxCommon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gBoxCommon.ForeColor = System.Drawing.Color.Yellow;
            this.gBoxCommon.Location = new System.Drawing.Point(3, 3);
            this.gBoxCommon.Name = "gBoxCommon";
            this.gBoxCommon.Size = new System.Drawing.Size(980, 160);
            this.gBoxCommon.TabIndex = 108;
            this.gBoxCommon.TabStop = false;
            this.gBoxCommon.Text = "共通設定";
            // 
            // gBoxUser
            // 
            this.tableLayoutPanel.SetColumnSpan(this.gBoxUser, 2);
            this.gBoxUser.Controls.Add(this.tableLayoutPanelUser);
            this.gBoxUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxUser.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gBoxUser.ForeColor = System.Drawing.Color.Yellow;
            this.gBoxUser.Location = new System.Drawing.Point(3, 169);
            this.gBoxUser.Name = "gBoxUser";
            this.gBoxUser.Size = new System.Drawing.Size(980, 577);
            this.gBoxUser.TabIndex = 108;
            this.gBoxUser.TabStop = false;
            this.gBoxUser.Text = "ユーザー個別設定";
            // 
            // tableLayoutPanelCommon
            // 
            this.tableLayoutPanelCommon.ColumnCount = 2;
            this.tableLayoutPanelCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelCommon.Controls.Add(this.numKeybordFont, 1, 0);
            this.tableLayoutPanelCommon.Controls.Add(this.lblKeybordFontSize, 0, 0);
            this.tableLayoutPanelCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCommon.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanelCommon.Name = "tableLayoutPanelCommon";
            this.tableLayoutPanelCommon.RowCount = 1;
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCommon.Size = new System.Drawing.Size(974, 106);
            this.tableLayoutPanelCommon.TabIndex = 0;
            // 
            // tableLayoutPanelUser
            // 
            this.tableLayoutPanelUser.ColumnCount = 2;
            this.tableLayoutPanelUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelUser.Controls.Add(this.lblShowCorrectSpelling, 0, 0);
            this.tableLayoutPanelUser.Controls.Add(this.lblShowKeybord, 0, 1);
            this.tableLayoutPanelUser.Controls.Add(this.lblShowFinger, 0, 2);
            this.tableLayoutPanelUser.Controls.Add(this.lblShowWordResult, 0, 3);
            this.tableLayoutPanelUser.Controls.Add(this.lblShowSpellUpper, 0, 4);
            this.tableLayoutPanelUser.Controls.Add(this.lblShowAllSpell, 0, 5);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowCorrectSpelling, 1, 0);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowKeybord, 1, 1);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowFinger, 1, 2);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowWordResult, 1, 3);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowSpellUpper, 1, 4);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowAllSpell, 1, 5);
            this.tableLayoutPanelUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUser.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanelUser.Name = "tableLayoutPanelUser";
            this.tableLayoutPanelUser.RowCount = 6;
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelUser.Size = new System.Drawing.Size(974, 523);
            this.tableLayoutPanelUser.TabIndex = 0;
            // 
            // numKeybordFont
            // 
            this.numKeybordFont.BackColor = System.Drawing.Color.DimGray;
            this.numKeybordFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numKeybordFont.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numKeybordFont.ForeColor = System.Drawing.Color.Aqua;
            this.numKeybordFont.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numKeybordFont.Location = new System.Drawing.Point(684, 3);
            this.numKeybordFont.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numKeybordFont.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numKeybordFont.Name = "numKeybordFont";
            this.numKeybordFont.ReadOnly = true;
            this.numKeybordFont.Size = new System.Drawing.Size(287, 55);
            this.numKeybordFont.TabIndex = 0;
            this.numKeybordFont.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblKeybordFontSize
            // 
            this.lblKeybordFontSize.AutoSize = true;
            this.lblKeybordFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeybordFontSize.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKeybordFontSize.ForeColor = System.Drawing.Color.White;
            this.lblKeybordFontSize.Location = new System.Drawing.Point(3, 0);
            this.lblKeybordFontSize.Name = "lblKeybordFontSize";
            this.lblKeybordFontSize.Size = new System.Drawing.Size(675, 106);
            this.lblKeybordFontSize.TabIndex = 1;
            this.lblKeybordFontSize.Text = "キーボードのフォントサイズ";
            this.lblKeybordFontSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShowCorrectSpelling
            // 
            this.lblShowCorrectSpelling.AutoSize = true;
            this.lblShowCorrectSpelling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowCorrectSpelling.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowCorrectSpelling.ForeColor = System.Drawing.Color.White;
            this.lblShowCorrectSpelling.Location = new System.Drawing.Point(3, 0);
            this.lblShowCorrectSpelling.Name = "lblShowCorrectSpelling";
            this.lblShowCorrectSpelling.Size = new System.Drawing.Size(675, 87);
            this.lblShowCorrectSpelling.TabIndex = 1;
            this.lblShowCorrectSpelling.Text = "綴りを表示する";
            this.lblShowCorrectSpelling.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShowKeybord
            // 
            this.lblShowKeybord.AutoSize = true;
            this.lblShowKeybord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowKeybord.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowKeybord.ForeColor = System.Drawing.Color.White;
            this.lblShowKeybord.Location = new System.Drawing.Point(3, 87);
            this.lblShowKeybord.Name = "lblShowKeybord";
            this.lblShowKeybord.Size = new System.Drawing.Size(675, 87);
            this.lblShowKeybord.TabIndex = 1;
            this.lblShowKeybord.Text = "キーボードナビを表示する";
            this.lblShowKeybord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShowFinger
            // 
            this.lblShowFinger.AutoSize = true;
            this.lblShowFinger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowFinger.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowFinger.ForeColor = System.Drawing.Color.White;
            this.lblShowFinger.Location = new System.Drawing.Point(3, 174);
            this.lblShowFinger.Name = "lblShowFinger";
            this.lblShowFinger.Size = new System.Drawing.Size(675, 87);
            this.lblShowFinger.TabIndex = 1;
            this.lblShowFinger.Text = "指ナビを表示する";
            this.lblShowFinger.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShowWordResult
            // 
            this.lblShowWordResult.AutoSize = true;
            this.lblShowWordResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowWordResult.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowWordResult.ForeColor = System.Drawing.Color.White;
            this.lblShowWordResult.Location = new System.Drawing.Point(3, 261);
            this.lblShowWordResult.Name = "lblShowWordResult";
            this.lblShowWordResult.Size = new System.Drawing.Size(675, 87);
            this.lblShowWordResult.TabIndex = 1;
            this.lblShowWordResult.Text = "単語入力毎に結果を表示する";
            this.lblShowWordResult.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShowSpellUpper
            // 
            this.lblShowSpellUpper.AutoSize = true;
            this.lblShowSpellUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowSpellUpper.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowSpellUpper.ForeColor = System.Drawing.Color.White;
            this.lblShowSpellUpper.Location = new System.Drawing.Point(3, 348);
            this.lblShowSpellUpper.Name = "lblShowSpellUpper";
            this.lblShowSpellUpper.Size = new System.Drawing.Size(675, 87);
            this.lblShowSpellUpper.TabIndex = 1;
            this.lblShowSpellUpper.Text = "綴りを大文字で表示する";
            this.lblShowSpellUpper.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShowAllSpell
            // 
            this.lblShowAllSpell.AutoSize = true;
            this.lblShowAllSpell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowAllSpell.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowAllSpell.ForeColor = System.Drawing.Color.White;
            this.lblShowAllSpell.Location = new System.Drawing.Point(3, 435);
            this.lblShowAllSpell.Name = "lblShowAllSpell";
            this.lblShowAllSpell.Size = new System.Drawing.Size(675, 88);
            this.lblShowAllSpell.TabIndex = 1;
            this.lblShowAllSpell.Text = "綴り候補を全て表示する";
            this.lblShowAllSpell.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblShowCorrectSpelling
            // 
            this.bLblShowCorrectSpelling.AutoSize = true;
            this.bLblShowCorrectSpelling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowCorrectSpelling.FalseColor = System.Drawing.Color.Red;
            this.bLblShowCorrectSpelling.ForeColor = System.Drawing.Color.Red;
            this.bLblShowCorrectSpelling.Location = new System.Drawing.Point(684, 0);
            this.bLblShowCorrectSpelling.Name = "bLblShowCorrectSpelling";
            this.bLblShowCorrectSpelling.Size = new System.Drawing.Size(287, 87);
            this.bLblShowCorrectSpelling.TabIndex = 2;
            this.bLblShowCorrectSpelling.Text = "いいえ";
            this.bLblShowCorrectSpelling.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowCorrectSpelling.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblShowKeybord
            // 
            this.bLblShowKeybord.AutoSize = true;
            this.bLblShowKeybord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowKeybord.FalseColor = System.Drawing.Color.Red;
            this.bLblShowKeybord.ForeColor = System.Drawing.Color.Red;
            this.bLblShowKeybord.Location = new System.Drawing.Point(684, 87);
            this.bLblShowKeybord.Name = "bLblShowKeybord";
            this.bLblShowKeybord.Size = new System.Drawing.Size(287, 87);
            this.bLblShowKeybord.TabIndex = 2;
            this.bLblShowKeybord.Text = "いいえ";
            this.bLblShowKeybord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowKeybord.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblShowFinger
            // 
            this.bLblShowFinger.AutoSize = true;
            this.bLblShowFinger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowFinger.FalseColor = System.Drawing.Color.Red;
            this.bLblShowFinger.ForeColor = System.Drawing.Color.Red;
            this.bLblShowFinger.Location = new System.Drawing.Point(684, 174);
            this.bLblShowFinger.Name = "bLblShowFinger";
            this.bLblShowFinger.Size = new System.Drawing.Size(287, 87);
            this.bLblShowFinger.TabIndex = 2;
            this.bLblShowFinger.Text = "いいえ";
            this.bLblShowFinger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowFinger.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblShowWordResult
            // 
            this.bLblShowWordResult.AutoSize = true;
            this.bLblShowWordResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowWordResult.FalseColor = System.Drawing.Color.Red;
            this.bLblShowWordResult.ForeColor = System.Drawing.Color.Red;
            this.bLblShowWordResult.Location = new System.Drawing.Point(684, 261);
            this.bLblShowWordResult.Name = "bLblShowWordResult";
            this.bLblShowWordResult.Size = new System.Drawing.Size(287, 87);
            this.bLblShowWordResult.TabIndex = 2;
            this.bLblShowWordResult.Text = "いいえ";
            this.bLblShowWordResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowWordResult.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblShowSpellUpper
            // 
            this.bLblShowSpellUpper.AutoSize = true;
            this.bLblShowSpellUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowSpellUpper.FalseColor = System.Drawing.Color.Red;
            this.bLblShowSpellUpper.ForeColor = System.Drawing.Color.Red;
            this.bLblShowSpellUpper.Location = new System.Drawing.Point(684, 348);
            this.bLblShowSpellUpper.Name = "bLblShowSpellUpper";
            this.bLblShowSpellUpper.Size = new System.Drawing.Size(287, 87);
            this.bLblShowSpellUpper.TabIndex = 2;
            this.bLblShowSpellUpper.Text = "いいえ";
            this.bLblShowSpellUpper.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowSpellUpper.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblShowAllSpell
            // 
            this.bLblShowAllSpell.AutoSize = true;
            this.bLblShowAllSpell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowAllSpell.FalseColor = System.Drawing.Color.Red;
            this.bLblShowAllSpell.ForeColor = System.Drawing.Color.Red;
            this.bLblShowAllSpell.Location = new System.Drawing.Point(684, 435);
            this.bLblShowAllSpell.Name = "bLblShowAllSpell";
            this.bLblShowAllSpell.Size = new System.Drawing.Size(287, 88);
            this.bLblShowAllSpell.TabIndex = 2;
            this.bLblShowAllSpell.Text = "いいえ";
            this.bLblShowAllSpell.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowAllSpell.TrueColor = System.Drawing.Color.Aqua;
            // 
            // FormPokemonSetConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(986, 833);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPokemonSetConf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPokemonSetConf";
            this.tableLayoutPanel.ResumeLayout(false);
            this.gBoxCommon.ResumeLayout(false);
            this.gBoxUser.ResumeLayout(false);
            this.tableLayoutPanelCommon.ResumeLayout(false);
            this.tableLayoutPanelCommon.PerformLayout();
            this.tableLayoutPanelUser.ResumeLayout(false);
            this.tableLayoutPanelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeybordFont)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gBoxCommon;
        private System.Windows.Forms.GroupBox gBoxUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCommon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUser;
        private System.Windows.Forms.NumericUpDown numKeybordFont;
        private System.Windows.Forms.Label lblKeybordFontSize;
        private System.Windows.Forms.Label lblShowCorrectSpelling;
        private System.Windows.Forms.Label lblShowKeybord;
        private System.Windows.Forms.Label lblShowFinger;
        private System.Windows.Forms.Label lblShowWordResult;
        private System.Windows.Forms.Label lblShowSpellUpper;
        private System.Windows.Forms.Label lblShowAllSpell;
        private PCUITCommon.Views.BoolLabel bLblShowCorrectSpelling;
        private PCUITCommon.Views.BoolLabel bLblShowKeybord;
        private PCUITCommon.Views.BoolLabel bLblShowFinger;
        private PCUITCommon.Views.BoolLabel bLblShowWordResult;
        private PCUITCommon.Views.BoolLabel bLblShowSpellUpper;
        private PCUITCommon.Views.BoolLabel bLblShowAllSpell;
    }
}