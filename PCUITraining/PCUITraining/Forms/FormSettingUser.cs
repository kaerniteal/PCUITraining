using Common.Extentions;
using Common.Utilities;
using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace PCUITraining.Forms
{
    /// <summary>
    /// ユーザー設定ダイアログ.
    /// </summary>
    public partial class FormSettingUser : Form
    {
        /// <summary>
        /// 内部モード.
        /// </summary>
        private enum MODE
        {
            ADD,
            UPDATE,
        }

        /// <summary>
        /// 内部モード.
        /// </summary>
        private MODE Mode { get; set; }

        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// 画像のオリジナルパス.
        /// </summary>
        private string OrgImagePath { get; set; }


        /// <summary>
        /// コンストラクタ(新規作成).
        /// </summary>
        public FormSettingUser(UserIconGrp userIconGrp)
        {
            InitializeComponent();

            this.Mode = MODE.ADD;
            this.UserIconGrp = userIconGrp;
            this.UserData = new UserData();
            this.OrgImagePath = string.Empty;
        }

        /// <summary>
        /// コンストラクタ(更新).
        /// </summary>
        public FormSettingUser(UserIconGrp userIconGrp, UserData userData)
        {
            InitializeComponent();

            this.Mode = MODE.UPDATE;
            this.UserIconGrp = userIconGrp;
            this.UserData = userData;
            this.OrgImagePath = userData.CreateImageFilePath();

            this.tBoxName.ReadOnly = true;
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettingUser_Load(object sender, EventArgs e)
        {
            this.tBoxName.Text = this.UserData.Name;

            this.SetColorComb(this.UserData.GetFontColor());
            this.cmbbColor.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmbbColor.DrawItem += this.comboBox1_DrawItem;

            this.SetUseIconLbl(this.UserData.UseCustomIcon);

            this.SetIconImage();

            this.btnCancel.Focus();
        }

        /// <summary>
        /// カラーコンボボックスをセット.
        /// </summary>
        private void SetColorComb(Color defColor)
        {
            var colors = UtilColor.GetWebColors();
            foreach (var color in colors)
            {
                this.cmbbColor.Items.Add(color);
            }

            this.cmbbColor.SelectedItem = defColor;
        }

        /// <summary>
        /// コンボボックスのアイテム描画.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //コンボボックス
            var cmb = sender as ComboBox;
            if (null == cmb)
            {
                return;
            }

            //背景を描画する
            e.DrawBackground();

            //項目
            var color = (Color)cmb.Items[e.Index];

            //項目を描画
            using (var brush = new SolidBrush(color))
            {
                e.Graphics.DrawString(
                    color.Name,
                    e.Font,
                    brush,
                    e.Bounds.X,
                    e.Bounds.Y);
            }

            //フォーカスを示す四角形を描画
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// アイコン使用ラベルをセット.
        /// </summary>
        /// <param name="use">使用要否</param>
        private void SetUseIconLbl(bool use)
        {
            if (use)
            {
                this.lblBtnUseIcon.Text = "する";
                this.lblBtnUseIcon.ForeColor = Color.Aqua;
                this.btnSelectIcon.Enabled = true;
            }
            else
            {
                this.lblBtnUseIcon.Text = "しない";
                this.lblBtnUseIcon.ForeColor = Color.Red;
                this.btnSelectIcon.Enabled = false;
            }
        }

        /// <summary>
        /// イメージをセットする.
        /// </summary>
        private void SetIconImage()
        {
            var icon = this.UserData.LoadIcon();
            if (null != icon)
            {
                this.btnSelectIcon.Image = icon;
            }
        }

        /// <summary>
        /// アイコン使用クリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblBtnUseIcon_Click(object sender, EventArgs e)
        {
            // 反転させる.
            this.UserData.UseCustomIcon = !this.UserData.UseCustomIcon;
            this.SetUseIconLbl(this.UserData.UseCustomIcon);
        }

        /// <summary>
        /// イメージ選択ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            // OpenFileDialogクラスのインスタンスを作成
            var ofd = new OpenFileDialog
            {
                Title = "画像を選択してください",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png",
            };

            // ダイアログを表示する
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }

            // PATHを取得.
            var path = ofd.FileName;
            if (!File.Exists(path))
            {
                return;
            }

            // オリジナルパスを確保.
            this.OrgImagePath = path;

            // ボタンに反映.
            this.btnSelectIcon.Image = new Bitmap(path);
        }

        /// <summary>
        /// 保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 入力チェック.
            var name = this.tBoxName.Text.Trim();
            if (name.IsEmpty())
            {
                FormMessageBox.Show("名前を入力してください。");
                return;
            }

            // 重複チェック.
            if (!this.UserIconGrp.CanAdd(name))
            {
                FormMessageBox.Show("[{0}]は既に存在します。\n違う名前を入力してください。".Fmt(name));
                return;
            }

            // 色を取得.
            var color = (Color)this.cmbbColor.SelectedItem;

            // データ反映.
            this.UserData.Name = name;
            this.UserData.FontColorStr = color.Name;
            this.UserData.IconFileName = Path.GetFileName(this.OrgImagePath);

            // Mode差異.
            var modeStr = string.Empty;
            switch (this.Mode)
            {
                case MODE.ADD:
                    modeStr = "追加";
                    break;

                case MODE.UPDATE:
                    modeStr = "更新";
                    break;
            }

            // 確認.
            if (DialogResult.Yes != FormMessageBox.YesNo("[{0}]を{1}します。\nよろしいですか？".Fmt(this.UserData.Name, modeStr)))
            {
                return;
            }

            try
            {
                // ディレクトリの作成
                var dirPath = this.UserData.CreateUserDataFolderPath();
                Directory.CreateDirectory(dirPath);

                // イメージファイルの複製.
                if (this.UserData.UseCustomIcon)
                {
                    var dstPath = this.UserData.CreateImageFilePath();
                    if (!dstPath.Equals(this.OrgImagePath))
                    {
                        File.Copy(this.OrgImagePath, dstPath);
                    }
                }

                // 保存処理.
                this.UserData.Save();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ユーザーデータの保存に失敗しました");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
