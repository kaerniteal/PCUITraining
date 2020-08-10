using PCUITCommon;
using PCUITCommon.Datas;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TypingExercise.Definitions;
using TypingExercise.Executors;
using TypingExercise.Interfaces;
using TypingExercise.WordSet;

namespace TypingExercise.Views
{
    /// <summary>
    /// 実行フォーム(デバッグ).
    /// </summary>
    public partial class FormTypExcDebug : Form, ITypExcViewer
    {
        /// <summary>
        /// ワードセット.
        /// </summary>
        private WordSetBase WordSet { get; set; }

        /// <summary>
        /// 実行インタフェース.
        /// </summary>
        private ITypExcExecutor Executor { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="wordSet">ワードセット</param>
        public FormTypExcDebug(WordSetBase wordSet)
        {
            InitializeComponent();

            this.WordSet = wordSet;

            var num = TypExc.Conf.NnumberOfQuestions;
            var newList = wordSet.CreateNewWordList(num);
            this.Executor = new SetExecutor(newList, this);
            this.Executor.Start();
        }

        /// <summary>
        /// Key入力を取得.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormExecDebug_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Esc
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Executor.Stop();
                this.Close();
            }

            // 実行クラスへ通知.
            this.Executor.InputKey(e.KeyChar);
        }

        /// <summary>
        /// 新しい入力対象単語をセットする.
        /// </summary>
        /// <param name="word">入力対象文字列</param>
        /// <returns>関連するイメージを抱えるストア</returns>
        public ImageStore SetNewWord(string word)
        {
            this.lblWord.Text = word;

            // 画像を取得して表示.
            var imageStore = this.pPanel.CreateNewImageStore();
            if (PCUIT.Conf.EnableWeb)
            {
                imageStore.DownLoadFromGoogle(word);
            }

            return imageStore;
        }

        /// <summary>
        /// Key入力に対する結果を通知.
        /// </summary>
        /// <param name="inputed">入力済み文字列</param>
        /// <param name="current">入力中文字列</param>
        /// <param name="spellings">次の入力文字の綴りリスト</param>
        /// <param name="missTypes">ミスタイプ文字</param>
        public void ShowKeyResult(string inputed, string current, List<CorrectSpelling> spellings, string missTypes)
        {
            this.lblInputed.Text = inputed + current;

            var nextSpellings = spellings
                .SelectMany(spel =>
                {
                    var spels = new List<string>();
                    spels.Add(spel.Cha);
                    spels.AddRange(spel.Spells);
                    spels.Add(string.Empty);

                    return spels;
                })
                .ToList();

            if (0 < nextSpellings.Count)
            {
                // 候補を複数表示できるように.
                this.lblCorrect.Text = string.Join("\n", nextSpellings.ToArray());
            }
            else
            {
                this.lblCorrect.Text = string.Empty;
            }

            this.lblMissTypes.Text = missTypes;
        }

        /// <summary>
        /// 単語入力毎の結果を通知する.
        /// </summary>
        public void ShowWordResult(WordResult result)
        {
            this.lblResultWord.Text = result.Word;
            this.lblResultETime.Text = result.MeasuredTime.ToString();
            this.lblResultMissType.Text = result.MissTypeCount.ToString();
            this.lblResultNoMissCount.Text = result.ConsecutiveNoMissCount.ToString();
        }

        /// <summary>
        /// 実行終了を通知する.
        /// </summary>
        /// <param name="result">実行結果</param>
        public void ShowSetResult(SetResult result)
        {
            this.Close();
        }
    }
}
