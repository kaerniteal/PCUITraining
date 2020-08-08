using Common.Extentions;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニライティング－ゲームデータ表示.
    /// </summary>
    public partial class FormPokeaniSetDataViewer : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// 全タイトルリスト.
        /// </summary>
        private List<PokeaniSetText> AllTitleList { get; set; }

        /// <summary>
        /// ユーザーデータリスト.
        /// </summary>
        private List<PokeaniSetGameDataRecord> UserList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">選択済みのユーザー(未選択ならnull可)</param>
        public FormPokeaniSetDataViewer(UserData userData = null)
        {
            InitializeComponent();

            // ユーザーアイコンをセット.
            this.UserIconGrp = this.userSelector.SetUserIcons(this.userIcon_Click);

            // 全タイトルリスト.
            this.AllTitleList = PokeaniTitleList.GetPokemonTitleList();

            // ユーザーデータリスト.
            this.UserList = new List<PokeaniSetGameDataRecord>();

            // 最初からユーザーが選択されている場合.
            if (null != userData)
            {
                this.UserIconGrp.SetSelected(userData);
                this.LoadGameData(userData);
            }

            this.cmbSort.SelectedIndex = 0;
        }

        /// <summary>
        /// ユーザーアイコンクリック
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void userIcon_Click(UserData userData)
        {
            // ユーザーゲームデータロード.
            this.LoadGameData(userData);
        }

        /// <summary>
        /// ユーザーゲームデータロード.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void LoadGameData(UserData userData)
        {
            var gameData = PokeaniSetGameData.Load(userData);
            if (null == gameData)
            {
                return;
            }

            this.UserList = gameData.RecordList;

            this.lblCount.Text = $"{this.UserList.Count}/{this.AllTitleList.Count}";

            // リストにデータを反映.
            this.ShowList();
        }

        /// <summary>
        /// リストを表示する.
        /// </summary>
        private void ShowList()
        {
            this.dgv.Rows.Clear();

            // 全て表示の場合.
            var list = this.UserList;
            if (this.chkBoxAll.Checked)
            {
                list = this.AllTitleList
                    .Select(ttl =>
                    {
                        // ユーザーデータに該当データがあれば充当.
                        var userData = this.UserList.Find(ud => ud.Total.Equals(ttl.Total));
                        if (null == userData)
                        {
                            return new PokeaniSetGameDataRecord(ttl);
                        }

                        return userData;
                    })
                    .ToList();
            }

            // ソートしてから表示.
            var sortedList = list;
            switch (this.cmbSort.SelectedIndex)
            {
                // シリーズ順.
                case 0:
                    // 変更不要.
                    break;

                // 最速タイム順.
                case 1:
                    sortedList = list
                        .Where(elm => 0 != elm.ShortestTime)
                        .OrderBy(elm => elm.ShortestTime)
                        .ToList();
                    break;
            }

            // フィルタしつつセット.
            var filter = this.tBoxFilter.Text;
            foreach (var record in sortedList)
            {
                if ((record.Series + record.Volume + record.Episode + record.Title).Contains(filter))
                {
                    this.AddRecord(record);
                }
            }
        }

        /// <summary>
        /// レコード追加.
        /// </summary>
        /// <param name="record">レコード</param>
        private void AddRecord(PokeaniSetGameDataRecord record)
        {
            var row = new Dgvr
            {
                Record = record,
            };

            // シリーズ情報.
            var volue = record.Volume.IsEmpty()
                ? string.Empty
                : $"【{record.Volume}】　";

            var col1 = new DataGridViewTextBoxCell
            {
                Value = $"{record.Series}\n{volue}{record.Episode}",
            };
            col1.Style.WrapMode = DataGridViewTriState.True;
            row.Cells.Add(col1);

            // タイトル.
            var col2 = new DataGridViewTextBoxCell
            {
                Value = record.Title,
            };
            col2.Style.ForeColor = Color.Aqua;
            row.Cells.Add(col2);

            // 入力回数.
            var col3 = new DataGridViewTextBoxCell
            {
                Value = $"{record.InputedCount}回",
            };
            row.Cells.Add(col3);

            // 最速入力タイム.
            var shortestTime = 0 == record.ShortestTime
                ? string.Empty
                : $"{record.ShortestTime}ms";

            var col4 = new DataGridViewTextBoxCell
            {
                Value = shortestTime,
            };
            col4.Style.ForeColor = Color.Yellow;
            row.Cells.Add(col4);

            // レコードをセット.
            this.dgv.Rows.Add(row);
        }

        /// <summary>
        /// コンボボックス変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// フィルタ変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxFilter_TextChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// チェックボックス変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// とじるボタン.
        /// </summary>
        /// <param name="sender"></param
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ポケアニライティング－ゲームデータ表示用行データ.
        /// </summary>
        private class Dgvr : DataGridViewRow
        {
            /// <summary>
            /// データレコード.
            /// </summary>
            public PokeaniSetGameDataRecord Record { get; set; }
        }
    }
}
