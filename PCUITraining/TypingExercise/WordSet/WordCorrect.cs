using System.Collections.Generic;
using System.Linq;
using TypingExercise.Definitions;

namespace TypingExercise.WordSet
{
    /// <summary>
    /// 正答
    /// </summary>
    public class WordCorrect
    {
        // 処理文字数.
        public enum SPELLING_WORD
        {
            WORD_1,
            WORD_2,
            WORD_3,
        }

        // ン処理の対象文字.
        public static readonly string NN = "ン";

        // ッ処理の対象文字.
        public static readonly string XTU = "ッ";

        // 例外処理対象外アルファベット[母音,n]
        public static readonly string[] IGNORE_EX = new string[]
        {
            "a",
            "i",
            "u",
            "e",
            "o",
            "n"
        };

        /// <summary>
        /// 対象文字(1～3文字)
        /// </summary>
        public string TargetCharacter { get; set; }

        /// <summary>
        /// 正しい1文字綴り.
        /// </summary>
        public CorrectSpelling CorrectSpelling1 { get; set; }

        /// <summary>
        /// 正しい2文字綴り.
        /// </summary>
        public CorrectSpelling CorrectSpelling2 { get; set; }

        /// <summary>
        /// 正しい例外2文字綴り.
        /// </summary>
        public CorrectSpelling CorrectSpellingEx2 { get; set; }

        /// <summary>
        /// 正しい例外3文字綴り.
        /// </summary>
        public CorrectSpelling CorrectSpellingEx3 { get; set; }


        /// <summary>
        /// コンストラクタ(JsonI/O用).
        /// </summary>
        public WordCorrect()
        {
            this.TargetCharacter = string.Empty;
            this.CorrectSpelling1 = new CorrectSpelling();
            this.CorrectSpelling2 = new CorrectSpelling();
            this.CorrectSpellingEx2 = new CorrectSpelling();
            this.CorrectSpellingEx3 = new CorrectSpelling();
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="character">対象文字列</param>
        public WordCorrect(string character)
        {
            this.TargetCharacter = character;
            this.CorrectSpelling1 = new CorrectSpelling();
            this.CorrectSpelling2 = new CorrectSpelling();
            this.CorrectSpellingEx2 = new CorrectSpelling();
            this.CorrectSpellingEx3 = new CorrectSpelling();

            // 文字が無ければ処理不要.
            if (character.Length <= 0)
            {
                return;
            }

            // 正答テーブルを取得.
            var correctTbl = TypExc.CorrectSpellingTable;

            // 一文字切り出す.
            var cha1 = character.Substring(0, 1);

            // 静的な1文字綴りを取得する.
            this.CorrectSpelling1 = correctTbl.Table1
                .Find(one => one.Cha.Equals(cha1))
                ?? new CorrectSpelling();

            // 二文字以上の場合は.
            if (1 < character.Length)
            {
                // 二文字切り出す.
                var cha2 = character.Substring(0, 2);

                // 静的な2文字綴りを取得する.
                this.CorrectSpelling2 = correctTbl.Table2
                    .Find(two => two.Cha.Equals(cha2))
                    ?? new CorrectSpelling();

                // 例外2文字綴りを生成する.
                this.CorrectSpellingEx2 = CreateExceptionalCorrectSpelling(SPELLING_WORD.WORD_2, cha2)
                    ?? new CorrectSpelling();

                // 三文字以上の場合は.
                if (2 < character.Length)
                {
                    // 三文字切り出す.
                    var cha3 = character.Substring(0, 3);

                    // 例外3文字綴りを生成する.
                    this.CorrectSpellingEx3 = CreateExceptionalCorrectSpelling(SPELLING_WORD.WORD_3, cha3)
                        ?? new CorrectSpelling();
                }
            }
        }

        /// <summary>
        /// 例外的な綴り(ン,ッ)を生成する.
        /// </summary>
        /// <param name="sw">対象を何文字で判定するか</param>
        /// <param name="characters">対象文字列</param>
        /// <returns></returns>
        private static CorrectSpelling CreateExceptionalCorrectSpelling(SPELLING_WORD sw, string characters)
        {
            // 一文字目と二文字目以降を分割する.
            var firstHalf = characters.Substring(0, 1);
            var letterHalf = characters.Substring(1);

            // 例外綴り考慮の要否.
            // 最初の文字が"ン"か"ッ"の場合のみ処理する.
            if (!firstHalf.Equals(NN) && !firstHalf.Equals(XTU))
            {
                return null;
            }

            // 二文字連続で例外の場合も除外する.
            // ・二文字連続で"ン"は以降の処理で除外されるが、ここで除いてしまう.
            // ・二文字連続で"ッ"はtttsuのような綴りを生成してしまう為、除外する.
            var secondChar = letterHalf.Substring(0, 1);
            if (secondChar.Equals(NN) || secondChar.Equals(XTU))
            {
                return null;
            }

            // 2文字目以降の正しい綴りを生成する(自身を利用して再帰処理)
            var letterCorrect = new WordCorrect(letterHalf);

            // 2文字目以降の正しい綴りを取得.
            CorrectSpelling letterCorrectSpelling = null;
            switch (sw)
            {
                case SPELLING_WORD.WORD_2:
                    letterCorrectSpelling = letterCorrect.CorrectSpelling1;
                    break;

                case SPELLING_WORD.WORD_3:
                    letterCorrectSpelling = letterCorrect.CorrectSpelling2;
                    break;

                default:
                    return null;
            }

            // 残っている文字の綴りが無い場合は考慮不要.
            // ・残り一文字が♂とか♀
            // ・残りの二文字綴りが無い場合.
            if (null == letterCorrectSpelling)
            {
                return null;
            }

            // 綴りの最初のアルファベットが母音[aiueo]または[n]で始まるものは除外する.
            var fillterdList = letterCorrectSpelling.Spells
                .Where(spell =>
                {
                    if (spell.Length <= 0)
                    {
                        return false;
                    }

                    var headChar = spell.Substring(0, 1);

                    // IGNORE_EXの何れかと一致する場合はfalse,
                    return !IGNORE_EX.Any(ignoreEx => ignoreEx == headChar);
                })
                .ToList();

            // 例外綴りを生成する.
            var correctSpellingList = new List<string>();
            if (firstHalf.Equals(NN))
            {
                // "ン"の場合は、先頭にnを追加して再リスト.
                correctSpellingList = fillterdList
                    .Select(spell => "n" + spell)
                    .ToList();
            }
            else if (firstHalf.Equals(XTU))
            {
                // "ッ"の場合は、先頭に先頭と同じアルファベットを追加して再リスト.
                correctSpellingList = fillterdList
                    .Select(spell => spell.Substring(0, 1) + spell)
                    .ToList();
            }

            // 正答を生成して返す.
            return new CorrectSpelling()
            {
                Cha = characters,
                Spells = correctSpellingList,
            };
        }
    }
}
