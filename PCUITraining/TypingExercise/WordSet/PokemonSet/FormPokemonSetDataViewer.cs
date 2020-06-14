using Common.Extentions;
using PCUITCommon;
using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Linq;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンタイプ－ユーザーデータ表示.
    /// </summary>
    public partial class FormPokemonSetDataViewer : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">選択済みのユーザー(未選択ならnull可)</param>
        public FormPokemonSetDataViewer(UserData userData = null)
        {
            InitializeComponent();

            this.UserIconGrp = UserIcon.CreateUserIconGrp();

            this.webBrowser.Visible = false;

            // リストの選択イベントを登録.
            this.ctrlPokemonSetDataViewerList.Selected += this.ListPokeMon_Selected;

            // ユーザーアイコンをセット.
            this.SetUserIcons(userData);
        }

        /// <summary>
        /// ユーザーアイコンをセット.
        /// </summary>
        /// <param name="userData">選択済みのユーザー(未選択ならnull可)</param>
        private void SetUserIcons(UserData userData)
        {
            foreach (var user in PCUIT.UserDataManager.UserDataList)
            {
                var userIcon = this.UserIconGrp.CreateUserIcon(user);
                userIcon.OnSelected += this.userIcon_Click;
                this.flowUserSelect.Controls.Add(userIcon);
            }

            // 最初からユーザーが選択されている場合.
            if (null != userData)
            {
                this.UserIconGrp.SetSelected(userData);
                this.LoadGameData(userData);
            }
        }

        /// <summary>
        /// ユーザーアイコンクリック
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void userIcon_Click(UserData userData)
        {
            // ゲームデータロード.
            this.LoadGameData(userData);
        }

        /// <summary>
        /// ユーザーゲームデータロード.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void LoadGameData(UserData userData)
        {
            var gameData = PokemonSetGameData.Load(userData);
            if (null == gameData)
            {
                this.webBrowser.Visible = false;
                return;
            }

            // 全ポケモンリスト.
            var pockeList = PocketMonsterList.GetPockeMonList();

            // 捕獲したポケモンのリスト.
            var catchedList = gameData.RecordList
                .Where(gdr => 0 < gdr.CapturCount)
                .ToList();

            this.lblComp.Text = "{0}/{1}".Fmt(catchedList.Count, pockeList.Count);

            // リストにデータを反映.
            this.ctrlPokemonSetDataViewerList.SetNewList(catchedList);
            if (catchedList.Count <= 0)
            {
                this.webBrowser.Visible = false;
            }
        }

        /// <summary>
        /// リスト選択イベント.
        /// </summary>
        /// <param name="record">選択されたレコードデータ</param>
        private void ListPokeMon_Selected(PokemonSetGameDataRecord record)
        {
            if (null == record)
            {
                this.webBrowser.Visible = false;
                return;
            }

            // ブラウザにポケモン図鑑を表示.
            var pokeMon = PocketMonsterList.GetPockeMonList()
                .Find(word => record.Name.Equals(word.orgWord));
            if (null == pokeMon)
            {
                this.webBrowser.Visible = false;
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

        /// <summary>
        /// フィルタ文字列変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxFilter_TextChanged(object sender, EventArgs e)
        {
            this.ctrlPokemonSetDataViewerList.ShowList();
        }
    }
}
