using Common.Extentions;
using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンタイプ－ゲームデータ表示リスト
    /// </summary>
    public partial class CtrlPokemonSetDataViewerList : UserControl
    {
        /// <summary>
        /// 全データリスト.
        /// </summary>
        public List<PokemonSetGameDataRecord> AllList { get; set; }

        /// <summary>
        /// 元データリスト.
        /// </summary>
        public List<PokemonSetGameDataRecord> OrgList { get; set; }

        /// <summary>
        /// 他方データリスト.
        /// </summary>
        public List<PokemonSetGameDataRecord> OthreSideList { get; set; }

        /// <summary>
        /// 選択状態変化イベント
        /// </summary>
        public Action<PokemonSetGameDataRecord> Selected;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CtrlPokemonSetDataViewerList()
        {
            InitializeComponent();

            this.AllList = new List<PokemonSetGameDataRecord>();
            this.OrgList = new List<PokemonSetGameDataRecord>();
            this.OthreSideList = new List<PokemonSetGameDataRecord>();

            this.cmbSort.SelectedIndex = 0;
        }

        /// <summary>
        /// ソートコンボボックスに０匹リストを加える.
        /// </summary>
        public void AddZeroSort()
        {
            this.cmbSort.Items.Add("０匹のポケモン");
        }

        /// <summary>
        /// 新リストセット.
        /// </summary>
        /// <param name="list">ポケモンデータリスト</param>
        public void SetNewList(List<PokemonSetGameDataRecord> list)
        {
            this.AllList = list
                .OrderBy(rec => rec.Name)
                .ToList();

            this.OrgList = this.AllList
                .Where(rec => 0 < rec.CapturCount)
                .ToList();

            this.ShowList();
        }

        /// <summary>
        /// 他方リストセット.
        /// </summary>
        /// <param name="list">ポケモンデータリスト</param>
        public void SetOtherSideList(List<PokemonSetGameDataRecord> list)
        {
            this.OthreSideList = list
                .Where(rec => 0 < rec.CapturCount)
                .ToList();

            this.ShowList();
        }

        /// <summary>
        /// レコード追加.
        /// </summary>
        /// <param name="record">レコード</param>
        /// <param name="shadow">陰</param>
        public void AddRecord(PokemonSetGameDataRecord record, bool shadow)
        {
            var row = new Dgvr
            {
                Record = record,
            };

            var col1 = new DataGridViewTextBoxCell
            {
                Value = record.Name,
            };
            row.Cells.Add(col1);

            var col2 = new DataGridViewTextBoxCell
            {
                Value = @"{0}匹".Fmt(record.CapturCount),
            };
            row.Cells.Add(col2);

            var col3 = new DataGridViewTextBoxCell
            {
                Value = "－",
            };

            // 計測時間が存在する場合のみ表示
            if (0 < record.ShortestTime)
            {
                col3.Value = @"{0}ms".Fmt(record.ShortestTime);
            }

            row.Cells.Add(col3);

            // 他方が持ってるポケモンを暗くするする.
            if (shadow)
            {
                row.DefaultCellStyle.ForeColor = Color.DimGray;
            }

            this.dgv.Rows.Add(row);
        }

        /// <summary>
        /// リストを表示する.
        /// </summary>
        public void ShowList()
        {
            this.dgv.Rows.Clear();

            var sortedList = this.OrgList;
            switch (this.cmbSort.SelectedIndex)
            {
                // アイウエオ順は元のリストなのでソート不要.
                case 0:
                    break;

                // 捕獲数順
                case 1:
                    sortedList = this.OrgList
                        .OrderByDescending(elm => elm.CapturCount)
                        .ToList();
                    break;

                // 最速タイム順.
                case 2:
                    sortedList = this.OrgList
                        .Where(elm => 0 != elm.ShortestTime)
                        .OrderBy(elm => elm.ShortestTime)
                        .ToList();
                    break;

                // ０匹ポケモンリスト.
                case 3:
                    sortedList = PocketMonsterList.GetPockeMonList()
                        .Select(fullPoke =>
                        {
                            var poke = this.AllList
                                .Find(p => p.Name.Equals(fullPoke.orgWord));
                            if (null != poke)
                            {
                                // 捕獲済みのポケモン.
                                if (0 < poke.CapturCount)
                                {
                                    return null;
                                }

                                // 0匹のポケモン.
                                return poke;
                            }

                            // まだデータがないポケモン.
                            return new PokemonSetGameDataRecord
                            {
                                Name = fullPoke.orgWord,
                            };
                        })
                        .Where(fullPoke => null != fullPoke)
                        .ToList();
                    break;
            }

            // テキストフィルタ.
            var filter = this.tBoxFilter.Text.Trim();
            if (!filter.IsEmpty())
            {
                // インクリメンタルサーチ.
                sortedList = UtilIncrementalSearch.IncrementalSearch<PokemonSetGameDataRecord>(
                    sortedList,
                    filter,
                    (rec) => { return rec.Name + rec.CapturCount; });
            }

            // セット.
            foreach (var record in sortedList)
            {
                // 他方が持ってるポケモンを暗くする.
                var shadow = false;
                if (null != this.OthreSideList && null != this.OthreSideList
                    .Find(pkmn => pkmn.Name.Equals(record.Name)))
                {
                    shadow = true;
                }

                this.AddRecord(record, shadow);
            }
        }

        /// <summary>
        /// 選択状態変化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_SelectionChanged(object sender, System.EventArgs e)
        {
            if (null == this.Selected)
            {
                return;
            }

            var row = this.GetSelected();
            if (null == row)
            {
                return;
            }

            this.Selected(row);
        }

        /// <summary>
        /// 選択されているレコードを取得する.
        /// </summary>
        /// <returns></returns>
        public PokemonSetGameDataRecord GetSelected()
        {
            var rows = this.dgv.SelectedRows;
            if (rows.Count <= 0)
            {
                return null;
            }

            var row = rows[0] as Dgvr;
            if (null == row)
            {
                return null;
            }

            return row.Record;
        }

        /// <summary>
        /// 選択されているレコードをセットする.
        /// </summary>
        /// <param name="name">選択するポケモン</param>
        public void SetSelected(string name)
        {
            foreach (var row in this.dgv.Rows)
            {
                var dgvr = row as Dgvr;
                if (null == dgvr)
                {
                    continue;
                }

                if (dgvr.Record.Name.Equals(name))
                {
                    dgvr.Selected = true;
                }
            }
        }

        /// <summary>
        /// コンボボックスチェンジ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// フィルタチェンジ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxFilter_TextChanged(object sender, EventArgs e)
        {
            this.ShowList();
        }

        /// <summary>
        /// ポケモンタイプゲームデータ表示用行データ.
        /// </summary>
        private class Dgvr : DataGridViewRow
        {
            /// <summary>
            /// データレコード.
            /// </summary>
            public PokemonSetGameDataRecord Record { get; set; }
        }
    }
}
