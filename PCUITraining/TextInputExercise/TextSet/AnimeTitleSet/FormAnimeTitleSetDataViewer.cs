using Common.Extentions;
using PCUITCommon;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// ポケアニライティング－ゲームデータ表示.
    /// </summary>
    public partial class FormAnimeTitleSetDataViewer : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// 全タイトルリスト.
        /// </summary>
        private List<AnimeTitleSetText> AllTitleList { get; set; }

        /// <summary>
        /// ユーザーデータリスト.
        /// </summary>
        private List<AnimeTitleSetGameDataRecord> UserList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">選択済みのユーザー(未選択ならnull可)</param>
        public FormAnimeTitleSetDataViewer(UserData userData = null)
        {
            InitializeComponent();

            // ユーザーアイコンをセット.
            this.UserIconGrp = this.userSelector.SetUserIcons(this.userIcon_Click);

            // 全タイトルリスト.
            this.AllTitleList = AnimeTitleList.GetTitleList();

            // ユーザーデータリスト.
            this.UserList = new List<AnimeTitleSetGameDataRecord>();

            // 最初からユーザーが選択されている場合.
            if (null != userData)
            {
                this.UserIconGrp.SetSelected(userData);
                this.LoadGameData(userData);
            }

            this.cmbSort.SelectedIndex = 0;

            // アニメーションリスト.
            var animeList = this.AllTitleList
                .Select(ttl => ttl.GetAnimation())
                .Distinct()
                .ToList();

            animeList.Insert(0, "全て表示");

            // コンボボックスに追加.
            this.cmbFilter.Items.AddRange(animeList.ToArray());

            this.cmbFilter.SelectedIndex = 0;
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
            var gameData = AnimeTitleSetGameData.Load(userData);
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

            // 全て表示の場合(ソートが最速タイム順でないことも条件).
            var list = this.UserList;
            if (this.chkBoxAll.Checked && 1 != this.cmbSort.SelectedIndex)
            {
                list = this.AllTitleList
                    .Select(ttl =>
                    {
                        // ユーザーデータに該当データがあれば充当.
                        var userData = this.UserList.Find(ud =>
                        {
                            return ud.Animation.Equals(ttl.GetAnimation()) && ud.ID.Equals(ttl.GetID());
                        });

                        if (null == userData)
                        {
                            return new AnimeTitleSetGameDataRecord(ttl);
                        }

                        return userData;
                    })
                    .ToList();
            }

            // アニメフィルタ.
            if (0 < this.cmbFilter.SelectedIndex)
            {
                var anime = this.cmbFilter.SelectedItem.ToString();
                list = list
                    .Where(elm => elm.Animation.Equals(anime))
                    .ToList();
            }

            // テキストフィルタ.
            var filter = this.tBoxFilter.Text;
            if (!filter.IsEmpty())
            {
                list = list
                    .Where(rec => (rec.Episode + rec.Title).Contains(filter))
                    .ToList();
            }

            // ソートしてから表示.
            switch (this.cmbSort.SelectedIndex)
            {
                // シリーズ順.
                case 0:
                    // 変更不要.
                    break;

                // 最速タイム順.
                case 1:
                    list = list
                        .Where(elm => 0 != elm.ShortestTime)
                        .OrderBy(elm => elm.ShortestTime)
                        .ToList();
                    break;
            }

            // フィルタしつつセット.
            foreach (var record in list)
            {
                this.AddRecord(record);
            }
        }

        /// <summary>
        /// レコード追加.
        /// </summary>
        /// <param name="record">レコード</param>
        private void AddRecord(AnimeTitleSetGameDataRecord record)
        {
            var row = new Dgvr
            {
                Record = record,
            };

            // アニメ名..
            var col1 = new DataGridViewTextBoxCell
            {
                Value = record.Animation,
            };
            col1.Style.Font = PCUIT.GetFont(18);
            row.Cells.Add(col1);

            // エピソード情報.
            var col2 = new DataGridViewTextBoxCell
            {
                Value = record.Episode,
            };
            col2.Style.WrapMode = DataGridViewTriState.True;
            col2.Style.Font = PCUIT.GetFont(18);
            row.Cells.Add(col2);

            // タイトル.
            var col3 = new DataGridViewTextBoxCell
            {
                Value = record.Title,
            };
            col3.Style.WrapMode = DataGridViewTriState.True;
            col3.Style.ForeColor = Color.Aqua;
            row.Cells.Add(col3);

            // 入力回数.
            var col4 = new DataGridViewTextBoxCell
            {
                Value = $"{record.InputedCount}回",
            };
            row.Cells.Add(col4);

            // 最速入力タイム.
            var shortestTime = 0 == record.ShortestTime
                ? string.Empty
                : $"{record.ShortestTime}ms";

            var col5 = new DataGridViewTextBoxCell
            {
                Value = shortestTime,
            };
            col5.Style.ForeColor = Color.Yellow;
            row.Cells.Add(col5);

            // レコードをセット.
            this.dgv.Rows.Add(row);
        }

        /// <summary>
        /// ソートコンボボックス変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// フィルタコンボボックス変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// フィルタ文字列変更.
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
            public AnimeTitleSetGameDataRecord Record { get; set; }
        }
    }
}
