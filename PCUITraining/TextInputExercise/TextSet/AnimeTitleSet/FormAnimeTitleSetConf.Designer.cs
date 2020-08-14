namespace TextInputExercise.TextSet.AnimeTitleSet
{
    partial class FormAnimeTitleSetConf
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gBoxCommon = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCommon = new System.Windows.Forms.TableLayoutPanel();
            this.lblMarqueeUpdateInterval = new System.Windows.Forms.Label();
            this.lblMarqueeAmountOfMovement = new System.Windows.Forms.Label();
            this.lblEnableAnimePokemon = new System.Windows.Forms.Label();
            this.lblEnableAnimeNaruto = new System.Windows.Forms.Label();
            this.lblEnableAnimeBoruto = new System.Windows.Forms.Label();
            this.bLblEnableAnimePokemon = new PCUITCommon.Views.BoolLabel();
            this.bLblEnableAnimeNaruto = new PCUITCommon.Views.BoolLabel();
            this.bLblEnableAnimeBoruto = new PCUITCommon.Views.BoolLabel();
            this.numMarqueeUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.numMarqueeAmountOfMovement = new System.Windows.Forms.NumericUpDown();
            this.gBoxUser = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelUser = new System.Windows.Forms.TableLayoutPanel();
            this.lblShowTextResult = new System.Windows.Forms.Label();
            this.bLblShowTextResult = new PCUITCommon.Views.BoolLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.gBoxCommon.SuspendLayout();
            this.tableLayoutPanelCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMarqueeUpdateInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarqueeAmountOfMovement)).BeginInit();
            this.gBoxUser.SuspendLayout();
            this.tableLayoutPanelUser.SuspendLayout();
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
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1019, 833);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(512, 751);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(504, 79);
            this.btnCancel.TabIndex = 107;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(3, 751);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(503, 79);
            this.btnSave.TabIndex = 106;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.gBoxCommon.Size = new System.Drawing.Size(1013, 618);
            this.gBoxCommon.TabIndex = 108;
            this.gBoxCommon.TabStop = false;
            this.gBoxCommon.Text = "共通設定";
            // 
            // tableLayoutPanelCommon
            // 
            this.tableLayoutPanelCommon.ColumnCount = 2;
            this.tableLayoutPanelCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelCommon.Controls.Add(this.lblMarqueeUpdateInterval, 0, 0);
            this.tableLayoutPanelCommon.Controls.Add(this.lblMarqueeAmountOfMovement, 0, 1);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableAnimePokemon, 0, 2);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableAnimeNaruto, 0, 3);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableAnimeBoruto, 0, 4);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableAnimePokemon, 1, 2);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableAnimeNaruto, 1, 3);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableAnimeBoruto, 1, 4);
            this.tableLayoutPanelCommon.Controls.Add(this.numMarqueeUpdateInterval, 1, 0);
            this.tableLayoutPanelCommon.Controls.Add(this.numMarqueeAmountOfMovement, 1, 1);
            this.tableLayoutPanelCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCommon.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanelCommon.Name = "tableLayoutPanelCommon";
            this.tableLayoutPanelCommon.RowCount = 7;
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.Size = new System.Drawing.Size(1007, 564);
            this.tableLayoutPanelCommon.TabIndex = 0;
            // 
            // lblMarqueeUpdateInterval
            // 
            this.lblMarqueeUpdateInterval.AutoSize = true;
            this.lblMarqueeUpdateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarqueeUpdateInterval.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMarqueeUpdateInterval.ForeColor = System.Drawing.Color.White;
            this.lblMarqueeUpdateInterval.Location = new System.Drawing.Point(3, 0);
            this.lblMarqueeUpdateInterval.Name = "lblMarqueeUpdateInterval";
            this.lblMarqueeUpdateInterval.Size = new System.Drawing.Size(698, 80);
            this.lblMarqueeUpdateInterval.TabIndex = 1;
            this.lblMarqueeUpdateInterval.Text = "画像マーキーの更新間隔";
            this.lblMarqueeUpdateInterval.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMarqueeAmountOfMovement
            // 
            this.lblMarqueeAmountOfMovement.AutoSize = true;
            this.lblMarqueeAmountOfMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarqueeAmountOfMovement.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMarqueeAmountOfMovement.ForeColor = System.Drawing.Color.White;
            this.lblMarqueeAmountOfMovement.Location = new System.Drawing.Point(3, 80);
            this.lblMarqueeAmountOfMovement.Name = "lblMarqueeAmountOfMovement";
            this.lblMarqueeAmountOfMovement.Size = new System.Drawing.Size(698, 80);
            this.lblMarqueeAmountOfMovement.TabIndex = 1;
            this.lblMarqueeAmountOfMovement.Text = "画像マーキーの移動量";
            this.lblMarqueeAmountOfMovement.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnableAnimePokemon
            // 
            this.lblEnableAnimePokemon.AutoSize = true;
            this.lblEnableAnimePokemon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableAnimePokemon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableAnimePokemon.ForeColor = System.Drawing.Color.White;
            this.lblEnableAnimePokemon.Location = new System.Drawing.Point(3, 160);
            this.lblEnableAnimePokemon.Name = "lblEnableAnimePokemon";
            this.lblEnableAnimePokemon.Size = new System.Drawing.Size(698, 80);
            this.lblEnableAnimePokemon.TabIndex = 1;
            this.lblEnableAnimePokemon.Text = "ポケモンデータ有効";
            this.lblEnableAnimePokemon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnableAnimeNaruto
            // 
            this.lblEnableAnimeNaruto.AutoSize = true;
            this.lblEnableAnimeNaruto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableAnimeNaruto.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableAnimeNaruto.ForeColor = System.Drawing.Color.White;
            this.lblEnableAnimeNaruto.Location = new System.Drawing.Point(3, 240);
            this.lblEnableAnimeNaruto.Name = "lblEnableAnimeNaruto";
            this.lblEnableAnimeNaruto.Size = new System.Drawing.Size(698, 80);
            this.lblEnableAnimeNaruto.TabIndex = 1;
            this.lblEnableAnimeNaruto.Text = "NARUTOデータ有効";
            this.lblEnableAnimeNaruto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnableAnimeBoruto
            // 
            this.lblEnableAnimeBoruto.AutoSize = true;
            this.lblEnableAnimeBoruto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableAnimeBoruto.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableAnimeBoruto.ForeColor = System.Drawing.Color.White;
            this.lblEnableAnimeBoruto.Location = new System.Drawing.Point(3, 320);
            this.lblEnableAnimeBoruto.Name = "lblEnableAnimeBoruto";
            this.lblEnableAnimeBoruto.Size = new System.Drawing.Size(698, 80);
            this.lblEnableAnimeBoruto.TabIndex = 1;
            this.lblEnableAnimeBoruto.Text = "BORUTOデータ有効";
            this.lblEnableAnimeBoruto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblEnableAnimePokemon
            // 
            this.bLblEnableAnimePokemon.AutoSize = true;
            this.bLblEnableAnimePokemon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableAnimePokemon.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableAnimePokemon.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableAnimePokemon.Location = new System.Drawing.Point(707, 160);
            this.bLblEnableAnimePokemon.Name = "bLblEnableAnimePokemon";
            this.bLblEnableAnimePokemon.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableAnimePokemon.TabIndex = 2;
            this.bLblEnableAnimePokemon.Text = "いいえ";
            this.bLblEnableAnimePokemon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableAnimePokemon.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblEnableAnimeNaruto
            // 
            this.bLblEnableAnimeNaruto.AutoSize = true;
            this.bLblEnableAnimeNaruto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableAnimeNaruto.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableAnimeNaruto.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableAnimeNaruto.Location = new System.Drawing.Point(707, 240);
            this.bLblEnableAnimeNaruto.Name = "bLblEnableAnimeNaruto";
            this.bLblEnableAnimeNaruto.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableAnimeNaruto.TabIndex = 2;
            this.bLblEnableAnimeNaruto.Text = "いいえ";
            this.bLblEnableAnimeNaruto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableAnimeNaruto.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblEnableAnimeBoruto
            // 
            this.bLblEnableAnimeBoruto.AutoSize = true;
            this.bLblEnableAnimeBoruto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableAnimeBoruto.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableAnimeBoruto.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableAnimeBoruto.Location = new System.Drawing.Point(707, 320);
            this.bLblEnableAnimeBoruto.Name = "bLblEnableAnimeBoruto";
            this.bLblEnableAnimeBoruto.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableAnimeBoruto.TabIndex = 2;
            this.bLblEnableAnimeBoruto.Text = "いいえ";
            this.bLblEnableAnimeBoruto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableAnimeBoruto.TrueColor = System.Drawing.Color.Aqua;
            // 
            // numMarqueeUpdateInterval
            // 
            this.numMarqueeUpdateInterval.BackColor = System.Drawing.Color.DimGray;
            this.numMarqueeUpdateInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numMarqueeUpdateInterval.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numMarqueeUpdateInterval.ForeColor = System.Drawing.Color.Aqua;
            this.numMarqueeUpdateInterval.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numMarqueeUpdateInterval.Location = new System.Drawing.Point(707, 3);
            this.numMarqueeUpdateInterval.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numMarqueeUpdateInterval.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMarqueeUpdateInterval.Name = "numMarqueeUpdateInterval";
            this.numMarqueeUpdateInterval.ReadOnly = true;
            this.numMarqueeUpdateInterval.Size = new System.Drawing.Size(297, 55);
            this.numMarqueeUpdateInterval.TabIndex = 0;
            this.numMarqueeUpdateInterval.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numMarqueeAmountOfMovement
            // 
            this.numMarqueeAmountOfMovement.BackColor = System.Drawing.Color.DimGray;
            this.numMarqueeAmountOfMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numMarqueeAmountOfMovement.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numMarqueeAmountOfMovement.ForeColor = System.Drawing.Color.Aqua;
            this.numMarqueeAmountOfMovement.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numMarqueeAmountOfMovement.Location = new System.Drawing.Point(707, 83);
            this.numMarqueeAmountOfMovement.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numMarqueeAmountOfMovement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMarqueeAmountOfMovement.Name = "numMarqueeAmountOfMovement";
            this.numMarqueeAmountOfMovement.ReadOnly = true;
            this.numMarqueeAmountOfMovement.Size = new System.Drawing.Size(297, 55);
            this.numMarqueeAmountOfMovement.TabIndex = 0;
            this.numMarqueeAmountOfMovement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gBoxUser
            // 
            this.tableLayoutPanel.SetColumnSpan(this.gBoxUser, 2);
            this.gBoxUser.Controls.Add(this.tableLayoutPanelUser);
            this.gBoxUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxUser.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gBoxUser.ForeColor = System.Drawing.Color.Yellow;
            this.gBoxUser.Location = new System.Drawing.Point(3, 627);
            this.gBoxUser.Name = "gBoxUser";
            this.gBoxUser.Size = new System.Drawing.Size(1013, 118);
            this.gBoxUser.TabIndex = 108;
            this.gBoxUser.TabStop = false;
            this.gBoxUser.Text = "ユーザー個別設定";
            // 
            // tableLayoutPanelUser
            // 
            this.tableLayoutPanelUser.ColumnCount = 2;
            this.tableLayoutPanelUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelUser.Controls.Add(this.lblShowTextResult, 0, 0);
            this.tableLayoutPanelUser.Controls.Add(this.bLblShowTextResult, 1, 0);
            this.tableLayoutPanelUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUser.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanelUser.Name = "tableLayoutPanelUser";
            this.tableLayoutPanelUser.RowCount = 1;
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUser.Size = new System.Drawing.Size(1007, 64);
            this.tableLayoutPanelUser.TabIndex = 0;
            // 
            // lblShowTextResult
            // 
            this.lblShowTextResult.AutoSize = true;
            this.lblShowTextResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShowTextResult.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblShowTextResult.ForeColor = System.Drawing.Color.White;
            this.lblShowTextResult.Location = new System.Drawing.Point(3, 0);
            this.lblShowTextResult.Name = "lblShowTextResult";
            this.lblShowTextResult.Size = new System.Drawing.Size(698, 64);
            this.lblShowTextResult.TabIndex = 1;
            this.lblShowTextResult.Text = "文章入力毎に結果を表示する";
            this.lblShowTextResult.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblShowTextResult
            // 
            this.bLblShowTextResult.AutoSize = true;
            this.bLblShowTextResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblShowTextResult.FalseColor = System.Drawing.Color.Red;
            this.bLblShowTextResult.ForeColor = System.Drawing.Color.Red;
            this.bLblShowTextResult.Location = new System.Drawing.Point(707, 0);
            this.bLblShowTextResult.Name = "bLblShowTextResult";
            this.bLblShowTextResult.Size = new System.Drawing.Size(297, 64);
            this.bLblShowTextResult.TabIndex = 2;
            this.bLblShowTextResult.Text = "いいえ";
            this.bLblShowTextResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblShowTextResult.TrueColor = System.Drawing.Color.Aqua;
            // 
            // FormAnimeTitleSetConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1019, 833);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAnimeTitleSetConf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPokemonSetConf";
            this.tableLayoutPanel.ResumeLayout(false);
            this.gBoxCommon.ResumeLayout(false);
            this.tableLayoutPanelCommon.ResumeLayout(false);
            this.tableLayoutPanelCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMarqueeUpdateInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarqueeAmountOfMovement)).EndInit();
            this.gBoxUser.ResumeLayout(false);
            this.tableLayoutPanelUser.ResumeLayout(false);
            this.tableLayoutPanelUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gBoxCommon;
        private System.Windows.Forms.GroupBox gBoxUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCommon;
        private System.Windows.Forms.Label lblShowTextResult;
        private System.Windows.Forms.Label lblMarqueeUpdateInterval;
        private System.Windows.Forms.Label lblMarqueeAmountOfMovement;
        private System.Windows.Forms.Label lblEnableAnimePokemon;
        private System.Windows.Forms.Label lblEnableAnimeNaruto;
        private System.Windows.Forms.Label lblEnableAnimeBoruto;
        private PCUITCommon.Views.BoolLabel bLblShowTextResult;
        private PCUITCommon.Views.BoolLabel bLblEnableAnimePokemon;
        private PCUITCommon.Views.BoolLabel bLblEnableAnimeNaruto;
        private PCUITCommon.Views.BoolLabel bLblEnableAnimeBoruto;
        private System.Windows.Forms.NumericUpDown numMarqueeUpdateInterval;
        private System.Windows.Forms.NumericUpDown numMarqueeAmountOfMovement;
    }
}