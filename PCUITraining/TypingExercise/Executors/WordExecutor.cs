using Common.Extentions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using TypingExercise.Definitions;
using TypingExercise.Interfaces;
using TypingExercise.WordSet;

namespace TypingExercise.Executors
{
    public class WordExecutor
    {
        /// <summary>
        /// マッチ結果.
        /// </summary>
        private enum CHAR_MATCH
        {
            MATCH_CONTINUE,
            MATCH_EXCHAR3,
            MATCH_EXCHAR2,
            MATCH_CHAR2,
            MATCH_CHAR1,
            NO_MATCH,
        }

        /// <summary>
        /// 表示インタフェース.
        /// </summary>
        private ITypExcViewer Viewer { get; set; }

        /// <summary>
        /// 正答リスト.
        /// </summary>
        private WordCorrect[] CorrectList { get; set; }

        /// <summary>
        /// 現在入力中の文字Index. 
        /// </summary>
        private int CurrentIndex { get; set; }

        /// <summary>
        /// 入力中の正答.
        /// </summary>
        private WordCorrect CurrentCorrect { get; set; }

        /// <summary>
        /// 入力済み文字列.
        /// </summary>
        private string InputedCharacters { get; set; }

        /// <summary>
        /// 入力中文字列.
        /// </summary>
        private string CurrentCharacters { get; set; }

        /// <summary>
        /// 時間計測クラス.
        /// </summary>
        private Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// 単語の入力結果.
        /// </summary>
        private WordResult WordResult { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="viewer">表示インタフェース</param>
        /// <param name="word">単語クラス</param>
        public WordExecutor(ITypExcViewer viewer, WordBase word)
        {
            this.Viewer = viewer;
            this.CorrectList = word.correctList;
            this.CurrentIndex = 0;
            this.CurrentCorrect = null;
            this.InputedCharacters = string.Empty;
            this.CurrentCharacters = string.Empty;
            this.Stopwatch = new Stopwatch();

            this.WordResult = new WordResult(word.orgWord);

            // 新しい入力単語の表示への反映は一度だけ.
            // 入力対象文字列に対するイメージストアを貰い、結果に保持する.
            this.WordResult.ImageStore = this.Viewer.SetNewWord(word.orgWord);


            // 入力時間の計測開始.
            this.Stopwatch.Start();

            // 最初の文字をセットする.
            this.CurrentIndex = 0;
            this.Expect();

            // 表示を初期化する.
            this.Viewer.ShowKeyResult(
                string.Empty,
                string.Empty,
                this.CreateSpellings(),
                string.Empty);
        }

        /// <summary>
        /// 結果を返す.
        /// </summary>
        /// <returns>単語入力結果</returns>
        public WordResult GetResult()
        {
            // 入力時間の計測終了.
            this.Stopwatch.Stop();
            this.WordResult.MeasuredTime = this.Stopwatch.ElapsedMilliseconds;

            return this.WordResult;
        }

        /// <summary>
        /// 入力待ちの文字をセットする.
        /// </summary>
        /// <returns>実行状況</returns>
        private EXEC_RESULT Expect()
        {
            // 入力中の文字はクリアする.
            this.CurrentCharacters = string.Empty;

            // 次の入力対象文字をセットする.
            while (true)
            {
                // これ以上入力文字が存在しない場合は次の文字列へ進む.
                if (this.CorrectList.Length <= this.CurrentIndex)
                {
                    return EXEC_RESULT.NEXT;
                }

                // 正答をセット.
                this.CurrentCorrect = this.CorrectList[this.CurrentIndex];

                // 例外文字(・♂♀等)考慮.
                // 最低限、一文字綴りが存在する場合は問題なし.
                if (0 < this.CurrentCorrect.CorrectSpelling1.Spells.Count)
                {
                    break;
                }

                // 次の文字へ進める.
                this.CurrentIndex++;
            }

            // 継続.
            return EXEC_RESULT.CONTINUE;
        }

        /// <summary>
        /// KEYの入力処理.
        /// </summary>
        /// <param name="key">入力されたKEY</param>
        /// <returns>入力結果</returns>
        public EXEC_RESULT InputKey(char key)
        {
            // ミスタイプ.
            var missType = string.Empty;

            // 正答が存在しない場合、次の文字列へ進む.
            if (null == this.CurrentCorrect)
            {
                return EXEC_RESULT.NEXT;
            }

            // 入力KEY処理.
            switch (key)
            {
                // 入力中の文字を一文字削除する.
                case (char)Keys.Back:
                    var len = this.CurrentCharacters.Length;
                    if (0 < len)
                    {
                        this.CurrentCharacters = this.CurrentCharacters.Substring(0, len - 1);
                    }
                    break;

                // 入力されたKEYを蓄積.
                default:
                    this.CurrentCharacters += key;
                    break;
            }

            // 文字列の一致を確認.
            var status = EXEC_RESULT.CONTINUE;
            switch (this.CheckMatch(this.CurrentCharacters))
            {
                // 一致途中.
                case CHAR_MATCH.MATCH_CONTINUE:
                    break;

                // 例外3文字綴りで一致.
                case CHAR_MATCH.MATCH_EXCHAR3:
                    this.InputedCharacters += this.CurrentCorrect.CorrectSpellingEx3.Cha;
                    this.CurrentIndex += 3;
                    status = this.Expect();
                    break;

                // 例外2文字綴りで一致.
                case CHAR_MATCH.MATCH_EXCHAR2:
                    this.InputedCharacters += this.CurrentCorrect.CorrectSpellingEx2.Cha;
                    this.CurrentIndex += 2;
                    status = this.Expect();
                    break;

                // 2文字綴りで一致.
                case CHAR_MATCH.MATCH_CHAR2:
                    this.InputedCharacters += this.CurrentCorrect.CorrectSpelling2.Cha;
                    this.CurrentIndex += 2;
                    status = this.Expect();
                    break;

                // 1文字綴りで一致.
                case CHAR_MATCH.MATCH_CHAR1:
                    this.InputedCharacters += this.CurrentCorrect.CorrectSpelling1.Cha;
                    this.CurrentIndex++;
                    status = this.Expect();
                    break;

                // 不一致.
                case CHAR_MATCH.NO_MATCH:
                    missType = this.CurrentCharacters;
                    this.CurrentCharacters = string.Empty;
                    this.WordResult.MissTypeCount++;
                    break;
            }

            // 入力結果を表示へ反映する.
            this.Viewer.ShowKeyResult(
                this.InputedCharacters,
                this.CurrentCharacters,
                this.CreateSpellings(),
                missType);

            // ステータスを返却.
            return status;
        }

        /// <summary>
        /// 綴りの候補を生成.
        /// </summary>
        private List<CorrectSpelling> CreateSpellings()
        {
            // 正答リストを作成して返す.
            var spellings = new List<CorrectSpelling>();

            // 既に入力済みの文字と一致する候補のみに絞って返す
            var listEx3 = this.CurrentCorrect.CorrectSpellingEx3.Spells
                .Where(spel => 0 == spel.IndexOf(this.CurrentCharacters))
                .ToList();
            if (0 < listEx3.Count)
            {
                spellings.Add(new CorrectSpelling
                {
                    Cha = this.CurrentCorrect.CorrectSpellingEx3.Cha,
                    Spells = listEx3,
                });
            }

            var listEx2 = this.CurrentCorrect.CorrectSpellingEx2.Spells
                .Where(spel => 0 == spel.IndexOf(this.CurrentCharacters))
                .ToList();
            if (0 < listEx2.Count)
            {
                spellings.Add(new CorrectSpelling
                {
                    Cha = this.CurrentCorrect.CorrectSpellingEx2.Cha,
                    Spells = listEx2,
                });
            }

            var list2 = this.CurrentCorrect.CorrectSpelling2.Spells
                .Where(spel => 0 == spel.IndexOf(this.CurrentCharacters))
                .ToList();
            if (0 < list2.Count)
            {
                spellings.Add(new CorrectSpelling
                {
                    Cha = this.CurrentCorrect.CorrectSpelling2.Cha,
                    Spells = list2,
                });
            }

            var list1 = this.CurrentCorrect.CorrectSpelling1.Spells
                .Where(spel => 0 == spel.IndexOf(this.CurrentCharacters))
                .ToList();
            if (0 < list1.Count)
            {
                spellings.Add(new CorrectSpelling
                {
                    Cha = this.CurrentCorrect.CorrectSpelling1.Cha,
                    Spells = list1,
                });
            }

            return spellings;
        }

        /// <summary>
        /// 文字列の一致を確認.
        /// </summary>
        /// <param name="characters">一致確認する文字列</param>
        /// <returns>一致状況</returns>
        private CHAR_MATCH CheckMatch(string characters)
        {
            // 文字無しの場合は一致継続.
            if (characters.IsEmpty())
            {
                return CHAR_MATCH.MATCH_CONTINUE;
            }

            // 例外3文字綴りで完全一致
            if (null != this.CurrentCorrect.CorrectSpellingEx3.Spells
                .Find(spelling => spelling.Equals(characters)))
            {
                return CHAR_MATCH.MATCH_EXCHAR3;
            }

            // 例外2文字綴りで完全一致
            if (null != this.CurrentCorrect.CorrectSpellingEx2.Spells
                .Find(spelling => spelling.Equals(characters)))
            {
                return CHAR_MATCH.MATCH_EXCHAR2;
            }

            // 2文字綴りで完全一致
            if (null != this.CurrentCorrect.CorrectSpelling2.Spells
                .Find(spelling => spelling.Equals(characters)))
            {
                return CHAR_MATCH.MATCH_CHAR2;
            }

            // 1文字綴りで完全一致
            if (null != this.CurrentCorrect.CorrectSpelling1.Spells
                .Find(spelling => spelling.Equals(characters)))
            {
                return CHAR_MATCH.MATCH_CHAR1;
            }

            // 例外3文字綴りで前方一致
            if (null != this.CurrentCorrect.CorrectSpellingEx3.Spells
                .Find(spelling => 0 == spelling.IndexOf(characters)))
            {
                return CHAR_MATCH.MATCH_CONTINUE;
            }

            // 例外2文字綴りで前方一致
            if (null != this.CurrentCorrect.CorrectSpellingEx2.Spells
                .Find(spelling => 0 == spelling.IndexOf(characters)))
            {
                return CHAR_MATCH.MATCH_CONTINUE;
            }

            // 2文字綴りで前方一致
            if (null != this.CurrentCorrect.CorrectSpelling2.Spells
                .Find(spelling => 0 == spelling.IndexOf(characters)))
            {
                return CHAR_MATCH.MATCH_CONTINUE;
            }

            // 1文字綴りで前方一致
            if (null != this.CurrentCorrect.CorrectSpelling1.Spells
                .Find(spelling => 0 == spelling.IndexOf(characters)))
            {
                return CHAR_MATCH.MATCH_CONTINUE;
            }

            return CHAR_MATCH.NO_MATCH;
        }
    }
}
