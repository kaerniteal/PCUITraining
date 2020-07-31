using Common.Extentions;
using System.Diagnostics;
using TextInputExercise.Interfaces;
using TextInputExercise.TextSet;
using static TextInputExercise.Executors.SetExecutor;

namespace TextInputExercise.Executors
{
    /// <summary>
    /// テキスト入力実行クラス.
    /// </summary>
    public class TextExecutor
    {
        /// <summary>
        /// 表示インタフェース.
        /// </summary>
        private ITIExcViewer Viewer { get; set; }

        /// <summary>
        /// 正答.
        /// </summary>
        private string CorrectText { get; set; }

        /// <summary>
        /// 正答リスト.
        /// </summary>
        private TextCorrect[] CorrectList { get; set; }

        /// <summary>
        /// 時間計測クラス.
        /// </summary>
        private Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// 単語の入力結果.
        /// </summary>
        private TextResult TextResult { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="viewer">表示インタフェース</param>
        /// <param name="word">単語クラス</param>
        public TextExecutor(ITIExcViewer viewer, TextBase word)
        {
            this.Viewer = viewer;
            this.CorrectText = word.Text;
            this.CorrectList = word.correctList;
            this.Stopwatch = new Stopwatch();

            this.TextResult = new TextResult(word);

            // 新しい入力単語の表示への反映は一度だけ.
            this.Viewer.SetNewText(this.CorrectText);

            // 入力時間の計測開始.
            this.Stopwatch.Start();

            // 表示を初期化する.
            this.Viewer.ShowInputResult(string.Empty, string.Empty);
        }

        /// <summary>
        /// 結果を返す.
        /// </summary>
        /// <returns>単語入力結果</returns>
        public TextResult GetResult()
        {
            // 入力時間の計測終了.
            this.Stopwatch.Stop();
            this.TextResult.MeasuredTime = this.Stopwatch.ElapsedMilliseconds;

            return this.TextResult;
        }

        /// <summary>
        /// 入力されたTEXT
        /// </summary>
        /// <param name="text">入力文字列</param>
        /// <returns>入力結果</returns>
        public EXEC_RESULT InputText(string text)
        {
            var cIdx = 0;
            var status = EXEC_RESULT.NEXT;
            var correctInputed = string.Empty;
            foreach (var correct in this.CorrectList)
            {
                // 入力文字列より正答の方が長い場合はチェック打ち切り.
                var cArray = text.ToCharArray();
                if (cArray.Length <= cIdx)
                {
                    status = EXEC_RESULT.CONTINUE;
                    break;
                }

                // チェック対象文字まで進める.
                var cha = char.MinValue;
                for (; cIdx < cArray.Length; cIdx++)
                {
                    var c = cArray[cIdx];
                    if (TextCorrect.IsIgnoreCorrectCheck(c))
                    {
                        correctInputed += c;
                        continue;
                    }

                    cha = c;
                    break;
                }

                // 入力文字列の終端まで辿り着いてしまった場合.
                if (char.MinValue == cha)
                {
                    status = EXEC_RESULT.CONTINUE;
                    break;
                }

                // チェック不要、もしくはチェックの結果が正しければ.
                if (correct.Correct.Contains(cha.ToString()))
                {
                    correctInputed += cha;
                    cIdx++;
                }
                else
                {
                    // チェック結果がNGの場合.
                    status = EXEC_RESULT.CONTINUE;
                    break;
                }
            }

            // 入力結果を表示へ反映する.
            this.Viewer.ShowInputResult(correctInputed, text.Right(correctInputed));

            // ステータスを返却.
            return status;
        }
    }
}
