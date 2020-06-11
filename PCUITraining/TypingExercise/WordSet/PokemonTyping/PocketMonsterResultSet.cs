using Common.Controls;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using TypingExercise.Executors;
using TypingExercise.Interfaces;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケモン総合結果表示ダイアログ.
    /// </summary>
    public partial class PocketMonsterResultSet : Form, IResultSetDlg
    {
        private int radius { get; set; }
        private int ox { get; set; }
        private int oy { get; set; }

        /// <summary>
        /// レコードコントロールリスト
        /// </summary>
        private List<PocketMonsterResultSetRecord> RecordList { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PocketMonsterResultSet()
        {
            InitializeComponent();

            this.radius = (int)(Math.Sqrt(Width * Width + Height * Height) / 2);
            this.ox = Width / 2;
            this.oy = Height / 2;

            this.Region = new Region(new GraphicsPath());

            this.RecordList = new List<PocketMonsterResultSetRecord>();
        }

        /// <summary>
        /// 総合結果表示
        /// </summary>
        /// <param name="setResult">総合結果</param>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowSetResultDlg(SetResult setResult, UserData userData)
        {
            //**************************************************//
            // ユーザーデータがnullの場合、保存処理等は走らない //
            //**************************************************//
            var pockemonData = new PocketMonsterGameData();
            if (null != userData)
            {
                // データロード(存在しな場合は新規作成)
                var userFolderPath = userData.CreateUserDataFolderPath();
                pockemonData = PocketMonsterGameData.Load(userFolderPath);
            }

            // 捕獲判定を実施.
            // ユーザーデータは更新もする.
            var judgResultList = setResult.WordResultList
                .Select(wordResult =>
                {
                    // ユーザーデータのポケモン別レコードを取得する.
                    PocketMonsterGameDataRecord record = null;
                    if (null != pockemonData)
                    {
                        // ユーザーデータから取得.
                        record = pockemonData.RecordList
                            .Find(rec => rec.Name.Equals(wordResult.Word));

                        // 存在しない場合は新たに生成して追加しておく.
                        if (null == record)
                        {
                            record = new PocketMonsterGameDataRecord
                            {
                                Name = wordResult.Word,
                            };

                            pockemonData.RecordList.Add(record);
                        }
                    }

                    //*****************//
                    // 捕獲判定を実施. //
                    //*****************//
                    // ユーザーデータも更新して貰う.
                    return PocketMonsterJudgmentResult.Judgment(wordResult, record);
                })
                .ToList();

            // ユーザーデータを保存
            if (null != userData)
            {
                var userFolderPath = userData.CreateUserDataFolderPath();
                pockemonData.Save(userFolderPath);
            }

            // 結果をセット.
            this.RecordList = new List<PocketMonsterResultSetRecord>();
            for (var ii = 0; ii < judgResultList.Count; ii++ )
            {
                var judgResult = judgResultList[ii];
                var ctrl = new PocketMonsterResultSetRecord();
                ctrl.SetWordResult(judgResult);

                // Load時、上から順にAnimationで表示する為に非表示にしておく.
                ctrl.Visible = false;

                this.RecordList.Add(ctrl);
                this.tableWordResult.Controls.Add(ctrl, 0, ii);
            }

            return this.ShowDialog();
        }

        /// <summary>
        /// ロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PocketMonsterResultSet_Load(object sender, System.EventArgs e)
        {
            // 円のエフェクトでフォームを描画する.
            Animator.Animate(300, (frame, resolution) =>
            {
                if (!Visible || IsDisposed) return false;
                var graphicsPath = new GraphicsPath();
                var r = radius * frame / resolution;
                graphicsPath.AddEllipse(new Rectangle(ox - r, oy - r, r * 2, r * 2));
                Region = new Region(graphicsPath);
                if (frame == resolution) Region = null;
                return true;
            });

            // 円のエフェクトでフォームを描画する.
            Animator.Animate(4000, (frame, frequency) =>
            {
                if (!Visible || IsDisposed)
                {
                    return false;
                }

                // 0～10が得られる.
                var index = (frame * 10) / frequency;

                // 最初の０の間は除外する.
                if (0 < index)
                {
                    // 0～9にする.
                    index--;
                    if (index < this.RecordList.Count)
                    {
                        this.RecordList[index].Visible = true;
                    }
                }

                return true;
            });
        }

        /// <summary>
        /// つづけるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btonOK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// おわるボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
