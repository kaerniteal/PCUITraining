using Common.Extentions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace TypingExercise.WordSet
{
    /// <summary>
    /// 言葉を表すクラスの基底クラス
    /// </summary>
    public class WordBase
    {
        /// <summary>
        /// オリジナル文字列.
        /// </summary>
        public string orgWord { get; set; }

        /// <summary>
        /// 入力対象文字列.
        /// </summary>
        public string targetWord { get; set; }

        /// <summary>
        /// 正答リスト.
        /// </summary>
        public WordCorrect[] correctList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public WordBase()
        {
            this.orgWord = string.Empty;
            this.targetWord = string.Empty;
            this.correctList = new WordCorrect[0];
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="word">文字列</param>
        public WordBase(string word)
        {
            this.SetWord(word);
        }

        /// <summary>
        /// 全角カタカナに変換して文字列をセットする.
        /// </summary>
        /// <param name="word">文字列</param>
        public void SetWord(string word)
        {
            this.orgWord = word;
            var zenkaku = Strings.StrConv(word, VbStrConv.Wide);
            this.targetWord = Strings.StrConv(zenkaku, VbStrConv.Katakana);
            this.correctList = Parse(this.targetWord);
        }

        /// <summary>
        /// 解析処理.
        /// </summary>
        /// <param name="targetWord">解析対象文字列</param>
        /// <returns>正答リスト</returns>
        private static WordCorrect[] Parse(string targetWord)
        {
            var list = new List<WordCorrect>();

            try
            {
                var maxLength = targetWord.Length;
                for (int ii = 0; ii < maxLength; ii++)
                {
                    // 残り文字数.
                    var remainder = maxLength - ii;

                    // 1文字確保.
                    var character = targetWord.Substring(ii, 1);
                    if (2 < remainder)
                    {
                        // 3文字以上残っていれば3文字確保.
                        character = targetWord.Substring(ii, 3);
                    }
                    else if (1 < remainder)
                    {
                        // 2文字以上残っていれば2文字確保.
                        character = targetWord.Substring(ii, 2);
                    }

                    // 正答を生成する.
                    list.Add(new WordCorrect(character));
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("[{0}]の綴りの生成に失敗しました。".Fmt(targetWord));
            }

            return list.ToArray();
        }
    }
}
