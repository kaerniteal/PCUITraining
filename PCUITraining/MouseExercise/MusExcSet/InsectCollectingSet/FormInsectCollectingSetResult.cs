using Common.Extentions;
using Common.WinForms;
using Common.WinForms.Animation;
using System.Drawing;
using System.Windows.Forms;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セット－結果表示ダイアログ.
    /// </summary>
    public partial class FormInsectCollectingSetResult : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="result">捕獲判定結果</param>
        /// <param name="gameData">捕獲判定結果</param>
        public FormInsectCollectingSetResult(MusExcSharedDataResult result, InsectCollectingSetGameData gameData)
        {
            InitializeComponent();

            // 捕獲ユニット一覧.
            this.dgvCapture.Rows.Clear();

            var resultlist = result.GetResultList();
            foreach (var rec in resultlist)
            {
                this.AddCaptureRecord(rec);
            }

            // 今回のスコア.
            var currentScore = result.GetTotalScore();
            this.lblScore.Text = "{0}点".Fmt(currentScore);

            // スコア一覧.
            var totalScore = result.GetTotalScore();
            foreach (var score in gameData.ScoreList)
            {
                this.AddHighScoreRecord(score, currentScore);
            }
        }

        /// <summary>
        /// 捕獲結果レコード追加.
        /// </summary>
        /// <param name="resultRec">レコード</param>
        public void AddCaptureRecord(MusExcSharedDataResultRecord resultRec)
        {
            var row = new DataGridViewRow();
            row.Height = 48;

            var col1 = new DataGridViewImageCell
            {
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Value = new Bitmap(resultRec.DefUnit.UnitImageFilePath),
            };
            row.Cells.Add(col1);

            var col2 = new DataGridViewTextBoxCell
            {
                Value = resultRec.UnitName,
            };
            row.Cells.Add(col2);

            var col3 = new DataGridViewTextBoxCell
            {
                Value = @"{0}匹".Fmt(resultRec.ClickedCount),
            };
            row.Cells.Add(col3);

            var socre = resultRec.ClickedCount * resultRec.DefUnit.Score;
            var col4 = new DataGridViewTextBoxCell
            {
                Value = @"{0}点".Fmt(socre),
            };
            row.Cells.Add(col4);

            this.dgvCapture.Rows.Add(row);
        }

        /// <summary>
        /// ハイスコアレコード追加.
        /// </summary>
        /// <param name="highScore">ハイスコア</param>
        /// <param name="currentScore">レコード</param>
        public void AddHighScoreRecord(int highScore, int currentScore)
        {
            var row = new DataGridViewRow();
            row.Height = 48;

            var col1 = new DataGridViewTextBoxCell
            {
                Value = highScore,
            };
            row.Cells.Add(col1);

            var current = string.Empty;
            if (highScore == currentScore)
            {
                current = @"⇦ 更新！";
            }

            var col2 = new DataGridViewTextBoxCell
            {
                Value = current,
            };
            row.Cells.Add(col2);

            this.dgvHighScore.Rows.Add(row);
        }

        /// <summary>
        /// ロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PocketMonsterResultSet_Load(object sender, System.EventArgs e)
        {
            // 円形エフェクトで表示する.
            var ace = new AnimationCircleEffect(this);
            ace.FadeIn(500);
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
