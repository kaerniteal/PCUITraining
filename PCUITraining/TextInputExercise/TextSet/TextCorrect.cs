using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextInputExercise.TextSet
{
    /// <summary>
    /// 正答
    /// </summary>
    public class TextCorrect
    {
        /// <summary>
        /// 対象文字.
        /// </summary>
        public string Char { get; set; }

        /// <summary>
        /// 正答辞書.
        /// </summary>
        public HashSet<string> Correct { get; set; }

        /// <summary>
        /// チェック不要文字正規表現パターン.
        /// </summary>
        private static Regex IgnoreCheck { get; set; }

        /// <summary>
        /// 互換許容パータン.
        /// </summary>
        public static readonly List<List<string>> CompatibleTolerancePattern = new List<List<string>>
        {
            // ハイフンパターン.
            new List<string>
            {
                "-",    // [-]:45
                "‐",   // [‐]:8208
                "―",   // [―]:8213
                "ー",   // [ー]:12540
                "ｰ",    // [ｰ]:65392
                "－",   // [－]:65293
                "‑",    // [?]:8209
                "–",    // [?]:8211
                "—",    // [?]:8212
                "−",    // [?]:8722
            },
        };


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="character">対象文字列</param>
        public TextCorrect(char character)
        {
            // 対象文字.
            this.Char = character.ToString();
            this.Correct = new HashSet<string>();

            // 正答を生成.
            this.CreateCorrect();
        }

        /// <summary>
        /// 正答を生成する.
        /// </summary>
        private void CreateCorrect()
        {
            // 対象文字列自体を登録.
            this.Correct.Add(this.Char);

            // 全角を登録.
            this.Correct.Add(Strings.StrConv(this.Char, VbStrConv.Wide));

            // 半角を登録.
            this.Correct.Add(Strings.StrConv(this.Char, VbStrConv.Narrow));

            // 互換許容パターンがあればここで登録.
            foreach(var grp in CompatibleTolerancePattern)
            {
                if (grp.Contains(this.Char))
                {
                    foreach(var pat in grp)
                    {
                        this.Correct.Add(pat);
                    }
                }
            }
        }

        /// <summary>
        /// 正答の確認の除外対象かどうか(例：スペースやタブはチェック不要).
        /// </summary>
        /// <param name="cha">チェック対象文字</param>
        /// <returns>不要な場合：true  必要な場合：flase</returns>
        public static bool IsIgnoreCorrectCheck(char cha)
        {
            if (null == IgnoreCheck)
            {
                IgnoreCheck = new Regex("\\s+", RegexOptions.Compiled);
            }

            // 除外文字に該当するかどうかを返す.
            return IgnoreCheck.IsMatch(cha.ToString());
        }
    }
}
