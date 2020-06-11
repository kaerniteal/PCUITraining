using Common.Extentions;
using PCUITCommon;
using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Linq;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケモンタイプ－ユーザーデータ表示.
    /// </summary>
    public partial class FormPocketMonsterDataViewer : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// ゲームデータ.
        /// </summary>
        private PocketMonsterGameData GameData { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormPocketMonsterDataViewer()
        {
            InitializeComponent();

            // ユーザーアイコンをセット.
            this.SetUserIcons();
            this.GameData = null;

            this.webBrowser.Visible = false;
        }

        /// <summary>
        /// ユーザーアイコンをセット.
        /// </summary>
        private void SetUserIcons()
        {
            this.UserIconGrp = UserIcon.CreateUserIconGrp();

            foreach (var user in PCUIT.UserDataManager.UserDataList)
            {
                var userIcon = this.UserIconGrp.CreateUserIcon(user);
                userIcon.OnSelected += this.userIcon_Click;
                this.flowUserSelect.Controls.Add(userIcon);
            }
        }

        /// <summary>
        /// ユーザーアイコンクリック
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void userIcon_Click(UserData userData)
        {
            // ゲームデータロード.
            var userFolderPath = userData.CreateUserDataFolderPath();
            this.GameData = PocketMonsterGameData.Load(userFolderPath);
            this.UpdateGameData();
        }

        /// <summary>
        /// 表示に反映する.
        /// </summary>
        private void UpdateGameData()
        {
            if (null == this.GameData)
            {
                return;
            }

            this.ListPokeMon.Items.Clear();

            var sorted = this.GameData.RecordList
                .OrderBy(rec => rec.Name);

            foreach ( var record in sorted)
            {
                if (0  < record.CapturCount)
                {
                    this.ListPokeMon.Items.Add(record.Name);
                }
            }

            // 捕獲したポケモンのリストを作成.
            var catchList = this.GameData.RecordList
                .Where(gdr => 0 < gdr.CapturCount)
                .ToList();

            var pockeList = PocketMonsterList.GetPockeMonList();
            this.lblCatch.Text = string.Empty;
            this.lblTime.Text = string.Empty;
            this.lblComp.Text = "{0}/{1}".Fmt(catchList.Count, pockeList.Count);

            this.webBrowser.Visible = false;
        }

        /// <summary>
        /// リスト選択イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListPokeMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = this.ListPokeMon.SelectedItem.ToString();
            if (null == selected)
            {
                return;
            }

            var record = GameData.RecordList
                .Find(rec => selected.Equals(rec.Name));
            if (null == record)
            {
                return;
            }

            this.lblCatch.Text = "{0} 匹".Fmt(record.CapturCount);
            this.lblTime.Text = "{0} ms".Fmt(record.ShortestTime);

            // ブラウザにポケモン図鑑を表示.
            var pokeMon = PocketMonsterList.GetPockeMonList()
                .Find(word => record.Name.Equals(word.orgWord)) as PocketMonsterWord;
            if (null == pokeMon)
            {
                return;
            }

            this.webBrowser.Navigate(@"https://zukan.pokemon.co.jp/detail/" + pokeMon.Num);
            this.webBrowser.Visible = true;
        }

        /// <summary>
        /// とじるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
