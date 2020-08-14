namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    partial class FormInsectCollectingSetConf
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
            this.lblViewUpdateWait = new System.Windows.Forms.Label();
            this.lblUnitMax = new System.Windows.Forms.Label();
            this.lblEnableDifficultyVeryEasy = new System.Windows.Forms.Label();
            this.bLblEnableDifficultyVeryEasy = new PCUITCommon.Views.BoolLabel();
            this.numViewUpdateWait = new System.Windows.Forms.NumericUpDown();
            this.numUnitMax = new System.Windows.Forms.NumericUpDown();
            this.gBoxUser = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelUser = new System.Windows.Forms.TableLayoutPanel();
            this.lblEnableDifficultyEasy = new System.Windows.Forms.Label();
            this.bLblEnableDifficultyEasy = new PCUITCommon.Views.BoolLabel();
            this.lblEnableDifficultyNormal = new System.Windows.Forms.Label();
            this.lblEnableDifficultyHard = new System.Windows.Forms.Label();
            this.lblEnableDifficultyVeryHard = new System.Windows.Forms.Label();
            this.bLblEnableDifficultyNormal = new PCUITCommon.Views.BoolLabel();
            this.bLblEnableDifficultyHard = new PCUITCommon.Views.BoolLabel();
            this.bLblEnableDifficultyVeryHard = new PCUITCommon.Views.BoolLabel();
            this.lblUseCustomMouseIcon = new System.Windows.Forms.Label();
            this.bLblUseCustomMouseIcon = new PCUITCommon.Views.BoolLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.gBoxCommon.SuspendLayout();
            this.tableLayoutPanelCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numViewUpdateWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitMax)).BeginInit();
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
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableDifficultyVeryHard, 1, 6);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableDifficultyHard, 1, 5);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableDifficultyNormal, 1, 4);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableDifficultyEasy, 1, 3);
            this.tableLayoutPanelCommon.Controls.Add(this.bLblEnableDifficultyVeryEasy, 1, 2);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableDifficultyEasy, 0, 3);
            this.tableLayoutPanelCommon.Controls.Add(this.lblViewUpdateWait, 0, 0);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableDifficultyVeryHard, 0, 6);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableDifficultyHard, 0, 5);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableDifficultyNormal, 0, 4);
            this.tableLayoutPanelCommon.Controls.Add(this.lblEnableDifficultyVeryEasy, 0, 2);
            this.tableLayoutPanelCommon.Controls.Add(this.lblUnitMax, 0, 1);
            this.tableLayoutPanelCommon.Controls.Add(this.numViewUpdateWait, 1, 0);
            this.tableLayoutPanelCommon.Controls.Add(this.numUnitMax, 1, 1);
            this.tableLayoutPanelCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCommon.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanelCommon.Name = "tableLayoutPanelCommon";
            this.tableLayoutPanelCommon.RowCount = 7;
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanelCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCommon.Size = new System.Drawing.Size(1007, 564);
            this.tableLayoutPanelCommon.TabIndex = 0;
            // 
            // lblViewUpdateWait
            // 
            this.lblViewUpdateWait.AutoSize = true;
            this.lblViewUpdateWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblViewUpdateWait.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblViewUpdateWait.ForeColor = System.Drawing.Color.White;
            this.lblViewUpdateWait.Location = new System.Drawing.Point(3, 0);
            this.lblViewUpdateWait.Name = "lblViewUpdateWait";
            this.lblViewUpdateWait.Size = new System.Drawing.Size(698, 80);
            this.lblViewUpdateWait.TabIndex = 1;
            this.lblViewUpdateWait.Text = "描画更新Wait(ms)";
            this.lblViewUpdateWait.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUnitMax
            // 
            this.lblUnitMax.AutoSize = true;
            this.lblUnitMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnitMax.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUnitMax.ForeColor = System.Drawing.Color.White;
            this.lblUnitMax.Location = new System.Drawing.Point(3, 80);
            this.lblUnitMax.Name = "lblUnitMax";
            this.lblUnitMax.Size = new System.Drawing.Size(698, 80);
            this.lblUnitMax.TabIndex = 1;
            this.lblUnitMax.Text = "描画オブジェクト最大数";
            this.lblUnitMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnableDifficultyVeryEasy
            // 
            this.lblEnableDifficultyVeryEasy.AutoSize = true;
            this.lblEnableDifficultyVeryEasy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableDifficultyVeryEasy.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableDifficultyVeryEasy.ForeColor = System.Drawing.Color.White;
            this.lblEnableDifficultyVeryEasy.Location = new System.Drawing.Point(3, 160);
            this.lblEnableDifficultyVeryEasy.Name = "lblEnableDifficultyVeryEasy";
            this.lblEnableDifficultyVeryEasy.Size = new System.Drawing.Size(698, 80);
            this.lblEnableDifficultyVeryEasy.TabIndex = 1;
            this.lblEnableDifficultyVeryEasy.Text = "ベリーイージー有効";
            this.lblEnableDifficultyVeryEasy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblEnableDifficultyVeryEasy
            // 
            this.bLblEnableDifficultyVeryEasy.AutoSize = true;
            this.bLblEnableDifficultyVeryEasy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableDifficultyVeryEasy.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyVeryEasy.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyVeryEasy.Location = new System.Drawing.Point(707, 160);
            this.bLblEnableDifficultyVeryEasy.Name = "bLblEnableDifficultyVeryEasy";
            this.bLblEnableDifficultyVeryEasy.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableDifficultyVeryEasy.TabIndex = 2;
            this.bLblEnableDifficultyVeryEasy.Text = "いいえ";
            this.bLblEnableDifficultyVeryEasy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableDifficultyVeryEasy.TrueColor = System.Drawing.Color.Aqua;
            // 
            // numViewUpdateWait
            // 
            this.numViewUpdateWait.BackColor = System.Drawing.Color.DimGray;
            this.numViewUpdateWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numViewUpdateWait.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numViewUpdateWait.ForeColor = System.Drawing.Color.Aqua;
            this.numViewUpdateWait.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numViewUpdateWait.Location = new System.Drawing.Point(707, 3);
            this.numViewUpdateWait.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numViewUpdateWait.Name = "numViewUpdateWait";
            this.numViewUpdateWait.ReadOnly = true;
            this.numViewUpdateWait.Size = new System.Drawing.Size(297, 55);
            this.numViewUpdateWait.TabIndex = 0;
            this.numViewUpdateWait.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numUnitMax
            // 
            this.numUnitMax.BackColor = System.Drawing.Color.DimGray;
            this.numUnitMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUnitMax.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numUnitMax.ForeColor = System.Drawing.Color.Aqua;
            this.numUnitMax.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numUnitMax.Location = new System.Drawing.Point(707, 83);
            this.numUnitMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUnitMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUnitMax.Name = "numUnitMax";
            this.numUnitMax.ReadOnly = true;
            this.numUnitMax.Size = new System.Drawing.Size(297, 55);
            this.numUnitMax.TabIndex = 0;
            this.numUnitMax.Value = new decimal(new int[] {
            10,
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
            this.tableLayoutPanelUser.Controls.Add(this.bLblUseCustomMouseIcon, 1, 0);
            this.tableLayoutPanelUser.Controls.Add(this.lblUseCustomMouseIcon, 0, 0);
            this.tableLayoutPanelUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUser.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanelUser.Name = "tableLayoutPanelUser";
            this.tableLayoutPanelUser.RowCount = 1;
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUser.Size = new System.Drawing.Size(1007, 64);
            this.tableLayoutPanelUser.TabIndex = 0;
            // 
            // lblEnableDifficultyEasy
            // 
            this.lblEnableDifficultyEasy.AutoSize = true;
            this.lblEnableDifficultyEasy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableDifficultyEasy.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableDifficultyEasy.ForeColor = System.Drawing.Color.White;
            this.lblEnableDifficultyEasy.Location = new System.Drawing.Point(3, 240);
            this.lblEnableDifficultyEasy.Name = "lblEnableDifficultyEasy";
            this.lblEnableDifficultyEasy.Size = new System.Drawing.Size(698, 80);
            this.lblEnableDifficultyEasy.TabIndex = 1;
            this.lblEnableDifficultyEasy.Text = "イージー有効";
            this.lblEnableDifficultyEasy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblEnableDifficultyEasy
            // 
            this.bLblEnableDifficultyEasy.AutoSize = true;
            this.bLblEnableDifficultyEasy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableDifficultyEasy.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyEasy.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyEasy.Location = new System.Drawing.Point(707, 240);
            this.bLblEnableDifficultyEasy.Name = "bLblEnableDifficultyEasy";
            this.bLblEnableDifficultyEasy.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableDifficultyEasy.TabIndex = 2;
            this.bLblEnableDifficultyEasy.Text = "いいえ";
            this.bLblEnableDifficultyEasy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableDifficultyEasy.TrueColor = System.Drawing.Color.Aqua;
            // 
            // lblEnableDifficultyNormal
            // 
            this.lblEnableDifficultyNormal.AutoSize = true;
            this.lblEnableDifficultyNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableDifficultyNormal.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableDifficultyNormal.ForeColor = System.Drawing.Color.White;
            this.lblEnableDifficultyNormal.Location = new System.Drawing.Point(3, 320);
            this.lblEnableDifficultyNormal.Name = "lblEnableDifficultyNormal";
            this.lblEnableDifficultyNormal.Size = new System.Drawing.Size(698, 80);
            this.lblEnableDifficultyNormal.TabIndex = 1;
            this.lblEnableDifficultyNormal.Text = "ノーマル有効";
            this.lblEnableDifficultyNormal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnableDifficultyHard
            // 
            this.lblEnableDifficultyHard.AutoSize = true;
            this.lblEnableDifficultyHard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableDifficultyHard.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableDifficultyHard.ForeColor = System.Drawing.Color.White;
            this.lblEnableDifficultyHard.Location = new System.Drawing.Point(3, 400);
            this.lblEnableDifficultyHard.Name = "lblEnableDifficultyHard";
            this.lblEnableDifficultyHard.Size = new System.Drawing.Size(698, 80);
            this.lblEnableDifficultyHard.TabIndex = 1;
            this.lblEnableDifficultyHard.Text = "ハード有効";
            this.lblEnableDifficultyHard.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnableDifficultyVeryHard
            // 
            this.lblEnableDifficultyVeryHard.AutoSize = true;
            this.lblEnableDifficultyVeryHard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableDifficultyVeryHard.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEnableDifficultyVeryHard.ForeColor = System.Drawing.Color.White;
            this.lblEnableDifficultyVeryHard.Location = new System.Drawing.Point(3, 480);
            this.lblEnableDifficultyVeryHard.Name = "lblEnableDifficultyVeryHard";
            this.lblEnableDifficultyVeryHard.Size = new System.Drawing.Size(698, 84);
            this.lblEnableDifficultyVeryHard.TabIndex = 1;
            this.lblEnableDifficultyVeryHard.Text = "ベリーハード有効";
            this.lblEnableDifficultyVeryHard.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblEnableDifficultyNormal
            // 
            this.bLblEnableDifficultyNormal.AutoSize = true;
            this.bLblEnableDifficultyNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableDifficultyNormal.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyNormal.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyNormal.Location = new System.Drawing.Point(707, 320);
            this.bLblEnableDifficultyNormal.Name = "bLblEnableDifficultyNormal";
            this.bLblEnableDifficultyNormal.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableDifficultyNormal.TabIndex = 2;
            this.bLblEnableDifficultyNormal.Text = "いいえ";
            this.bLblEnableDifficultyNormal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableDifficultyNormal.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblEnableDifficultyHard
            // 
            this.bLblEnableDifficultyHard.AutoSize = true;
            this.bLblEnableDifficultyHard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableDifficultyHard.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyHard.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyHard.Location = new System.Drawing.Point(707, 400);
            this.bLblEnableDifficultyHard.Name = "bLblEnableDifficultyHard";
            this.bLblEnableDifficultyHard.Size = new System.Drawing.Size(297, 80);
            this.bLblEnableDifficultyHard.TabIndex = 2;
            this.bLblEnableDifficultyHard.Text = "いいえ";
            this.bLblEnableDifficultyHard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableDifficultyHard.TrueColor = System.Drawing.Color.Aqua;
            // 
            // bLblEnableDifficultyVeryHard
            // 
            this.bLblEnableDifficultyVeryHard.AutoSize = true;
            this.bLblEnableDifficultyVeryHard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblEnableDifficultyVeryHard.FalseColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyVeryHard.ForeColor = System.Drawing.Color.Red;
            this.bLblEnableDifficultyVeryHard.Location = new System.Drawing.Point(707, 480);
            this.bLblEnableDifficultyVeryHard.Name = "bLblEnableDifficultyVeryHard";
            this.bLblEnableDifficultyVeryHard.Size = new System.Drawing.Size(297, 84);
            this.bLblEnableDifficultyVeryHard.TabIndex = 2;
            this.bLblEnableDifficultyVeryHard.Text = "いいえ";
            this.bLblEnableDifficultyVeryHard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblEnableDifficultyVeryHard.TrueColor = System.Drawing.Color.Aqua;
            // 
            // lblUseCustomMouseIcon
            // 
            this.lblUseCustomMouseIcon.AutoSize = true;
            this.lblUseCustomMouseIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUseCustomMouseIcon.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUseCustomMouseIcon.ForeColor = System.Drawing.Color.White;
            this.lblUseCustomMouseIcon.Location = new System.Drawing.Point(3, 0);
            this.lblUseCustomMouseIcon.Name = "lblUseCustomMouseIcon";
            this.lblUseCustomMouseIcon.Size = new System.Drawing.Size(698, 64);
            this.lblUseCustomMouseIcon.TabIndex = 1;
            this.lblUseCustomMouseIcon.Text = "マウスアイコンを変更する";
            this.lblUseCustomMouseIcon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bLblUseCustomMouseIcon
            // 
            this.bLblUseCustomMouseIcon.AutoSize = true;
            this.bLblUseCustomMouseIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bLblUseCustomMouseIcon.FalseColor = System.Drawing.Color.Red;
            this.bLblUseCustomMouseIcon.ForeColor = System.Drawing.Color.Red;
            this.bLblUseCustomMouseIcon.Location = new System.Drawing.Point(707, 0);
            this.bLblUseCustomMouseIcon.Name = "bLblUseCustomMouseIcon";
            this.bLblUseCustomMouseIcon.Size = new System.Drawing.Size(297, 64);
            this.bLblUseCustomMouseIcon.TabIndex = 2;
            this.bLblUseCustomMouseIcon.Text = "いいえ";
            this.bLblUseCustomMouseIcon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLblUseCustomMouseIcon.TrueColor = System.Drawing.Color.Aqua;
            // 
            // FormInsectCollectingSetConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1019, 833);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInsectCollectingSetConf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPokemonSetConf";
            this.tableLayoutPanel.ResumeLayout(false);
            this.gBoxCommon.ResumeLayout(false);
            this.tableLayoutPanelCommon.ResumeLayout(false);
            this.tableLayoutPanelCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numViewUpdateWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitMax)).EndInit();
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
        private System.Windows.Forms.Label lblViewUpdateWait;
        private System.Windows.Forms.Label lblUnitMax;
        private System.Windows.Forms.Label lblEnableDifficultyVeryEasy;
        private PCUITCommon.Views.BoolLabel bLblEnableDifficultyVeryEasy;
        private System.Windows.Forms.NumericUpDown numViewUpdateWait;
        private System.Windows.Forms.NumericUpDown numUnitMax;
        private System.Windows.Forms.Label lblEnableDifficultyEasy;
        private PCUITCommon.Views.BoolLabel bLblEnableDifficultyEasy;
        private System.Windows.Forms.Label lblEnableDifficultyNormal;
        private System.Windows.Forms.Label lblEnableDifficultyHard;
        private System.Windows.Forms.Label lblEnableDifficultyVeryHard;
        private PCUITCommon.Views.BoolLabel bLblEnableDifficultyNormal;
        private PCUITCommon.Views.BoolLabel bLblEnableDifficultyHard;
        private PCUITCommon.Views.BoolLabel bLblEnableDifficultyVeryHard;
        private PCUITCommon.Views.BoolLabel bLblUseCustomMouseIcon;
        private System.Windows.Forms.Label lblUseCustomMouseIcon;
    }
}