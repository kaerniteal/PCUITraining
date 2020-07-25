using Common.Extentions;
using System;
using System.Linq;

namespace TextInputExercise.TextSet
{
    /// <summary>
    /// 言葉を表すクラスの基底クラス
    /// </summary>
    public class TextBase
    {
        /// <summary>
        /// オリジナル文字列.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// 正答リスト.
        /// </summary>
        public TextCorrect[] correctList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public TextBase()
        {
            this.Text = string.Empty;
            this.correctList = new TextCorrect[0];
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="word">文字列</param>
        public TextBase(string word)
        {
            this.SetText(word);
        }

        /// <summary>
        /// 全角に変換して文字列をセットする.
        /// </summary>
        /// <param name="text">文字列</param>
        public void SetText(string text)
        {
            this.Text = text;
            this.correctList = Parse(this.Text);
        }

        /// <summary>
        /// 解析処理.
        /// </summary>
        /// <param name="text">解析対象文字列</param>
        /// <returns>正答リスト</returns>
        private static TextCorrect[] Parse(string text)
        {
            try
            {
                return text
                    .ToCharArray()
                    .Where(cha => !TextCorrect.IsIgnoreCorrectCheck(cha))
                    .Select(cha => new TextCorrect(cha))
                    .ToArray();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("[{0}]の正答の生成に失敗しました。".Fmt(text));
            }

            return new TextCorrect[0];
        }
    }
}
