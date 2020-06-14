using Common.Extentions;
using System;
using System.Collections.Generic;
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
        private List<PokemonSetGameDataRecord> AllList { get; set; }

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

            AllList = new List<PokemonSetGameDataRecord>();
        }

        /// <summary>
        /// 新リストセット.
        /// </summary>
        /// <param name="list">ポケモンデータリスト</param>
        public void SetNewList(List<PokemonSetGameDataRecord> list)
        {
            this.AllList = list
                .Where(rec => 0 < rec.CapturCount)
                .OrderBy(rec => rec.Name)
                .ToList();

            this.ShowList();
        }

        /// <summary>
        /// レコード追加.
        /// </summary>
        /// <param name="record"></param>
        public void AddRecord(PokemonSetGameDataRecord record)
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

            this.dgv.Rows.Add(row);
        }

        /// <summary>
        /// リストを表示する.
        /// </summary>
        public void ShowList()
        {
            this.dgv.Rows.Clear();

            var filter = this.tBoxFilter.Text;

            // フィルタしつつセット.
            foreach (var record in this.AllList)
            {
                if ((record.Name + record.CapturCount).Contains(filter))
                {
                    this.AddRecord(record);
                }
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
            foreach(var row in this.dgv.Rows)
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
