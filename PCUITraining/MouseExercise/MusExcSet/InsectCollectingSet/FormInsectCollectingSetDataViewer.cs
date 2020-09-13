using Common.Extentions;
using Common.WinForms;
using Common.WinForms.Animation;
using PCUITCommon.Users;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static PCUITCommon.Views.UserIcon;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セット－データ表示ダイアログ.
    /// </summary>
    public partial class FormInsectCollectingSetDataViewer : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// 全ユニットリスト.
        /// </summary>
        private List<MusExcQuestionDefUnit> AllUnitList { get; set; }

        /// <summary>
        /// トータルスコアリスト.
        /// </summary>
        public List<int> ScoreList { get; set; }

        /// <summary>
        /// データレコードリスト.
        /// </summary>
        public List<InsectCollectingSetGameDataRecord> RecordList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">選択済みのユーザー(未選択ならnull可)</param>
        public FormInsectCollectingSetDataViewer(UserData userData = null)
        {
            InitializeComponent();

            // ユーザーアイコンをセット.
            this.UserIconGrp = this.userSelector.SetUserIcons(this.userIcon_Click);

            // 全ユニットリストを取得.
            this.AllUnitList = InsectCollectingSetQuestionList.GetQuestionList()
                .SelectMany(qd => qd.UnitList)
                .ToList();

            // リスト.
            this.ScoreList = new List<int>();
            this.RecordList = new List<InsectCollectingSetGameDataRecord>();

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
            // ユーザーゲームデータロード.
            this.LoadGameData(userData);
        }

        /// <summary>
        /// ユーザーゲームデータロード.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        private void LoadGameData(UserData userData)
        {
            var gameData = InsectCollectingSetGameData.Load(userData);
            if (null == gameData)
            {
                return;
            }

            // ユーザーデータを確保.
            this.RecordList = gameData.RecordList
                .OrderBy(rd => rd.ImageFilePath)
                .ToList();
            this.ScoreList = gameData.ScoreList;

            // カウントをセット.
            this.lblCount.Text = $"{this.RecordList.Count}/{this.AllUnitList.Count}";

            // リストにデータを反映.
            this.ShowList();
        }

        /// <summary>
        /// リストを表示する.
        /// </summary>
        private void ShowList()
        {
            // いったんクリア.
            this.dgvCapture.Rows.Clear();
            this.dgvHighScore.Rows.Clear();

            // 取得一覧を格納.
            foreach (var rec in this.RecordList)
            {
                this.AddRecord(rec);
            }

            // スコア一覧.
            foreach (var score in this.ScoreList)
            {
                this.AddHighScoreRecord(score);
            }
        }

        /// <summary>
        /// 捕獲データレコード追加.
        /// </summary>
        /// <param name="gameRec">レコード</param>
        public void AddRecord(InsectCollectingSetGameDataRecord gameRec)
        {
            var row = new DataGridViewRow();
            row.Height = 64;

            var col1 = new DataGridViewImageCell
            {
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Value = new Bitmap(gameRec.ImageFilePath),
            };
            row.Cells.Add(col1);

            var col2 = new DataGridViewTextBoxCell
            {
                Value = gameRec.Name,
            };
            row.Cells.Add(col2);

            var col3 = new DataGridViewTextBoxCell
            {
                Value = @"{0}匹".Fmt(gameRec.CaptureCount),
            };
            col3.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            row.Cells.Add(col3);

            var col4 = new DataGridViewTextBoxCell
            {
                Value = @"{0}点".Fmt(gameRec.Score),
            };
            col4.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            row.Cells.Add(col4);

            this.dgvCapture.Rows.Add(row);
        }

        /// <summary>
        /// ハイスコアレコード追加.
        /// </summary>
        /// <param name="highScore">ハイスコア</param>
        public void AddHighScoreRecord(int highScore)
        {
            var row = new DataGridViewRow();
            row.Height = 64;

            var col1 = new DataGridViewTextBoxCell
            {
                Value = highScore,
            };
            col1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            row.Cells.Add(col1);

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
